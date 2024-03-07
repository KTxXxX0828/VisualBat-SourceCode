/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#nullable disable
namespace VisualBat
{
  public class RichTextBoxEx : RichTextBox
  {
    public const int DecUBUpdatingMessage = 32770;
    public const int DelayedUpdatingMessage = 32771;
    public const int ReraiseEventMessage = 32772;
    private const int WM_SETREDRAW = 11;
    private const int WM_IME_COMPOSITION = 271;
    private const int EM_GETSCROLLPOS = 1245;
    private const int EM_SETSCROLLPOS = 1246;
    private const int GCS_RESULTSTR = 2048;
    private const int GCS_COMPSTR = 8;
    private List<RichTextBoxEx.UndoElem> undoBuffer = new List<RichTextBoxEx.UndoElem>();
    private int undoBufferIndex;
    private RichTextBoxEx.UndoState undoState;
    private int undoBufferUpdatingCounter;
    private RichTextBoxEx.UndoElem preUe;
    private int imeSelectionStart = -1;
    private int redrawLockCount;
    private Stack<RichTextBoxEx.POINT> redrawPointStack = new Stack<RichTextBoxEx.POINT>();
    private Dictionary<MethodBase, MethodInvoker> reraiseEventDic = new Dictionary<MethodBase, MethodInvoker>();
    private bool doingReraiseEvent;
    private bool usingReraiseEvent;
    private bool scrollingPos;

    [DllImport("user32.dll", EntryPoint = "SendMessageW")]
    private static extern int SendMessage(int hwnd, uint wMsg, int wParam, int lParam);

    [DllImport("user32.dll", EntryPoint = "PostMessageW")]
    private static extern bool PostMessage(int hwnd, uint wMsg, int wParam, int lParam);

    [DllImport("user32.dll", EntryPoint = "SendMessageW")]
    private static extern int SendMessage(
      int hwnd,
      uint wMsg,
      int wParam,
      ref RichTextBoxEx.POINT lParam);

    [DllImport("Imm32.dll")]
    private static extern int ImmGetContext(int hWnd);

    [DllImport("Imm32.dll")]
    private static extern bool ImmReleaseContext(int hWnd, int hIMC);

    [DllImport("Imm32.dll")]
    private static extern int ImmGetCompositionString(
      int hIMC,
      int dwIndex,
      StringBuilder lpBuf,
      int dwBufLen);

    public MethodInvoker ScrollToCaretDelg { get; set; }

    public VScrollBar Vsc { get; set; }

    public bool EventSkip { get; set; }

    public bool TextChangedSkip { get; set; }

    public bool SelectionChangedSkip { get; set; }

    public new bool CanUndo => this.undoBufferIndex > 0;

    public new bool CanRedo => this.undoBufferIndex != this.undoBuffer.Count;

    public object TextEditState
    {
      get => !this.CanUndo ? (object) null : (object) this.undoBuffer[this.undoBufferIndex - 1];
    }

    public string PrevText { get; set; }

    public int PrevSelectionStart { get; set; }

    public string PrevSelectedText { get; set; }

    public Point PrevPosition { get; set; }

    public int DelayedPrevSelectionStart { get; set; }

    public string DelayedPrevSelectedText { get; set; }

    public Point DelayedPrevPosition { get; set; }

    public bool IsDoingUndoOrRedo => this.undoState != RichTextBoxEx.UndoState.None;

    public int UndoSelectionStart { get; set; }

    public new int SelectionStart
    {
      get => !this.IsDoingUndoOrRedo ? base.SelectionStart : this.UndoSelectionStart;
      set => base.SelectionStart = value;
    }

    public RichTextBoxEx()
    {
      this.PrevText = "";
      this.PrevSelectedText = "";
      this.PrevSelectionStart = 0;
      this.PrevPosition = new Point();
    }

    protected override void WndProc(ref Message m)
    {
      switch (m.Msg)
      {
        case 271:
          int context = RichTextBoxEx.ImmGetContext(this.Handle.ToInt32());
          if ((m.LParam.ToInt32() & 2048) != 0)
            this.imeSelectionStart = -1;
          if ((m.LParam.ToInt32() & 8) != 0)
            this.imeSelectionStart = this.PrevSelectionStart;
          if (m.LParam.ToInt32() == 0)
            this.imeSelectionStart = -1;
          RichTextBoxEx.ImmReleaseContext(this.Handle.ToInt32(), context);
          break;
        case 32770:
          if (this.undoBufferUpdatingCounter > 0)
            --this.undoBufferUpdatingCounter;
          if (this.undoBufferUpdatingCounter == 0)
          {
            this.preUe = (RichTextBoxEx.UndoElem) null;
            this.SelectionChangedSkip = false;
            break;
          }
          break;
        case 32771:
          this.PrevSelectionStart = this.DelayedPrevSelectionStart;
          this.PrevSelectedText = this.DelayedPrevSelectedText;
          this.PrevPosition = this.DelayedPrevPosition;
          break;
        case 32772:
          this.doingReraiseEvent = true;
          foreach (MethodBase key in new List<MethodBase>((IEnumerable<MethodBase>) this.reraiseEventDic.Keys))
          {
            this.reraiseEventDic[key]();
            this.reraiseEventDic.Remove(key);
          }
          this.doingReraiseEvent = false;
          break;
      }
      base.WndProc(ref m);
    }

    protected override bool ProcessCmdKey(ref Message m, Keys keyData)
    {
      return (Keys.KeyCode & keyData) == Keys.Insert || (Keys.KeyCode & keyData) == Keys.Tab && (Keys.Control & keyData) == Keys.Control || base.ProcessCmdKey(ref m, keyData);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      this.PrevSelectionStart = this.imeSelectionStart != -1 ? this.imeSelectionStart : this.SelectionStart;
      base.OnKeyDown(e);
      this.UpdateUndoBuffer();
    }

    public void UpdateUndoBuffer()
    {
      ++this.undoBufferUpdatingCounter;
      RichTextBoxEx.PostMessage(this.Handle.ToInt32(), 32770U, 0, 0);
    }

    public void DelayedUpdatingPrevInfo()
    {
      RichTextBoxEx.PostMessage(this.Handle.ToInt32(), 32771U, 0, 0);
    }

    public void EnableRedrawLock(bool toEnabled)
    {
      this.redrawLockCount += toEnabled ? 1 : -1;
      if (this.redrawLockCount == 0)
      {
        this.usingReraiseEvent = false;
        RichTextBoxEx.POINT point = this.redrawPointStack.Pop();
        this.SetScrollPos(point.x, point.y);
        RichTextBoxEx.SendMessage(this.Handle.ToInt32(), 11U, 1, 0);
        this.Invalidate(true);
        if (this.Vsc == null)
          return;
        RichTextBoxEx.SendMessage(this.Vsc.Handle.ToInt32(), 11U, 1, 0);
        this.Vsc.Invalidate(true);
      }
      else
      {
        if (!toEnabled || this.redrawLockCount != 1)
          return;
        if (this.undoState == RichTextBoxEx.UndoState.None)
          this.usingReraiseEvent = true;
        RichTextBoxEx.POINT lParam = new RichTextBoxEx.POINT();
        RichTextBoxEx.SendMessage(this.Handle.ToInt32(), 1245U, 0, ref lParam);
        this.redrawPointStack.Push(lParam);
        RichTextBoxEx.SendMessage(this.Handle.ToInt32(), 11U, 0, 0);
        if (this.Vsc == null)
          return;
        RichTextBoxEx.SendMessage(this.Vsc.Handle.ToInt32(), 11U, 0, 0);
      }
    }

    protected override void OnTextChanged(EventArgs e)
    {
      if (this.TextChangedSkip || this.EventSkip || this.scrollingPos)
        return;
      if (this.undoState == RichTextBoxEx.UndoState.None && this.undoBufferUpdatingCounter > 0 && this.Text != this.PrevText)
      {
        RichTextBoxEx.UndoElem undoElem;
        if (this.preUe != null)
        {
          undoElem = this.preUe;
        }
        else
        {
          undoElem = new RichTextBoxEx.UndoElem();
          undoElem.Pos = this.PrevSelectionStart;
          if (this.PrevSelectedText == "")
          {
            undoElem.InsertLength = this.Text.Length - this.PrevText.Length;
          }
          else
          {
            undoElem.InsertLength = this.Text.Length - (this.PrevText.Length - this.PrevSelectedText.Length);
            undoElem.UndoData = this.PrevSelectedText;
          }
        }
        if (this.undoBufferIndex < this.undoBuffer.Count)
          this.undoBuffer.RemoveRange(this.undoBufferIndex, this.undoBuffer.Count - this.undoBufferIndex);
        this.undoBuffer.Add(undoElem);
        ++this.undoBufferIndex;
        this.preUe = (RichTextBoxEx.UndoElem) null;
        this.SelectionChangedSkip = false;
        --this.undoBufferUpdatingCounter;
      }
      base.OnTextChanged(e);
    }

    public void MakePreUE(Keys key)
    {
      this.preUe = new RichTextBoxEx.UndoElem();
      this.preUe.InsertLength = 0;
      if (key == Keys.Delete)
        this.preUe.IsDelete = true;
      if (this.SelectedText == "")
      {
        switch (key)
        {
          case Keys.Back:
            if (this.SelectionStart > 0)
            {
              this.preUe.Pos = this.SelectionStart - 1;
              this.preUe.UndoData = this.Text.Substring(this.SelectionStart - 1, 1);
              break;
            }
            break;
          case Keys.Delete:
            if (this.SelectionStart < this.Text.Length)
            {
              this.preUe.Pos = this.SelectionStart;
              this.preUe.UndoData = this.Text.Substring(this.SelectionStart, 1);
              break;
            }
            break;
        }
      }
      else
      {
        this.preUe.Pos = this.SelectionStart;
        this.preUe.UndoData = this.SelectedText;
      }
      this.SelectionChangedSkip = true;
    }

    public new void Undo()
    {
      if (!this.CanUndo)
        return;
      RichTextBoxEx.UndoElem undoElem = this.undoBuffer[--this.undoBufferIndex];
      string str = this.Text;
      if (undoElem.InsertLength > 0)
      {
        if (undoElem.RedoData == null)
          undoElem.RedoData = str.Substring(undoElem.Pos, undoElem.InsertLength);
        str = str.Remove(undoElem.Pos, undoElem.InsertLength);
      }
      if (undoElem.UndoData != null)
        str = str.Insert(undoElem.Pos, undoElem.UndoData);
      this.UndoSelectionStart = undoElem.Pos + (undoElem.IsDelete || undoElem.UndoData == null ? 0 : undoElem.UndoData.Length);
      this.undoState = RichTextBoxEx.UndoState.Undo;
      this.EnableRedrawLock(true);
      this.Text = str;
      this.undoState = RichTextBoxEx.UndoState.None;
      this.BeginInvoke((Delegate) (() =>
      {
        this.EnableRedrawLock(false);
        this.SelectionStart = this.UndoSelectionStart;
      }));
    }

    public new void Redo()
    {
      if (!this.CanRedo)
        return;
      RichTextBoxEx.UndoElem undoElem = this.undoBuffer[this.undoBufferIndex++];
      string str = this.Text;
      if (undoElem.UndoData != null)
        str = str.Remove(undoElem.Pos, undoElem.UndoData.Length);
      if (undoElem.RedoData != null)
        str = str.Insert(undoElem.Pos, undoElem.RedoData);
      this.UndoSelectionStart = undoElem.Pos + (undoElem.RedoData != null ? undoElem.RedoData.Length : 0);
      this.undoState = RichTextBoxEx.UndoState.Redo;
      this.EnableRedrawLock(true);
      this.Text = str;
      this.undoState = RichTextBoxEx.UndoState.None;
      this.BeginInvoke((Delegate) (() =>
      {
        this.EnableRedrawLock(false);
        this.SelectionStart = this.UndoSelectionStart;
      }));
    }

    private void ChangeTextWithoutEvent(string cText)
    {
      this.TextChangedSkip = true;
      this.Text = cText;
      this.TextChangedSkip = false;
    }

    public new void Clear()
    {
      this.Text = "";
      this.undoBuffer.Clear();
      this.undoBufferIndex = 0;
      this.PrevText = "";
      this.DelayedPrevSelectionStart = this.PrevSelectionStart = 0;
      this.DelayedPrevSelectedText = this.PrevSelectedText = "";
      this.DelayedPrevPosition = this.PrevPosition = new Point();
    }

    public new void Cut()
    {
      this.SelectionChangedSkip = true;
      this.UpdateUndoBuffer();
      base.Cut();
    }

    public new void Paste()
    {
      Clipboard.GetDataObject();
      string data = (string) Clipboard.GetDataObject().GetData(DataFormats.UnicodeText);
      if (data == null)
        return;
      this.SelectionChangedSkip = true;
      this.UpdateUndoBuffer();
      this.SelectedText = data;
    }

    public void UpdateBreakPointLineDic(Dictionary<int, bool> bpLineDic)
    {
      if (this.undoBufferIndex == 0)
      {
        if (this.undoState != RichTextBoxEx.UndoState.Undo)
          return;
      }
      try
      {
        RichTextBoxEx.UndoElem undoElem = (RichTextBoxEx.UndoElem) null;
        int moveLine = 0;
        string str1 = (string) null;
        if (this.undoState == RichTextBoxEx.UndoState.None)
        {
          undoElem = this.undoBuffer[this.undoBufferIndex - 1];
          str1 = undoElem.UndoData;
          if (undoElem.UndoData != null)
            moveLine -= undoElem.UndoData.Length - undoElem.UndoData.Replace("\n", "").Length;
          if (undoElem.InsertLength > 0)
          {
            string str2 = this.Text.Substring(undoElem.Pos, undoElem.InsertLength);
            moveLine += str2.Length - str2.Replace("\n", "").Length;
          }
        }
        else if (this.undoState == RichTextBoxEx.UndoState.Undo)
        {
          undoElem = this.undoBuffer[this.undoBufferIndex];
          str1 = undoElem.RedoData;
          if (undoElem.UndoData != null)
            moveLine += undoElem.UndoData.Length - undoElem.UndoData.Replace("\n", "").Length;
          if (undoElem.RedoData != null)
            moveLine -= undoElem.RedoData.Length - undoElem.RedoData.Replace("\n", "").Length;
        }
        else if (this.undoState == RichTextBoxEx.UndoState.Redo)
        {
          undoElem = this.undoBuffer[this.undoBufferIndex - 1];
          str1 = undoElem.UndoData;
          if (undoElem.UndoData != null)
            moveLine -= undoElem.UndoData.Length - undoElem.UndoData.Replace("\n", "").Length;
          if (undoElem.RedoData != null)
            moveLine += undoElem.RedoData.Length - undoElem.RedoData.Replace("\n", "").Length;
        }
        if (moveLine == 0)
          return;
        if (str1 != null)
        {
          int length1 = str1.Length;
          int length2 = str1.Replace("\n", "").Length;
        }
        int num1 = this.GetLineFromCharIndex(undoElem.Pos) + 1;
        int charIndexFromLine = this.GetFirstCharIndexFromLine(num1 - 1);
        string input1 = this.Text.Substring(charIndexFromLine, undoElem.Pos - charIndexFromLine);
        int num2 = Regex.IsMatch(input1, "^[ \\t]*$") ? 0 : 1;
        int num3 = moveLine;
        if (str1 != null)
        {
          int num4 = num1 + (str1.Length - str1.Replace("\n", "").Length);
          int pos = undoElem.Pos;
          int num5 = this.Text.Substring(pos).IndexOf('\n');
          int num6 = num5 + (num5 == -1 ? this.Text.Length + 1 : pos);
          string input2 = this.Text.Substring(pos, num6 - pos);
          int num7 = input1 != "" ? 1 : (Regex.IsMatch(input2, "^[ \\t]*$") ? 1 : 0);
          for (int key = num1 + num2; key < num4 + num7; ++key)
          {
            if (bpLineDic.ContainsKey(key))
              bpLineDic.Remove(key);
          }
        }
        List<int> intList = new List<int>((IEnumerable<int>) bpLineDic.Keys);
        intList.Sort((Comparison<int>) ((a, b) => Math.Sign(moveLine) * (a == b ? 0 : (a < b ? 1 : -1))));
        foreach (int key in intList)
        {
          if (key >= num1 + num2)
          {
            bpLineDic.Remove(key);
            bpLineDic[key + moveLine] = true;
          }
        }
      }
      catch
      {
        0.ToString();
      }
    }

    public void Delete()
    {
      if (!this.ReadOnly)
        this.MakePreUE(Keys.Delete);
      RichTextBoxEx.SendMessage(this.Handle.ToInt32(), 256U, 46, 0);
      RichTextBoxEx.SendMessage(this.Handle.ToInt32(), 257U, 46, 0);
    }

    public bool RegisterReraiseEvent(MethodBase mb, MethodInvoker delg)
    {
      if (this.doingReraiseEvent || !this.usingReraiseEvent)
        return false;
      if (this.reraiseEventDic.ContainsKey(mb))
        return true;
      if (this.reraiseEventDic.Count == 0)
        RichTextBoxEx.PostMessage(this.Handle.ToInt32(), 32772U, 0, 0);
      this.reraiseEventDic[mb] = delg;
      return true;
    }

    public void SetScrollPos(int x, int y)
    {
      this.scrollingPos = true;
      RichTextBoxEx.SendMessage(this.Handle.ToInt32(), 1246U, 0, ref new RichTextBoxEx.POINT()
      {
        x = x,
        y = y
      });
      this.scrollingPos = false;
    }

    public void ChangeSelectedText(string newText)
    {
      this.UpdateUndoBuffer();
      this.SelectionChangedSkip = true;
      this.PrevText = this.Text;
      this.PrevSelectionStart = this.DelayedPrevSelectionStart;
      this.PrevSelectedText = this.DelayedPrevSelectedText;
      this.PrevPosition = this.DelayedPrevPosition;
      this.SelectedText = newText;
    }

    public void UpdateDelayedSelectionParams()
    {
      this.DelayedPrevSelectionStart = this.SelectionStart;
      this.DelayedPrevSelectedText = this.SelectedText;
      this.DelayedPrevPosition = this.GetPositionFromCharIndex(this.SelectionStart);
    }

    private struct POINT
    {
      public int x;
      public int y;
    }

    private class UndoElem
    {
      public string UndoData;
      public string RedoData;
      public int InsertLength;
      public int Pos;
      public bool IsDelete;
    }

    private enum UndoState
    {
      None,
      Undo,
      Redo,
    }
  }
}

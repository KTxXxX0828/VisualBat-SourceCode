/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace VisualBat
{
  public class LinedRichTextBox : UserControl
  {
    private const int EM_LINESCROLL = 182;
    private const int EM_GETFIRSTVISIBLELINE = 206;
    private const int EM_GETLINECOUNT = 186;
    private const int EM_GETSCROLLPOS = 1245;
    private const int EM_SETSCROLLPOS = 1246;
    private const int EM_GETSEL = 176;
    private const int EM_SETSEL = 177;
    private const int EM_GETRECT = 178;
    private const int EM_SETRECT = 179;
    private const int WM_SETREDRAW = 11;
    private IContainer components;
    private RichTextBoxEx rtxMain;
    private Panel pnlLineNumber;
    private VScrollBar vscMain;
    private Panel pnlVScrollBar;
    private Panel pnlPadArea;
    private Dictionary<int, bool> bpLineDic = new Dictionary<int, bool>();
    private int breakLine;
    private bool disableScrollEvent;
    private bool delayedEvent;
    private int textHeight;
    private int textBoxHeight;
    private int lineCount;
    private int visibleLineCount;
    private int firstVisibleLine;
    private int interpolationTargetIndex;
    private string interpolationTarget;
    private long highlightCounter;
    private Thread lastHighlightingThread;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.pnlLineNumber = new Panel();
      this.vscMain = new VScrollBar();
      this.pnlVScrollBar = new Panel();
      this.pnlPadArea = new Panel();
      this.rtxMain = new RichTextBoxEx();
      this.pnlVScrollBar.SuspendLayout();
      this.SuspendLayout();
      this.pnlLineNumber.Dock = DockStyle.Left;
      this.pnlLineNumber.Font = new Font("ＭＳ ゴシック", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.pnlLineNumber.Location = new Point(0, 0);
      this.pnlLineNumber.Name = "pnlLineNumber";
      this.pnlLineNumber.Size = new Size(50, 276);
      this.pnlLineNumber.TabIndex = 3;
      this.pnlLineNumber.Click += new EventHandler(this.pnlLineNumber_Click);
      this.pnlLineNumber.Paint += new PaintEventHandler(this.pnlLineNumber_Paint);
      this.pnlLineNumber.DoubleClick += new EventHandler(this.pnlLineNumber_DoubleClick);
      this.vscMain.Dock = DockStyle.Fill;
      this.vscMain.Location = new Point(0, 0);
      this.vscMain.Name = "vscMain";
      this.vscMain.Size = new Size(17, 256);
      this.vscMain.TabIndex = 4;
      this.vscMain.Scroll += new ScrollEventHandler(this.vscMain_Scroll);
      this.vscMain.ValueChanged += new EventHandler(this.vscMain_ValueChanged);
      this.pnlVScrollBar.Controls.Add((Control) this.vscMain);
      this.pnlVScrollBar.Controls.Add((Control) this.pnlPadArea);
      this.pnlVScrollBar.Dock = DockStyle.Right;
      this.pnlVScrollBar.Location = new Point(285, 0);
      this.pnlVScrollBar.Name = "pnlVScrollBar";
      this.pnlVScrollBar.Size = new Size(17, 276);
      this.pnlVScrollBar.TabIndex = 5;
      this.pnlPadArea.Dock = DockStyle.Bottom;
      this.pnlPadArea.Location = new Point(0, 256);
      this.pnlPadArea.Name = "pnlPadArea";
      this.pnlPadArea.Size = new Size(17, 20);
      this.pnlPadArea.TabIndex = 5;
      this.rtxMain.DelayedPrevPosition = new Point(0, 0);
      this.rtxMain.DelayedPrevSelectedText = (string) null;
      this.rtxMain.DelayedPrevSelectionStart = 0;
      this.rtxMain.DetectUrls = false;
      this.rtxMain.Dock = DockStyle.Fill;
      this.rtxMain.EventSkip = false;
      this.rtxMain.Font = new Font("ＭＳ ゴシック", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.rtxMain.HideSelection = false;
      this.rtxMain.Location = new Point(50, 0);
      this.rtxMain.Name = "rtxMain";
      this.rtxMain.PrevPosition = new Point(0, 0);
      this.rtxMain.PrevSelectedText = "";
      this.rtxMain.PrevSelectionStart = 0;
      this.rtxMain.PrevText = "";
      this.rtxMain.ScrollBars = RichTextBoxScrollBars.ForcedHorizontal;
      this.rtxMain.ScrollToCaretDelg = (MethodInvoker) null;
      this.rtxMain.SelectionChangedSkip = false;
      this.rtxMain.Size = new Size(235, 276);
      this.rtxMain.TabIndex = 2;
      this.rtxMain.Text = "";
      this.rtxMain.TextChangedSkip = false;
      this.rtxMain.UndoSelectionStart = 0;
      this.rtxMain.Vsc = (VScrollBar) null;
      this.rtxMain.WordWrap = false;
      this.rtxMain.SelectionChanged += new EventHandler(this.rtxMain_SelectionChanged);
      this.rtxMain.VScroll += new EventHandler(this.rtxMain_VScroll);
      this.rtxMain.Click += new EventHandler(this.rtxMain_Click);
      this.rtxMain.FontChanged += new EventHandler(this.rtxMain_FontChanged);
      this.rtxMain.TextChanged += new EventHandler(this.rtxMain_TextChanged);
      this.rtxMain.KeyDown += new KeyEventHandler(this.rtxMain_KeyDown);
      this.rtxMain.KeyPress += new KeyPressEventHandler(this.rtxMain_KeyPress);
      this.rtxMain.Leave += new EventHandler(this.rtxMain_Leave);
      this.rtxMain.PreviewKeyDown += new PreviewKeyDownEventHandler(this.rtxMain_PreviewKeyDown);
      this.rtxMain.Resize += new EventHandler(this.rtxMain_Resize);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.rtxMain);
      this.Controls.Add((Control) this.pnlVScrollBar);
      this.Controls.Add((Control) this.pnlLineNumber);
      this.Name = nameof (LinedRichTextBox);
      this.Size = new Size(302, 276);
      this.Load += new EventHandler(this.LinedRichTextBox_Load);
      this.pnlVScrollBar.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    [DllImport("user32.dll", EntryPoint = "SendMessageW")]
    private static extern int SendMessage(int hwnd, uint wMsg, int wParam, int lParam);

    [DllImport("user32.dll", EntryPoint = "SendMessageW")]
    private static extern int SendMessage(int hwnd, uint wMsg, ref int wParam, ref int lParam);

    [DllImport("user32.dll", EntryPoint = "SendMessageW")]
    private static extern int SendMessage(
      int hwnd,
      uint wMsg,
      int wParam,
      ref LinedRichTextBox.POINT lParam);

    [DllImport("user32.dll", EntryPoint = "SendMessageW")]
    private static extern int SendMessage(
      int hwnd,
      uint wMsg,
      int wParam,
      ref LinedRichTextBox.RECT lParam);

    [DllImport("user32.dll")]
    private static extern bool GetCaretPos(ref LinedRichTextBox.POINT lpPoint);

    [DllImport("user32.dll")]
    private static extern bool SetCaretPos(int x, int y);

    public event EventHandler LineCountChanged;

    public event EventHandler VisibleLineCountChanged;

    public event EventHandler FirstVisibleLineChanged;

    public Action<int> ToggledBreakPointDelg { get; set; }

    public Action<bool> MoveNextTab { get; set; }

    public Action<string> DecidedIntellisenseDelg { get; set; }

    public LinedRichTextBox() => this.InitializeComponent();

    public override string Text
    {
      set => this.rtxMain.Text = value;
      get => this.rtxMain.Text;
    }

    public RichTextBoxEx TextBox => this.rtxMain;

    public Panel LineNumberPanel => this.pnlLineNumber;

    public ListBox LstIntellisense { get; set; }

    public int LineCount
    {
      protected set
      {
        bool flag = this.lineCount != value;
        this.lineCount = value;
        if (!flag)
          return;
        this.OnLineCountChanged(new EventArgs());
      }
      get => this.lineCount;
    }

    public int VisibleLineCount
    {
      protected set
      {
        bool flag = this.visibleLineCount != value;
        this.visibleLineCount = value;
        if (!flag)
          return;
        this.OnVisibleLineCountChanged(new EventArgs());
      }
      get => this.visibleLineCount;
    }

    public int FirstVisibleLine
    {
      protected set
      {
        bool flag = this.firstVisibleLine != value;
        this.firstVisibleLine = value;
        if (!flag)
          return;
        this.OnFirstVisibleLineChanged(new EventArgs());
      }
      get => this.firstVisibleLine;
    }

    public int BreakLine => this.breakLine;

    protected virtual void OnLineCountChanged(EventArgs e)
    {
      if (this.LineCountChanged != null)
        this.LineCountChanged((object) this.rtxMain, e);
      this.updateLineNumberPanelWidth();
      this.adjustScrollBar();
      this.rtxMain.UpdateBreakPointLineDic(this.bpLineDic);
    }

    protected virtual void OnVisibleLineCountChanged(EventArgs e)
    {
      if (this.VisibleLineCountChanged != null)
        this.VisibleLineCountChanged((object) this.rtxMain, e);
      this.adjustScrollBar();
    }

    protected virtual void OnFirstVisibleLineChanged(EventArgs e)
    {
      if (this.FirstVisibleLineChanged != null)
        this.FirstVisibleLineChanged((object) this.rtxMain, e);
      this.adjustScrollBar();
    }

    private void adjustScrollBar()
    {
      if (this.lineCount > this.visibleLineCount)
      {
        if (!this.vscMain.Enabled)
          this.vscMain.Enabled = true;
        this.vscMain.LargeChange = this.visibleLineCount;
        this.vscMain.Maximum = this.lineCount - 1;
        if (this.firstVisibleLine > this.lineCount)
          return;
        this.vscMain.Value = this.firstVisibleLine - 1;
      }
      else
      {
        if (!this.vscMain.Enabled)
          return;
        this.vscMain.Enabled = false;
        if (this.firstVisibleLine == 1)
          return;
        LinedRichTextBox.POINT lParam = new LinedRichTextBox.POINT();
        LinedRichTextBox.SendMessage(this.rtxMain.Handle.ToInt32(), 1245U, 0, ref lParam);
        lParam.y = 0;
        this.rtxMain.SetScrollPos(lParam.x, lParam.y);
        this.Invalidate(true);
      }
    }

    private void updateTextBoxHeight()
    {
      LinedRichTextBox.RECT lParam = new LinedRichTextBox.RECT();
      LinedRichTextBox.SendMessage(this.rtxMain.Handle.ToInt32(), 178U, 0, ref lParam);
      this.textBoxHeight = lParam.bottom - lParam.top;
      LinedRichTextBox.SendMessage(this.rtxMain.Handle.ToInt32(), 179U, 0, ref lParam);
    }

    private void updateTextHeight()
    {
      this.textHeight = TextRenderer.MeasureText(" ", this.rtxMain.Font).Height;
    }

    private void updateLineNumberPanelWidth()
    {
      this.pnlLineNumber.Width = (int) ((double) TextRenderer.MeasureText(string.Concat((object) this.lineCount), this.rtxMain.Font).Width * 1.1) + 14;
    }

    private void updateVisibleLineCount()
    {
      if (this.textHeight == 0)
        return;
      this.VisibleLineCount = this.textBoxHeight / this.textHeight;
    }

    private void updateLineCount()
    {
      this.LineCount = LinedRichTextBox.SendMessage(this.rtxMain.Handle.ToInt32(), 186U, 0, 0);
    }

    private void updateFirstVisibleLine()
    {
      LinedRichTextBox.POINT lpPoint = new LinedRichTextBox.POINT();
      LinedRichTextBox.GetCaretPos(ref lpPoint);
      this.rtxMain.GetPositionFromCharIndex(0);
      this.FirstVisibleLine = LinedRichTextBox.SendMessage(this.rtxMain.Handle.ToInt32(), 206U, 0, 0) + 1;
    }

    private bool isBackSelect()
    {
      LinedRichTextBox.POINT lpPoint = new LinedRichTextBox.POINT();
      LinedRichTextBox.GetCaretPos(ref lpPoint);
      int num = (this.rtxMain.Width - this.rtxMain.ClientSize.Width) / 2;
      if (this.rtxMain.PrevSelectedText.Length <= 0)
        return false;
      if (lpPoint.y < this.rtxMain.PrevPosition.Y)
        return true;
      return lpPoint.x + num == this.rtxMain.PrevPosition.X && lpPoint.y == this.rtxMain.PrevPosition.Y;
    }

    public new void Update()
    {
      if (!this.InvokeRequired)
        return;
      this.Invoke((Delegate) (() => this.Update()));
    }

    public string getColorTableStr(Color color)
    {
      return this.getColorTableStr((int) color.R, (int) color.G, (int) color.B);
    }

    public string getColorTableStr(int r, int g, int b)
    {
      Math.Min(r, Math.Min(g, b));
      Math.Max(r, Math.Max(g, b));
      return string.Format("\\red{0}\\green{1}\\blue{2};", (object) r, (object) g, (object) b);
    }

    public void UpdateKeywordHighlight()
    {
      if (this.delayedEvent || !this.Created)
        return;
      string rtf = this.rtxMain.Rtf;
      long curHighlightCounter = ++this.highlightCounter;
      Thread thread = new Thread((ThreadStart) (() =>
      {
        try
        {
          int num1 = rtf.IndexOf("{\\colortbl");
          string str1 = "{\\colortbl ;" + this.getColorTableStr(Setting.ForeColor) + this.getColorTableStr(0, 0, (int) byte.MaxValue) + this.getColorTableStr(153, 50, 204) + this.getColorTableStr(0, 160, 0) + "}";
          if (num1 != -1)
          {
            string str2 = rtf.Substring(0, num1);
            string str3 = rtf.Substring(rtf.Substring(num1).IndexOf('}') + str2.Length + 1);
            rtf = str2 + str1 + str3;
          }
          else
            rtf = rtf.Insert(rtf.IndexOf("\\viewkind"), str1);
          Match match1 = Regex.Match(rtf, "\\\\fs\\d+ ?");
          if (!match1.Success)
            return;
          int num2 = match1.Index + match1.Length;
          string header = rtf.Substring(0, num2) + "\\cf1 ";
          string text = rtf.Substring(num2);
          text = Regex.Replace(text, "(?<!\\\\)\\\\cf\\d+ ?", "");
          SortedDictionary<int, int> sortedDictionary = new SortedDictionary<int, int>();
          List<string> stringList1 = new List<string>();
          foreach (Match match2 in new Regex("(?:^|[\\s&|><\"]|(?<!\\\\)')(?<word>@?[a-z0-9]+)(?=$|[\\s\\\\&|><;,/=\"'])", RegexOptions.IgnoreCase | RegexOptions.Multiline).Matches(text))
          {
            Group group = match2.Groups["word"];
            if (BatKeyword.Dic.ContainsKey(group.Value.TrimStart('@')))
            {
              sortedDictionary[group.Index] = 2;
              int key = group.Index + group.Value.Length;
              if (!sortedDictionary.ContainsKey(key))
                sortedDictionary[key] = 1;
            }
          }
          if (Setting.HighlightVar)
          {
            List<string> stringList2 = new List<string>();
            foreach (Match match3 in new Regex("(?<var>(?:%[a-zA-Z0-9_[\\]]+?(?::(?:~-?\\d+(?:,-?\\d+)?|[^%!=]*=[^%!=]*))?%|![a-zA-Z0-9_[\\]]+?(?::(?:~-?\\d+(?:,-?\\d+)?|[^%!=]*=[^%!=]*))?!|%(?:~(?:[fdpnxsatz]*|\\$[a-z]+:))?\\d|%%(?:~(?:[fdpnxsatz]*|\\$[a-z]+:))?[a-zA-Z]))", RegexOptions.IgnoreCase | RegexOptions.Multiline).Matches(text))
            {
              Group group = match3.Groups["var"];
              sortedDictionary[group.Index] = 3;
              int key = group.Index + group.Value.Length;
              if (!sortedDictionary.ContainsKey(key))
                sortedDictionary[key] = 1;
            }
          }
          int[] array1 = new List<int>((IEnumerable<int>) sortedDictionary.Keys).ToArray();
          int index = 0;
          List<string> stringList3 = new List<string>();
          foreach (Match match4 in new Regex("^(?<comment>[ \\t]*(?::|@?rem[;:,. \\\\<>&|\\t]).*)$", RegexOptions.IgnoreCase | RegexOptions.Multiline).Matches(text))
          {
            Group group = match4.Groups["comment"];
            sortedDictionary[group.Index] = 4;
            int key = group.Index + group.Value.Length;
            while (index < array1.Length && array1[index] < key)
            {
              if (array1[index++] > group.Index)
                sortedDictionary.Remove(array1[index - 1]);
            }
            if (!sortedDictionary.ContainsKey(key))
              sortedDictionary[key] = 1;
          }
          int[] array2 = new List<int>((IEnumerable<int>) sortedDictionary.Keys).ToArray();
          Array.Reverse((Array) array2);
          Stack<string> stringStack = new Stack<string>(array2.Length * 2 + 1);
          StringBuilder stringBuilder = new StringBuilder(text);
          int num3 = 0;
          foreach (int num4 in array2)
          {
            string str4 = stringBuilder.ToString(num4, stringBuilder.Length - num3 - num4);
            stringStack.Push(str4);
            stringStack.Push("\\cf" + (object) sortedDictionary[num4] + " ");
            num3 += str4.Length;
          }
          stringStack.Push(stringBuilder.ToString(0, stringBuilder.Length - num3));
          text = string.Join("", stringStack.ToArray());
          this.BeginInvoke((Delegate) (() =>
          {
            if (curHighlightCounter != this.highlightCounter)
              return;
            this.delayedEvent = true;
            this.disableScrollEvent = true;
            this.rtxMain.TextChangedSkip = true;
            this.rtxMain.SelectionChangedSkip = true;
            LinedRichTextBox.SendMessage(this.pnlLineNumber.Handle.ToInt32(), 11U, 0, 0);
            this.rtxMain.EnableRedrawLock(true);
            int selectionStart = this.rtxMain.SelectionStart;
            LinedRichTextBox.POINT lParam = new LinedRichTextBox.POINT();
            LinedRichTextBox.SendMessage(this.rtxMain.Handle.ToInt32(), 1245U, 0, ref lParam);
            this.rtxMain.Rtf = new StringBuilder(header.Length + text.Length).Append(header).Append(text).ToString();
            LinedRichTextBox.SendMessage(this.pnlLineNumber.Handle.ToInt32(), 11U, 1, 0);
            this.pnlLineNumber.Invalidate(true);
            this.rtxMain.EnableRedrawLock(false);
            this.rtxMain.SelectionStart = selectionStart;
            this.rtxMain.SetScrollPos(lParam.x, lParam.y);
            this.rtxMain.SelectionChangedSkip = false;
            this.rtxMain.TextChangedSkip = false;
            this.disableScrollEvent = false;
            this.delayedEvent = false;
            this.lastHighlightingThread = (Thread) null;
          }));
        }
        catch (ThreadAbortException ex)
        {
        }
      }));
      if (this.lastHighlightingThread != null)
        this.lastHighlightingThread.Abort();
      this.lastHighlightingThread = thread;
      thread.IsBackground = true;
      thread.Start();
    }

    private void LinedRichTextBox_Load(object sender, EventArgs e)
    {
      this.updateTextHeight();
      string text = this.rtxMain.Text;
      this.Clear();
      this.rtxMain.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
      this.rtxMain.MouseWheel += new MouseEventHandler(this.rtxMain_MouseWheel);
      this.rtxMain.Vsc = this.vscMain;
      this.rtxMain.ScrollToCaretDelg = (MethodInvoker) (() =>
      {
        int num = this.rtxMain.GetLineFromCharIndex(this.rtxMain.SelectionStart) + 1;
        if (num >= this.firstVisibleLine && this.firstVisibleLine + this.visibleLineCount - 1 >= num)
          return;
        this.rtxMain.ScrollToCaret();
      });
      typeof (Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty).SetValue((object) this.pnlLineNumber, (object) true, (object[]) null);
      this.rtxMain.Text = text;
    }

    private void pnlLineNumber_Paint(object sender, PaintEventArgs e)
    {
      LinedRichTextBox.RECT lParam = new LinedRichTextBox.RECT();
      LinedRichTextBox.SendMessage(this.rtxMain.Handle.ToInt32(), 178U, 0, ref lParam);
      StringFormat format = new StringFormat();
      format.Alignment = StringAlignment.Far;
      format.LineAlignment = StringAlignment.Near;
      Graphics graphics = e.Graphics;
      TextRenderingHint textRenderingHint = graphics.TextRenderingHint;
      SmoothingMode smoothingMode = graphics.SmoothingMode;
      graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      for (int firstVisibleLine = this.firstVisibleLine; firstVisibleLine <= Math.Min(this.firstVisibleLine + this.visibleLineCount, this.lineCount); ++firstVisibleLine)
      {
        string str = firstVisibleLine.ToString();
        Size size = TextRenderer.MeasureText(str, this.rtxMain.Font);
        int y = (firstVisibleLine - this.firstVisibleLine) * size.Height + 3;
        if (y + size.Height - 3 <= lParam.top + lParam.bottom)
        {
          int num = (int) ((double) size.Height * 0.7);
          if (this.bpLineDic.ContainsKey(firstVisibleLine))
          {
            Rectangle rect = new Rectangle(2, y + (int) ((double) ((size.Height - num) / 2) * 0.7), num, num);
            using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.MistyRose, Color.Red, 45f))
              graphics.FillEllipse((Brush) linearGradientBrush, rect);
            graphics.DrawEllipse(Pens.Black, rect);
          }
          if (firstVisibleLine == this.breakLine)
          {
            int x1 = (int) ((double) num * 0.1);
            float width = (float) ((double) size.Height / 2.0 * 0.40000000596046448);
            using (Pen pen = new Pen(this.bpLineDic.ContainsKey(firstVisibleLine) ? Color.Yellow : Color.FromArgb(220, 170, 0), width))
            {
              using (CustomLineCap customLineCap = (CustomLineCap) new AdjustableArrowCap((float) ((double) size.Height / 60.0 + 2.0999999046325684), (float) ((double) width / 60.0 + 1.7999999523162842), true))
              {
                pen.CustomEndCap = customLineCap;
                graphics.DrawLine(pen, (float) x1, (float) (y + size.Height / 2) - width / 3f, (float) (num - x1 + 2), (float) (y + size.Height / 2) - width / 3f);
              }
            }
          }
          Rectangle layoutRectangle = new Rectangle(this.pnlLineNumber.Width - size.Width - 2, y, size.Width, size.Height);
          graphics.DrawString(str, this.rtxMain.Font, Brushes.Black, (RectangleF) layoutRectangle, format);
        }
        else
          break;
      }
      graphics.SmoothingMode = smoothingMode;
      graphics.TextRenderingHint = textRenderingHint;
    }

    private void vscMain_Scroll(object sender, ScrollEventArgs e)
    {
      int lParam = 0;
      int num = 1 + this.vscMain.Maximum - this.vscMain.LargeChange;
      switch (e.Type)
      {
        case ScrollEventType.SmallDecrement:
          if (e.OldValue > this.vscMain.Minimum)
          {
            lParam = -1;
            break;
          }
          break;
        case ScrollEventType.SmallIncrement:
          if (e.OldValue < num)
          {
            lParam = 1;
            break;
          }
          break;
        case ScrollEventType.LargeDecrement:
          lParam = e.OldValue >= this.vscMain.LargeChange ? -this.vscMain.LargeChange : e.OldValue - this.vscMain.LargeChange;
          break;
        case ScrollEventType.LargeIncrement:
          lParam = num - e.OldValue >= this.vscMain.LargeChange ? this.vscMain.LargeChange : num - e.OldValue;
          break;
        case ScrollEventType.ThumbTrack:
          lParam = e.NewValue - e.OldValue;
          break;
        case ScrollEventType.First:
          lParam = -e.OldValue;
          break;
        case ScrollEventType.Last:
          lParam = num - e.OldValue;
          break;
      }
      if (lParam == 0)
        return;
      LinedRichTextBox.SendMessage(this.rtxMain.Handle.ToInt32(), 182U, 0, lParam);
    }

    private void vscMain_ValueChanged(object sender, EventArgs e)
    {
    }

    private void rtxMain_FontChanged(object sender, EventArgs e)
    {
      this.updateTextHeight();
      this.updateLineNumberPanelWidth();
      int visibleLineCount = this.visibleLineCount;
      this.updateVisibleLineCount();
      if (this.visibleLineCount > visibleLineCount)
        this.FirstVisibleLine = Math.Max(1, this.firstVisibleLine - (this.visibleLineCount - visibleLineCount) / 2);
      else if (this.visibleLineCount < visibleLineCount)
        this.FirstVisibleLine = Math.Min(this.lineCount, this.firstVisibleLine + (visibleLineCount - this.visibleLineCount) / 2);
      this.pnlLineNumber.Invalidate();
    }

    private void rtxMain_TextChanged(object sender, EventArgs e)
    {
      if (this.rtxMain.RegisterReraiseEvent(MethodBase.GetCurrentMethod(), (MethodInvoker) (() => this.rtxMain_TextChanged(sender, e))) || this.rtxMain.EventSkip)
        return;
      this.rtxMain.PrevText = this.rtxMain.Text;
      this.rtxMain.PrevSelectedText = this.rtxMain.SelectedText;
      this.updateLineCount();
      this.updateFirstVisibleLine();
      this.UpdateKeywordHighlight();
    }

    private void rtxMain_SelectionChanged(object sender, EventArgs e)
    {
      if (this.rtxMain.SelectionChangedSkip)
        return;
      if (this.rtxMain.Text == "a")
        0.ToString();
      this.rtxMain.UpdateDelayedSelectionParams();
      this.rtxMain.DelayedUpdatingPrevInfo();
      if (!this.LstIntellisense.Visible || this.rtxMain.SelectionStart >= this.interpolationTargetIndex)
        return;
      this.CloseIntelliSense(false);
    }

    private void rtxMain_VScroll(object sender, EventArgs e)
    {
      if (this.disableScrollEvent)
        return;
      ReentryBlock.Work((MethodInvoker) (() =>
      {
        this.updateFirstVisibleLine();
        this.pnlLineNumber.Invalidate();
      }), (object) MethodBase.GetCurrentMethod());
    }

    private void rtxMain_Resize(object sender, EventArgs e)
    {
      ReentryBlock.Work((MethodInvoker) (() =>
      {
        this.updateTextBoxHeight();
        this.updateVisibleLineCount();
        this.updateFirstVisibleLine();
        this.pnlLineNumber.Invalidate();
        this.rtxMain.Invalidate();
      }), (object) MethodBase.GetCurrentMethod());
    }

    private void rtxMain_KeyDown(object sender, KeyEventArgs e)
    {
      int wParam = 0;
      int lParam = 0;
      int num1 = 0;
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      int index = this.rtxMain.SelectionStart + (this.isBackSelect() ? 0 : this.rtxMain.PrevSelectedText.Length);
      if (e.Control)
      {
        switch (e.KeyCode)
        {
          case Keys.E:
            e.Handled = true;
            break;
          case Keys.V:
            flag1 = true;
            break;
          case Keys.X:
            this.rtxMain.SelectionChangedSkip = true;
            break;
          case Keys.Y:
            if (!this.rtxMain.ReadOnly)
              this.rtxMain.Redo();
            e.Handled = true;
            this.CloseIntelliSense(true);
            break;
          case Keys.Z:
            if (!this.rtxMain.ReadOnly)
              this.rtxMain.Undo();
            e.Handled = true;
            this.CloseIntelliSense(false);
            break;
        }
      }
      switch (e.KeyCode)
      {
        case Keys.Back:
          if (!this.rtxMain.ReadOnly)
            this.rtxMain.MakePreUE(e.KeyCode);
          this.updateIntelliSense('\b');
          break;
        case Keys.Tab:
          if (this.LstIntellisense.Visible)
          {
            e.Handled = true;
            this.CloseIntelliSense(!e.Shift);
            break;
          }
          break;
        case Keys.Return:
          if (this.LstIntellisense.Visible)
          {
            e.Handled = true;
            this.CloseIntelliSense(true);
            break;
          }
          break;
        case Keys.Escape:
        case Keys.ProcessKey:
          flag3 = true;
          break;
        case Keys.Prior:
          num1 = -1;
          flag3 = true;
          break;
        case Keys.Next:
          num1 = 1;
          flag3 = true;
          break;
        case Keys.End:
          flag3 = true;
          if (index == this.rtxMain.PrevText.Length || !e.Control && this.rtxMain.PrevText[index] == '\n')
          {
            flag2 = true;
            break;
          }
          break;
        case Keys.Home:
          flag3 = true;
          if (index == 0 || !e.Control && this.rtxMain.PrevText[index - 1] == '\n')
          {
            flag2 = true;
            break;
          }
          break;
        case Keys.Left:
          wParam = -1;
          flag3 = true;
          break;
        case Keys.Up:
          if (this.LstIntellisense.Visible)
          {
            e.Handled = true;
            this.moveIntellisense(false);
            break;
          }
          lParam = -1;
          break;
        case Keys.Right:
          wParam = 1;
          flag3 = true;
          break;
        case Keys.Down:
          if (this.LstIntellisense.Visible)
          {
            e.Handled = true;
            this.moveIntellisense(true);
            break;
          }
          lParam = 1;
          break;
        case Keys.Insert:
          flag1 = e.Shift;
          break;
      }
      if (num1 != 0)
      {
        if (e.Shift)
        {
          this.pnlLineNumber.Invalidate();
          if (num1 == -1 && index == 0)
            e.Handled = true;
          else if (num1 == 1 && !this.isBackSelect() && this.rtxMain.SelectionStart + this.rtxMain.SelectionLength == this.rtxMain.PrevText.Length)
          {
            e.Handled = true;
          }
          else
          {
            int num2 = index - this.rtxMain.GetFirstCharIndexFromLine(this.rtxMain.GetLineFromCharIndex(index));
            int lineFromCharIndex = this.rtxMain.GetLineFromCharIndex(index);
            int lineNumber = Math.Max(Math.Min(lineFromCharIndex + this.visibleLineCount * num1 + 1, this.lineCount), 1) - 1;
            int num3 = Math.Max(Math.Min(this.rtxMain.GetFirstCharIndexFromLine(lineNumber) + (lineNumber == lineFromCharIndex + this.visibleLineCount * num1 ? num2 : this.rtxMain.PrevText.Length * num1), this.rtxMain.PrevText.Length), 0);
            int start = index == this.rtxMain.SelectionStart ? index + this.rtxMain.SelectionLength : this.rtxMain.SelectionStart;
            this.rtxMain.Select(start, num3 - start);
            e.Handled = true;
          }
        }
        else if (num1 == -1 && this.rtxMain.SelectionStart == 0 || num1 == 1 && (this.rtxMain.SelectionStart == this.rtxMain.PrevText.Length || e.Control && this.rtxMain.PrevText.Substring(this.rtxMain.SelectionStart).Trim() == ""))
          flag2 = true;
      }
      if (wParam != 0 || lParam != 0)
      {
        if (e.Control)
        {
          LinedRichTextBox.SendMessage(this.rtxMain.Handle.ToInt32(), 182U, wParam, lParam);
          e.Handled = true;
        }
        else if (e.Shift)
        {
          if (wParam + lParam == -1 && index == 0 || wParam + lParam == 1 && !this.isBackSelect() && this.rtxMain.SelectionStart + this.rtxMain.SelectionLength == this.rtxMain.PrevText.Length)
            e.Handled = true;
        }
        else if (wParam == -1 && this.rtxMain.SelectionStart == 0 || lParam == -1 && this.rtxMain.GetLineFromCharIndex(this.rtxMain.SelectionStart) == 0 || wParam == 1 && this.rtxMain.SelectionStart == this.rtxMain.PrevText.Length || lParam == 1 && this.rtxMain.GetLineFromCharIndex(this.rtxMain.SelectionStart) == this.lineCount - 1)
          flag2 = true;
      }
      if (flag1 && !this.rtxMain.ReadOnly)
      {
        flag3 = true;
        this.rtxMain.Paste();
        e.Handled = true;
      }
      if (flag2)
      {
        flag3 = true;
        this.rtxMain.SelectionLength = 0;
        e.Handled = true;
      }
      if (!flag3)
        return;
      this.CloseIntelliSense(false);
    }

    private void rtxMain_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Tab:
          e.IsInputKey = this.LstIntellisense.Visible && !e.Control;
          if (e.Control && this.MoveNextTab != null)
          {
            this.MoveNextTab(!e.Shift);
            break;
          }
          break;
        case Keys.Insert:
          e.IsInputKey = false;
          break;
        case Keys.Delete:
          if (!this.rtxMain.ReadOnly)
            this.rtxMain.MakePreUE(e.KeyCode);
          e.IsInputKey = false;
          break;
        default:
          e.IsInputKey = true;
          break;
      }
      if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9)
        e.IsInputKey = false;
      if (!e.IsInputKey || e.Control && e.KeyValue != 17 && e.KeyCode != Keys.Space)
        this.CloseIntelliSense(false);
      if (!e.Control && !e.Alt)
        return;
      e.IsInputKey = false;
    }

    private void rtxMain_KeyPress(object sender, KeyPressEventArgs e)
    {
      switch (e.KeyChar)
      {
        case '\b':
          this.BeginInvoke((Delegate) (() => this.rtxMain.UpdateDelayedSelectionParams()));
          return;
        case '\t':
          e.Handled = true;
          return;
        case ' ':
          if (Control.ModifierKeys == Keys.Control)
          {
            e.Handled = true;
            this.openIntelliSense();
            return;
          }
          break;
      }
      if (!this.LstIntellisense.Visible || Control.ModifierKeys == Keys.Control)
        return;
      if ('a' <= e.KeyChar && e.KeyChar <= 'z' || 'A' <= e.KeyChar && e.KeyChar <= 'Z' || '0' <= e.KeyChar && e.KeyChar <= '9' || e.KeyChar == '_')
      {
        this.updateIntelliSense(e.KeyChar);
      }
      else
      {
        e.Handled = true;
        this.CloseIntelliSense(true, e.KeyChar);
      }
    }

    private void updateIntelliSense(char inputChar)
    {
      if (!this.LstIntellisense.Visible || this.rtxMain.TextChangedSkip)
        return;
      if (inputChar == '\b')
      {
        if (this.rtxMain.SelectionStart == this.interpolationTargetIndex)
        {
          this.CloseIntelliSense(false);
          return;
        }
        this.interpolationTarget = this.interpolationTarget.Remove(this.interpolationTarget.Length - 1);
      }
      else
      {
        if (this.rtxMain.SelectionLength != 0)
          this.interpolationTarget = "";
        this.interpolationTarget += inputChar.ToString().ToLower();
      }
      this.updateIntelliSense();
    }

    private void updateIntelliSense()
    {
      this.LstIntellisense.Items.Clear();
      foreach (string key in BatKeyword.Dic.Keys)
      {
        if (key.Contains(this.interpolationTarget) && !this.LstIntellisense.Items.Contains((object) key))
          this.LstIntellisense.Items.Add((object) key);
      }
      if (this.LstIntellisense.Items.Count <= 0)
        return;
      foreach (string key in BatKeyword.Dic.Keys)
      {
        if (key.StartsWith(this.interpolationTarget))
        {
          this.LstIntellisense.SelectedItem = (object) key;
          break;
        }
      }
    }

    private void updateInterpolationTarget()
    {
      this.interpolationTargetIndex = this.rtxMain.SelectionStart;
      if (this.rtxMain.SelectionLength > 0)
      {
        this.interpolationTarget = this.rtxMain.SelectedText;
      }
      else
      {
        this.interpolationTarget = "";
        int indexOfCurrentLine = this.rtxMain.GetFirstCharIndexOfCurrentLine();
        Match match1 = Regex.Match(this.rtxMain.Text.Substring(indexOfCurrentLine, this.rtxMain.SelectionStart - indexOfCurrentLine), "([a-zA-Z0-9_]+)$");
        Match match2 = Regex.Match(this.rtxMain.Text.Substring(this.rtxMain.SelectionStart), "^([a-zA-Z0-9_]+)");
        if (match1.Success)
        {
          this.interpolationTargetIndex = indexOfCurrentLine + match1.Index;
          this.interpolationTarget = match1.Value;
        }
        if (match2.Success)
          this.interpolationTarget += match2.Value;
      }
      this.interpolationTarget = this.interpolationTarget.ToLower();
    }

    private void openIntelliSense()
    {
      if (this.rtxMain.ReadOnly || this.LstIntellisense.Visible)
        return;
      this.updateInterpolationTarget();
      Point client = this.LstIntellisense.Parent.PointToClient(this.rtxMain.PointToScreen(this.rtxMain.GetPositionFromCharIndex(this.rtxMain.SelectionStart)));
      client.Y += this.textHeight + 3;
      ++client.X;
      this.LstIntellisense.Location = client;
      this.LstIntellisense.Visible = true;
      this.updateIntelliSense();
    }

    public void CloseIntelliSense(bool decided) => this.CloseIntelliSense(decided, char.MinValue);

    public void CloseIntelliSense(bool decided, char inputChar)
    {
      if (!this.LstIntellisense.Visible)
        return;
      this.LstIntellisense.Visible = false;
      if (!decided || this.LstIntellisense.SelectedItem == null)
        return;
      string selectedItem = (string) this.LstIntellisense.SelectedItem;
      this.DecidedIntellisenseDelg(selectedItem);
      if (this.rtxMain.Text.Substring(this.interpolationTargetIndex, this.interpolationTarget.Length) == selectedItem)
        return;
      if (this.interpolationTarget.Length != 0)
        this.rtxMain.Select(this.interpolationTargetIndex, this.interpolationTarget.Length);
      if (inputChar != char.MinValue)
        this.rtxMain.ChangeSelectedText(selectedItem + (object) inputChar);
      else
        this.rtxMain.ChangeSelectedText(selectedItem);
      this.rtxMain.UpdateDelayedSelectionParams();
    }

    private void moveIntellisense(bool isDown)
    {
      if (!this.LstIntellisense.Visible || this.LstIntellisense.Items.Count == 0)
        return;
      this.LstIntellisense.SelectedIndex = Math.Min(this.LstIntellisense.Items.Count - 1, Math.Max(0, this.LstIntellisense.SelectedIndex + (isDown ? 1 : -1)));
    }

    private void rtxMain_MouseWheel(object sender, MouseEventArgs e)
    {
      int lParam1 = 0;
      int num1 = 1 + this.vscMain.Maximum - this.vscMain.LargeChange;
      int num2 = -e.Delta * SystemInformation.MouseWheelScrollLines / 120;
      if (num2 < 0)
      {
        lParam1 = this.vscMain.Value >= -num2 ? num2 : this.vscMain.Value + num2;
      }
      else
      {
        LinedRichTextBox.POINT lParam2 = new LinedRichTextBox.POINT();
        LinedRichTextBox.SendMessage(this.rtxMain.Handle.ToInt32(), 1245U, 0, ref lParam2);
        if (lParam2.y <= this.textHeight * (this.lineCount - this.visibleLineCount))
          lParam1 = num1 - this.vscMain.Value >= num2 ? num2 : num1 - this.vscMain.Value;
      }
      if (lParam1 == 0)
        return;
      LinedRichTextBox.SendMessage(this.rtxMain.Handle.ToInt32(), 182U, 0, lParam1);
    }

    private void toggleBreakPoint()
    {
      if (this.ToggledBreakPointDelg == null)
        return;
      int y = this.pnlLineNumber.PointToClient(Cursor.Position).Y;
      if (y < 3)
        return;
      int num = y / TextRenderer.MeasureText(" ", this.rtxMain.Font).Height + this.firstVisibleLine;
      if (num > this.firstVisibleLine + this.visibleLineCount - 1 || num > this.lineCount)
        return;
      this.ToggledBreakPointDelg(num);
      this.pnlLineNumber.Invalidate();
    }

    private void pnlLineNumber_Click(object sender, EventArgs e) => this.toggleBreakPoint();

    private void pnlLineNumber_DoubleClick(object sender, EventArgs e) => this.toggleBreakPoint();

    public void SetBPLineDic(Dictionary<int, bool> newBPLineDic) => this.bpLineDic = newBPLineDic;

    public void Break(int line)
    {
      this.breakLine = line;
      this.rtxMain.SelectionLength = 0;
      this.rtxMain.SelectionStart = this.rtxMain.GetFirstCharIndexFromLine(this.breakLine - 1);
      if (this.breakLine < this.firstVisibleLine || this.firstVisibleLine + this.visibleLineCount - 1 < this.breakLine)
        this.rtxMain.ScrollToCaret();
      if (this.firstVisibleLine + this.visibleLineCount - 1 < this.breakLine + 5)
        LinedRichTextBox.SendMessage(this.rtxMain.Handle.ToInt32(), 182U, 0, this.breakLine + 5 - (this.firstVisibleLine + this.visibleLineCount - 1));
      this.pnlLineNumber.Invalidate();
    }

    public void Unbreak()
    {
      this.breakLine = 0;
      this.pnlLineNumber.Invalidate();
    }

    public void Clear()
    {
      this.rtxMain.Clear();
      this.updateLineCount();
      this.updateVisibleLineCount();
      this.updateFirstVisibleLine();
    }

    private void rtxMain_Leave(object sender, EventArgs e)
    {
      this.BeginInvoke((Delegate) (() => this.CloseIntelliSense(false)));
    }

    private void rtxMain_Click(object sender, EventArgs e) => this.CloseIntelliSense(false);

    private struct POINT
    {
      public int x;
      public int y;
    }

    private struct RECT
    {
      public int left;
      public int top;
      public int right;
      public int bottom;
    }
  }
}

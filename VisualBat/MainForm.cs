/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using IpcLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using VisualBat.Properties;

#nullable disable
namespace VisualBat
{
  public class MainForm : Form
  {
    private readonly string baseTitle;
    private IpcServer ipcServer;
    private int traceInfoIndex;
    private int srcMaxDigit;
    private bool quitFlag;
    private List<object[]> lastTraceInfoList;
    private List<string> traceTextList;
    private Dictionary<int, int> visibleTraceTextIndexDic;
    private Dictionary<int, string> runCommandDic;
    private Dictionary<int, string[]> expandedTraceTextDic;
    private string lastSrc;
    private List<Dictionary<string, object>> editorParamListWithClosing;
    private string editFilePathWithClosing;
    private bool lastDumpForVar;
    private bool lastDumpArg;
    private string cmdextversion;
    private string highestnumanodenumber;
    private IContainer components;
    private SplitContainer sptMainVertical;
    private SplitContainer sptDebugHorizontal;
    private StatusStrip stsMain;
    private MenuStrip mnuMain;
    private ToolStripMenuItem mniFile;
    private ToolStripMenuItem mniFileExit;
    private Panel pnlRight;
    private ToolStripMenuItem mniExecute;
    private ToolStripMenuItem mniExeRun;
    private ToolStripMenuItem mniExeRunWD;
    private ToolStripMenuItem mniFileNew;
    private ToolStripMenuItem mniFileOpen;
    private ToolStripMenuItem mniFileSave;
    private ToolStripMenuItem mniFileSaveWithName;
    private ToolStripMenuItem mniSetting;
    private ToolStripMenuItem mniDebug;
    private ToolStripMenuItem mniDebugContinue;
    private ToolStripMenuItem mniDebugStep;
    private ToolStripMenuItem mniExeStop;
    private ToolStripSeparator tsmDebugSeparate;
    private ToolStripMenuItem mniDebugClearBP;
    private OpenFileDialog ofdEdit;
    private SaveFileDialog sfdEdit;
    private DataGridView dgvVarList;
    private ToolStripMenuItem mniEdit;
    private ToolStripMenuItem mniEditUndo;
    private ToolStripMenuItem mniEditRedo;
    private ToolStripSeparator tsmEditSeparate;
    private ToolStripMenuItem mniEditCut;
    private ToolStripMenuItem mniEditCopy;
    private ToolStripMenuItem mniEditPaste;
    private ToolStripMenuItem mniEditDel;
    private ToolStripMenuItem mniSearch;
    private ToolStripMenuItem mniSearchFind;
    private ToolStripMenuItem mniSearchReplace;
    private System.Windows.Forms.Timer timWatchBreak;
    private GroupBox grpRunningCondition;
    private TextBox txtArguments;
    private Label lblArguments;
    private TextBox txtWorkDir;
    private Label lblWorkDir;
    private GroupBox grpTraceSetting;
    private CheckBox chkShowErrorLevel;
    private CheckBox chkShowTime;
    private ToolStripMenuItem mniDebugToggleBP;
    private ToolStripMenuItem mniDebugPause;
    private ToolStripStatusLabel tslRunningState;
    private ToolStripStatusLabel tslBreakState;
    private ToolStripMenuItem mniBuild;
    private ToolStripMenuItem mniBuildToExe;
    private ToolStripMenuItem mniBuildToExeNoConsole;
    private SaveFileDialog sfdBuild;
    private SplitContainer sptEditHorizontal;
    private SplitContainer sptIdiomVertical;
    private ListBox lstIdiomIndex;
    private TextBox txtIdiomText;
    private Button btnAddIdiom;
    private ToolStripMenuItem mniView;
    private ToolStripMenuItem mniViewCommandReference;
    private Button btnModifyIdiom;
    private TableLayoutPanel tlpIdiomControl;
    private ToolStripMenuItem mniViewIdiom;
    private ContextMenuStrip cmsEdit;
    private ToolStripMenuItem mniCtxEditUndo;
    private ToolStripMenuItem mniCtxEditRedo;
    private ToolStripSeparator tsmCtxEditSeparator1;
    private ToolStripMenuItem mniCtxEditCut;
    private ToolStripMenuItem mniCtxEditCopy;
    private ToolStripMenuItem mniCtxEditPaste;
    private ToolStripMenuItem mniCtxEditDelete;
    private ToolStripSeparator tsmCtxEditSeparator2;
    private ToolStripMenuItem mniCtxEditAddIdiom;
    private ToolStripSeparator toolStripMenuItem1;
    private ToolStripMenuItem mniEditAddIdiom;
    private ToolTip tipIdiomName;
    private ContextMenuStrip cmsIdiomIndex;
    private ToolStripMenuItem mniCtxIdiomIndexInsert;
    private ToolStripMenuItem mniCtxIdiomIndexModify;
    private ToolStripMenuItem mniCtxIdiomIndexDelete;
    private ToolStripMenuItem mniHelp;
    private ToolStripMenuItem mniHelpVersion;
    private ToolStripMenuItem mniSettingOption;
    private SplitContainer sptRoot;
    private ToolStrip tstToolBox;
    private ToolStripButton tsbToolBoxNew;
    private ToolStripButton tsbToolBoxOpen;
    private ToolStripButton tsbToolBoxSave;
    private ToolStripButton tsbToolBoxSaveNamed;
    private ToolStripSeparator tssToolBoxSeparator1;
    private ToolStripButton tsbToolBoxRun;
    private ToolStripButton tsbToolBoxPause;
    private ToolStripButton tsbToolBoxStop;
    private ToolStripButton tsbToolBoxUndo;
    private ToolStripButton tsbToolBoxRedo;
    private ToolStripSeparator tssToolBoxSeparator2;
    private ToolStripSeparator tssToolBoxSeparator3;
    private ToolStripButton tsbToolBoxContinue;
    private ToolStripButton tsbToolBoxStep;
    private ToolStripMenuItem mniViewToolBox;
    private ToolStripSeparator tssToolBoxSeparator4;
    private ToolStripButton tsbToolBoxBuild;
    private ToolStripButton tsbToolBoxBuildNoConsole;
    private ToolStripSeparator tssToolBoxSeparator5;
    private ToolStripButton tsbToolBoxOption;
    private ToolStripMenuItem mniDebugInterruptCmd;
    private ToolStripSeparator toolStripMenuItem2;
    private DraggableTabControl dtcEdit;
    private Panel pnlEditLeft;
    private Panel pnlEdit;
    private DataGridViewTextBoxColumn ColumnName;
    private DataGridViewTextBoxColumn ColumnValue;
    private ContextMenuStrip cmsEditTab;
    private ToolStripMenuItem mniCtxEditTabClose;
    private ToolStripMenuItem mniEditCloseTab;
    private ToolStripSeparator toolStripMenuItem3;
    private ToolStripSeparator toolStripMenuItem4;
    private ToolStripSeparator toolStripMenuItem5;
    private ToolStripMenuItem mniFileOpenDirOnEditFile;
    private ToolStripMenuItem mniFileOpenWorkDir;
    private ToolStripSeparator toolStripMenuItem6;
    private ToolStripSeparator toolStripMenuItem7;
    private ToolStripMenuItem mniFileReload;
    private ToolStripMenuItem mniViewTopMost;
    private ToolStripStatusLabel tslTopMost;
    private ListBox lstInfo;
    private CheckBox chkExpandVar;
    private Label lblFilter;
    private TextBox txtFilter;
    private ListBox lstIntellisense;

    private string EditFileName
    {
      get => !(this.EditFilePath == "") ? Path.GetFileName(this.EditFilePath) : "(無題)";
    }

    private string EditTabTitleName => this.EditFileName + (this.TextUpdated ? "*" : "");

    private string EditWindowTitleName
    {
      get
      {
        return (this.EditFilePath == "" ? this.EditFileName : (Setting.ShowFullPath ? this.EditFilePath : this.EditFileName)) + (this.TextUpdated ? "*" : "");
      }
    }

    public TabPage CurrentTab
    {
      get => this.dtcEdit.SelectedTab;
      set => this.dtcEdit.SelectedTab = value;
    }

    public TabPage RunningTab
    {
      get => (TabPage) ((Dictionary<string, object>) this.dtcEdit.Tag)[nameof (RunningTab)];
      set => ((Dictionary<string, object>) this.dtcEdit.Tag)[nameof (RunningTab)] = (object) value;
    }

    public TabPage LastTab
    {
      get => (TabPage) ((Dictionary<string, object>) this.dtcEdit.Tag)[nameof (LastTab)];
      set => ((Dictionary<string, object>) this.dtcEdit.Tag)[nameof (LastTab)] = (object) value;
    }

    public List<LinedRichTextBox> AllEditors
    {
      get
      {
        List<LinedRichTextBox> allEditors = new List<LinedRichTextBox>();
        foreach (TabPage tabPage in this.dtcEdit.TabPages)
          allEditors.Add((LinedRichTextBox) ((Dictionary<string, object>) tabPage.Tag)["Editor"]);
        return allEditors;
      }
    }

    public LinedRichTextBox Editor
    {
      get => (LinedRichTextBox) ((Dictionary<string, object>) this.CurrentTab.Tag)[nameof (Editor)];
    }

    public LinedRichTextBox RunningEditor
    {
      get => (LinedRichTextBox) ((Dictionary<string, object>) this.RunningTab.Tag)["Editor"];
    }

    public LinedRichTextBox LastEditor
    {
      get => (LinedRichTextBox) ((Dictionary<string, object>) this.LastTab.Tag)["Editor"];
    }

    public BatDebugger Debugger
    {
      get => (BatDebugger) ((Dictionary<string, object>) this.CurrentTab.Tag)[nameof (Debugger)];
    }

    public BatDebugger RunningDebugger
    {
      get => (BatDebugger) ((Dictionary<string, object>) this.RunningTab.Tag)["Debugger"];
    }

    private bool TextUpdated => this.TextEditState != this.Editor.TextBox.TextEditState;

    private object TextEditState
    {
      get => ((Dictionary<string, object>) this.Editor.Tag)[nameof (TextEditState)];
      set => ((Dictionary<string, object>) this.Editor.Tag)[nameof (TextEditState)] = value;
    }

    private string EditFilePath
    {
      get => (string) ((Dictionary<string, object>) this.Editor.Tag)[nameof (EditFilePath)];
      set
      {
        ((Dictionary<string, object>) this.Editor.Tag)[nameof (EditFilePath)] = (object) value;
        this.UpdateTitle();
      }
    }

    public bool Breaking { get; set; }

    public MainForm()
    {
      this.InitializeComponent();
      this.baseTitle = this.Text + " ver " + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      this.ipcServer = new IpcServer(BatDebugger.BreakPointId);
      this.dtcEdit.Tag = (object) new Dictionary<string, object>();
      Setting.Load();
      this.mniFileNew_Click((object) null, (EventArgs) null);
      this.LastTab = (TabPage) null;
      this.RunningTab = (TabPage) null;
      if (Program.Args.Length > 0)
      {
        foreach (string str in Program.Args)
        {
          if (File.Exists(str))
            this.openFile(str);
        }
      }
      else if (Setting.RememberTab)
      {
        foreach (string lastFilePath in Setting.LastFilePathList)
        {
          if (File.Exists(lastFilePath))
            this.openFile(lastFilePath);
        }
        foreach (TabPage tabPage in this.dtcEdit.TabPages)
        {
          if ((string) ((Dictionary<string, object>) ((Control) ((Dictionary<string, object>) tabPage.Tag)["Editor"]).Tag)["EditFilePath"] == Setting.LastFilePath)
          {
            this.CurrentTab = tabPage;
            break;
          }
        }
      }
      this.ActiveControl = (Control) this.Editor.TextBox;
      this.dtcEdit_SelectedIndexChanged((object) null, (EventArgs) null);
      this.UpdateTitle();
      this.lstIdiomIndex.ContextMenuStrip = this.cmsIdiomIndex;
      BatDebugger.RunningCompleted += (EventHandler) ((se, ev) => this.changeRunningState(false));
      this.changeRunningState(false);
      this.updateIdiom();
      if (Setting.RememberLayout && Setting.LastWidth > 0)
      {
        if (Setting.WasMaximum)
        {
          this.WindowState = FormWindowState.Maximized;
        }
        else
        {
          this.SetDesktopLocation(Setting.LastX, Setting.LastY);
          this.Width = Setting.LastWidth;
          this.Height = Setting.LastHeight;
        }
        this.mniViewToolBox.Checked = Setting.ShownToolBox;
        this.mniViewToolBox_Click((object) null, (EventArgs) null);
        this.mniViewIdiom.Checked = Setting.ShownIdiom;
        this.mniViewIdiom_Click((object) null, (EventArgs) null);
        if (Setting.ShownCommandReference)
          this.mniViewCommandReference_Click((object) null, (EventArgs) null);
        this.sptMainVertical.SplitterDistance = Setting.MainVertical;
        this.sptEditHorizontal.SplitterDistance = Setting.EditHorizontal;
        this.sptIdiomVertical.SplitterDistance = Setting.IdiomVertical;
        this.sptDebugHorizontal.SplitterDistance = Setting.DebugHorizontal;
        this.dgvVarList.Columns["ColumnName"].Width = Setting.DumpVarGridNameWidth;
      }
      this.chkShowTime.Checked = Setting.ShowTime;
      this.chkShowErrorLevel.Checked = Setting.ShowErrorLevel;
      this.chkExpandVar.Checked = Setting.ExpandVar;
      this.txtWorkDir.Text = Setting.WorkDirectory;
      this.mniFile_DropDownOpening((object) null, (EventArgs) null);
      this.mniEdit_DropDownOpening((object) null, (EventArgs) null);
      this.mniView_DropDownOpening((object) null, (EventArgs) null);
      this.mniSearch_DropDownOpening((object) null, (EventArgs) null);
      this.mniExecute_DropDownOpening((object) null, (EventArgs) null);
      this.mniDebug_DropDownOpening((object) null, (EventArgs) null);
      this.mniBuild_DropDownOpening((object) null, (EventArgs) null);
      this.mniSetting_DropDownOpening((object) null, (EventArgs) null);
      this.mniHelp_DropDownOpening((object) null, (EventArgs) null);
      this.updateTextControlColor();
      this.cmdextversion = BatDebugger.GetCommandOutput("echo;%cmdextversion%");
      this.highestnumanodenumber = BatDebugger.GetCommandOutput("echo;%highestnumanodenumber%");
    }

    public void UpdateTitle()
    {
      this.Text = this.baseTitle + " - " + this.EditWindowTitleName;
      this.CurrentTab.Text = this.EditTabTitleName;
    }

    private void updateIdiom()
    {
      this.lstIdiomIndex.Items.Clear();
      this.txtIdiomText.Text = "";
      foreach (object idiom in Setting.IdiomList)
        this.lstIdiomIndex.Items.Add(idiom);
      this.btnModifyIdiom.Enabled = false;
    }

    private List<Control> getAllChildControls(Control parent)
    {
      List<Control> allChildControls = new List<Control>();
      foreach (Control control in (ArrangedElementCollection) parent.Controls)
      {
        allChildControls.Add(control);
        allChildControls.AddRange((IEnumerable<Control>) this.getAllChildControls(control));
      }
      return allChildControls;
    }

    private void changeRunningState(bool runningState)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) (() => this.changeRunningState(runningState)));
      }
      else
      {
        foreach (LinedRichTextBox allEditor in this.AllEditors)
          allEditor.TextBox.ReadOnly = runningState;
        this.grpRunningCondition.Enabled = !runningState;
        if (ReplaceDialog.CurrentInstance != null)
          ReplaceDialog.CurrentInstance.Visible = !runningState;
        this.mniFileNew.Enabled = !runningState;
        this.mniFileReload.Enabled = !runningState;
        this.mniFileSave.Enabled = !runningState;
        this.mniFileSaveWithName.Enabled = !runningState;
        this.mniEdit.Enabled = !runningState;
        this.mniSearchReplace.Enabled = !runningState;
        this.mniExeRun.Enabled = !runningState;
        this.mniExeRunWD.Enabled = !runningState;
        this.mniExeStop.Enabled = runningState;
        this.mniDebugContinue.Enabled = runningState & BatDebugger.Debug;
        this.mniDebugPause.Enabled = runningState & BatDebugger.Debug;
        this.mniDebugStep.Enabled = runningState & BatDebugger.Debug;
        this.mniDebugInterruptCmd.Enabled = runningState & Setting.EnableInterruptCmd;
        this.mniBuild.Enabled = !runningState;
        this.mniSetting.Enabled = !runningState;
        this.tsbToolBoxNew.Enabled = !runningState;
        this.tsbToolBoxSave.Enabled = !runningState;
        this.tsbToolBoxSaveNamed.Enabled = !runningState;
        this.tsbToolBoxUndo.Enabled = !runningState & this.Editor.TextBox.CanUndo;
        this.tsbToolBoxRedo.Enabled = !runningState & this.Editor.TextBox.CanRedo;
        this.tsbToolBoxRun.Enabled = !runningState;
        this.tsbToolBoxPause.Enabled = runningState & BatDebugger.Debug;
        this.tsbToolBoxStop.Enabled = runningState;
        this.tsbToolBoxContinue.Enabled = runningState & BatDebugger.Debug;
        this.tsbToolBoxStep.Enabled = runningState & BatDebugger.Debug;
        this.tsbToolBoxBuild.Enabled = !runningState & this.Editor.Text.Length > 0;
        this.tsbToolBoxBuildNoConsole.Enabled = !runningState & this.Editor.Text.Length > 0;
        this.tsbToolBoxOption.Enabled = !runningState;
        this.ipcServer.RemoteObject.DebugCommand = DebugCommand.Continue;
        this.tslBreakState.Text = "";
        if (runningState)
        {
          this.tslRunningState.Text = "実行中";
          if (this.EditFilePath != "")
            this.saveFile();
          this.timWatchBreak.Start();
          this.ipcServer.RemoteObject.BPLineDic = this.Debugger.BPLineDic;
          this.ipcServer.RemoteObject.SystemVariableDic = (IDictionary) null;
          this.ipcServer.RemoteObject.BatVariableDic = (IDictionary) null;
          this.ipcServer.RemoteObject.TraceInfoList = new List<object[]>();
          this.ipcServer.RemoteObject.TraceInfoCount = 0;
          this.ipcServer.RemoteObject.TraceInfoCountReceived = true;
          this.srcMaxDigit = (int) Math.Floor(Math.Log10((double) this.Editor.LineCount)) + 1;
          this.RunningTab = this.CurrentTab;
          this.runCommandDic = new Dictionary<int, string>();
          this.expandedTraceTextDic = new Dictionary<int, string[]>();
          this.lastSrc = this.RunningEditor.Text;
          this.lastTraceInfoList = new List<object[]>();
          this.initTraceInfo();
          this.updateVarList();
          this.lastDumpForVar = Setting.DumpForVar;
          this.lastDumpArg = Setting.DumpArg;
        }
        else
        {
          this.tslRunningState.Text = "";
          if (this.RunningTab != null)
            this.RunningEditor.Unbreak();
          this.timWatchBreak.Stop();
          if (this.ipcServer.RemoteObject.TraceInfoList != null && !this.ipcServer.RemoteObject.ArrivedSrcEnd && !this.ipcServer.RemoteObject.Stopped && !BatDebugger.ErrorOccurred && BatDebugger.Debug)
            this.ipcServer.RemoteObject.TraceInfoList.Add(new object[4]
            {
              (object) this.ipcServer.RemoteObject.BreakLine,
              (object) BatDebugger.ExitCode,
              (object) BatDebugger.ExitTime,
              (object) Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process)
            });
          if (this.ipcServer.RemoteObject.TraceInfoList != null)
          {
            if (this.ipcServer.RemoteObject.TraceInfoCount != 0)
            {
              List<object[]> traceInfoList = this.ipcServer.RemoteObject.TraceInfoList;
              traceInfoList.RemoveRange(0, this.ipcServer.RemoteObject.TraceInfoCount);
              this.ipcServer.RemoteObject.TraceInfoList = traceInfoList;
              this.ipcServer.RemoteObject.TraceInfoCount = 0;
            }
            if (this.ipcServer.RemoteObject.TraceInfoList.Count > 0)
              this.lastTraceInfoList.AddRange((IEnumerable<object[]>) this.ipcServer.RemoteObject.TraceInfoList);
          }
          this.updateTraceInfo();
          if (this.RunningTab != null && RunCommandDialog.CurrentInstance != null)
            RunCommandDialog.CurrentInstance.Close();
          this.RunningTab = (TabPage) null;
          this.Breaking = false;
        }
      }
    }

    private int getFirstCharIndexFromLine(string src, int line)
    {
      int startIndex = 0;
      for (; line > 0; --line)
      {
        startIndex = src.IndexOf('\n', startIndex) + 1;
        if (startIndex == 0)
          return src.Length;
      }
      return startIndex;
    }

    private void updateTraceInfo()
    {
      if (this.lastTraceInfoList == null)
        return;
      int count = this.lastTraceInfoList.Count;
      if (this.traceInfoIndex >= count)
        return;
      List<string> stringList = new List<string>();
      for (int traceInfoIndex = this.traceInfoIndex; traceInfoIndex < count; ++traceInfoIndex)
      {
        object[] traceInfo = this.lastTraceInfoList[traceInfoIndex];
        if (traceInfo[0] is int && (int) traceInfo[0] == -2)
          traceInfo[0] = (object) RunCommandDialog.LastCommand;
        bool flag = traceInfo[0] is string;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(string.Format("{0,4}-", (object) (traceInfoIndex + 1)));
        if (flag)
          stringBuilder.Append(new string('*', this.srcMaxDigit));
        else
          stringBuilder.Append(string.Format("{0," + (object) this.srcMaxDigit + "}", traceInfo[0]));
        if (this.chkShowTime.Checked)
          stringBuilder.Append(string.Format("[{0}]", (object) ((DateTime) traceInfo[2]).ToString("HH:mm:ss.ff")));
        if (this.chkShowErrorLevel.Checked)
          stringBuilder.Append(string.Format("<{0,4:0000}>", this.lastTraceInfoList[traceInfoIndex][1]));
        stringBuilder.Append(':');
        if (!this.expandedTraceTextDic.ContainsKey(traceInfoIndex))
        {
          string[] strArray = new string[2];
          string input;
          if (flag)
          {
            input = (string) traceInfo[0];
          }
          else
          {
            int charIndexFromLine = this.getFirstCharIndexFromLine(this.lastSrc, (int) traceInfo[0] - 1);
            int num = this.lastSrc.IndexOf('\n', charIndexFromLine);
            input = num == -1 ? this.lastSrc.Substring(charIndexFromLine) : this.lastSrc.Substring(charIndexFromLine, num - charIndexFromLine);
          }
          strArray[0] = input;
          IDictionary dictionary1 = traceInfoIndex == 0 ? this.ipcServer.RemoteObject.BreakVariableDic : (IDictionary) this.lastTraceInfoList[traceInfoIndex - 1][3];
          Dictionary<string, string> varDic = new Dictionary<string, string>();
          foreach (string key in (IEnumerable) dictionary1.Keys)
            varDic[key.ToLower()] = (string) dictionary1[(object) key];
          Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
          foreach (string key in (IEnumerable) dictionary1.Keys)
            dictionary2[key] = (string) dictionary1[(object) key];
          MainForm.Func1<string, string> func1 = (MainForm.Func1<string, string>) (name =>
          {
            name = name.ToLower();
            switch (name)
            {
              case "cd":
                return (string) traceInfo[4];
              case "date":
                return ((DateTime) traceInfo[2]).ToString("yyyy/MM/dd");
              case "time":
                return ((DateTime) traceInfo[2]).ToString("HH:mm:ss.ff");
              case "random":
                return "0";
              case "cmdextversion":
                return this.cmdextversion;
              case "cmdcmdline":
                return BatDebugger.LastCmdLine;
              case "highestnumanodenumber":
                return this.highestnumanodenumber;
              default:
                if (name == "errorlevel")
                  name = "_errorlevel";
                return !varDic.ContainsKey(name) ? "" : varDic[name];
            }
          });
          int startIndex1 = 0;
          Stack<object[]> objArrayStack = new Stack<object[]>();
          Match match1;
          for (; (match1 = Regex.Match(input.Substring(startIndex1), "(%%)|%(~(?:[fdpnxsatz]*|\\$[a-z]+:))?(\\d)|%([a-zA-Z0-9_[\\]]+?)(:(?:~-?\\d+(?:,-?\\d+)?|[^%!=]*=[^%!=]*))?%|%.*$", RegexOptions.IgnoreCase)).Success; startIndex1 += match1.Index + match1.Length)
          {
            string str;
            if (match1.Groups[1].Success)
            {
              str = "%";
            }
            else
            {
              string t1 = !match1.Groups[3].Success ? match1.Groups[4].Value : "_arg_" + match1.Groups[3].Value;
              str = this.lastDumpArg || !t1.StartsWith("_arg_") ? func1(t1) : match1.Groups[0].Value;
              if (match1.Groups[2].Success && str != "")
                str = BatDebugger.GetCommandOutput(string.Format("for %I in ({0}) do @echo;%{1}I", (object) str, (object) match1.Groups[2].Value), (string) traceInfo[4]);
              else if (match1.Groups[5].Success && str != "")
              {
                Environment.SetEnvironmentVariable("_", str, EnvironmentVariableTarget.Process);
                str = BatDebugger.GetCommandOutput(string.Format("@echo;%_{0}%", (object) match1.Groups[5].Value), (string) traceInfo[4], false);
                Environment.SetEnvironmentVariable("_", "", EnvironmentVariableTarget.Process);
              }
            }
            objArrayStack.Push(new object[3]
            {
              (object) (startIndex1 + match1.Index),
              (object) match1.Length,
              (object) str
            });
          }
          foreach (object[] objArray in objArrayStack)
            input = input.Remove((int) objArray[0]) + objArray[2] + input.Substring((int) objArray[0] + (int) objArray[1]);
          int startIndex2 = 0;
          objArrayStack.Clear();
          Match match2;
          for (; (match2 = Regex.Match(input.Substring(startIndex2), "\\^(.)", RegexOptions.IgnoreCase)).Success; startIndex2 += match2.Index + match2.Length)
            objArrayStack.Push(new object[3]
            {
              (object) (startIndex2 + match2.Index),
              (object) match2.Length,
              (object) match2.Groups[1].Value
            });
          foreach (object[] objArray in objArrayStack)
            input = input.Remove((int) objArray[0]) + objArray[2] + input.Substring((int) objArray[0] + (int) objArray[1]);
          if (this.lastDumpForVar && !Regex.IsMatch(input, "^[ \\t]*@?for[ /]", RegexOptions.IgnoreCase))
          {
            int startIndex3 = 0;
            objArrayStack.Clear();
            Match match3;
            for (; (match3 = Regex.Match(input.Substring(startIndex3), "%(~(?:[fdpnxsatz]*|\\$[a-z]+:))?([a-z])", RegexOptions.IgnoreCase)).Success; startIndex3 += match3.Index + match3.Length)
            {
              string key = "_for_" + match3.Groups[2].Value;
              string commandOutput = dictionary2.ContainsKey(key) ? dictionary2[key] : "";
              if (match3.Groups[1].Success && commandOutput != "")
                commandOutput = BatDebugger.GetCommandOutput(string.Format("for %I in ({0}) do @echo;%{1}I", (object) commandOutput, (object) match3.Groups[1].Value), (string) traceInfo[4]);
              objArrayStack.Push(new object[3]
              {
                (object) (startIndex3 + match3.Index),
                (object) match3.Length,
                (object) commandOutput
              });
            }
            foreach (object[] objArray in objArrayStack)
              input = input.Remove((int) objArray[0]) + objArray[2] + input.Substring((int) objArray[0] + (int) objArray[1]);
          }
          int startIndex4 = 0;
          objArrayStack.Clear();
          Match match4;
          for (; (match4 = Regex.Match(input.Substring(startIndex4), "!([a-zA-Z0-9_[\\]]+?)(:(?:~-?\\d+(?:,-?\\d+)?|[^%!=]*=[^%!=]*))?!|!.*$")).Success; startIndex4 += match4.Index + match4.Length)
          {
            string t1 = match4.Groups[1].Value;
            string str = func1(t1);
            if (match4.Groups[2].Success && str != "")
            {
              Environment.SetEnvironmentVariable("_", str, EnvironmentVariableTarget.Process);
              str = BatDebugger.GetCommandOutput(string.Format("@echo;!_{0}!", (object) match4.Groups[2].Value), (string) traceInfo[4], true);
              Environment.SetEnvironmentVariable("_", "", EnvironmentVariableTarget.Process);
            }
            objArrayStack.Push(new object[3]
            {
              (object) (startIndex4 + match4.Index),
              (object) match4.Length,
              (object) str
            });
          }
          foreach (object[] objArray in objArrayStack)
            input = input.Remove((int) objArray[0]) + objArray[2] + input.Substring((int) objArray[0] + (int) objArray[1]);
          strArray[1] = input;
          this.expandedTraceTextDic[traceInfoIndex] = strArray;
        }
        string str1 = this.expandedTraceTextDic[traceInfoIndex][this.chkExpandVar.Checked ? 1 : 0];
        this.traceTextList.Add(stringBuilder.ToString() + str1);
        if (!(this.txtFilter.Text != "") || str1.Contains(this.txtFilter.Text))
        {
          this.visibleTraceTextIndexDic[this.lstInfo.Items.Count + stringList.Count] = traceInfoIndex;
          stringList.Add(stringBuilder.ToString() + str1);
        }
      }
      this.traceInfoIndex = count;
      this.lstInfo.Items.AddRange((object[]) stringList.ToArray());
      this.lstInfo.SelectedIndex = this.lstInfo.Items.Count - 1;
    }

    private void createNewEditTab()
    {
      TabPage tabPage = new TabPage();
      this.dtcEdit.Controls.Add((Control) tabPage);
      LinedRichTextBox editor = new LinedRichTextBox();
      editor.LstIntellisense = this.lstIntellisense;
      editor.AllowDrop = true;
      editor.Dock = DockStyle.Fill;
      editor.TextBox.Font = Setting.EditorFont;
      editor.Visible = false;
      editor.MoveNextTab = (Action<bool>) (toNext =>
      {
        int num = this.dtcEdit.TabPages.IndexOf(this.CurrentTab) + (toNext ? 1 : -1);
        this.dtcEdit.SelectedIndex = num == this.dtcEdit.TabCount ? 0 : (num == -1 ? this.dtcEdit.TabCount - 1 : num);
      });
      editor.Tag = (object) new Dictionary<string, object>()
      {
        ["TextEditState"] = (object) null
      };
      this.pnlEdit.Controls.Add((Control) editor);
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      BatDebugger debugger = new BatDebugger();
      editor.TextBox.TextChanged += (EventHandler) ((se, ev) =>
      {
        debugger.UpdatedSrc(editor.Text);
        this.UpdateTitle();
        this.tsbToolBoxUndo.Enabled = editor.TextBox.CanUndo;
        this.tsbToolBoxRedo.Enabled = editor.TextBox.CanRedo;
        this.tsbToolBoxBuild.Enabled = editor.Text.Length > 0;
        this.tsbToolBoxBuildNoConsole.Enabled = editor.Text.Length > 0;
      });
      editor.ToggledBreakPointDelg = new Action<int>(debugger.ToggleBreakPoint);
      editor.SetBPLineDic(debugger.BPLineDic);
      editor.TextBox.ContextMenuStrip = this.cmsEdit;
      dictionary["Debugger"] = (object) debugger;
      dictionary["Editor"] = (object) editor;
      tabPage.Tag = (object) dictionary;
      this.CurrentTab = tabPage;
      this.EditFilePath = "";
      foreach (Control allChildControl in this.getAllChildControls((Control) this.Editor))
      {
        allChildControl.AllowDrop = true;
        allChildControl.DragEnter += new DragEventHandler(this.MainForm_DragEnter);
        allChildControl.DragDrop += new DragEventHandler(this.MainForm_DragDrop);
      }
      editor.DecidedIntellisenseDelg = (Action<string>) (command =>
      {
        if (CommandReferenceDialog.CurrentInstance == null)
          return;
        CommandReferenceDialog.CurrentInstance.SelectItem(command);
      });
      editor.TextBox.ForeColor = Setting.ForeColor;
      editor.TextBox.BackColor = Setting.BackColor;
    }

    private bool closeEditTab() => this.closeEditTab(this.CurrentTab);

    private bool closeEditTab(TabPage tab)
    {
      if (this.CurrentTab == this.RunningTab)
      {
        if (MessageDialog.Show(MessageID.CFM_STOP_RUNNING) != DialogResult.Yes)
          return false;
        BatDebugger.Stop();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        while (stopwatch.ElapsedMilliseconds <= 10000L)
        {
          Application.DoEvents();
          if (BatDebugger.Running)
            Thread.Sleep(100);
          else
            break;
        }
      }
      if (this.confirmSavingText() == DialogResult.Cancel)
        return false;
      if (this.EditFilePath == "" && this.editorParamListWithClosing != null)
      {
        foreach (Dictionary<string, object> dictionary in this.editorParamListWithClosing)
        {
          if (this.Editor.Tag == dictionary)
          {
            this.editorParamListWithClosing.Remove(dictionary);
            break;
          }
        }
      }
      if (this.dtcEdit.TabCount == 1)
      {
        this.clearEditText();
        this.EditFilePath = "";
      }
      else
      {
        this.dtcEdit.TabPages.Remove(tab);
        ((Component) ((Dictionary<string, object>) tab.Tag)["Editor"]).Dispose();
        tab.Dispose();
      }
      return true;
    }

    private void mniFile_DropDownOpening(object sender, EventArgs e)
    {
      this.Editor.CloseIntelliSense(false);
      this.mniFileReload.Enabled = this.EditFilePath != "";
      try
      {
        this.mniFileOpenDirOnEditFile.Enabled = this.EditFilePath != "" && Directory.Exists(Path.GetDirectoryName(this.EditFilePath));
        this.mniFileOpenWorkDir.Enabled = Directory.Exists(this.txtWorkDir.Text);
      }
      catch
      {
      }
    }

    private void clearEditText()
    {
      this.Editor.Clear();
      this.Debugger.ClearBreakPoint();
      this.TextEditState = (object) null;
    }

    private DialogResult confirmSavingText()
    {
      if (!this.TextUpdated)
        return DialogResult.No;
      DialogResult dialogResult = MessageDialog.Show(MessageID.CFM_SAVE_FILE, this.EditFileName);
      if (dialogResult != DialogResult.Yes)
        return dialogResult;
      if (this.EditFilePath == "")
        return this.showSaveFileDialog();
      this.saveFile();
      return DialogResult.OK;
    }

    private DialogResult confirmDestructionEdit()
    {
      return !this.TextUpdated ? DialogResult.Yes : MessageDialog.Show(MessageID.CFM_DESTRUCTION_EDIT);
    }

    private void mniFileNew_Click(object sender, EventArgs e)
    {
      this.createNewEditTab();
      this.Editor.TextBox.Focus();
    }

    private void openFile(string filePath)
    {
      foreach (TabPage tabPage in this.dtcEdit.TabPages)
      {
        if ((string) ((Dictionary<string, object>) ((Control) ((Dictionary<string, object>) tabPage.Tag)["Editor"]).Tag)["EditFilePath"] == filePath)
        {
          this.CurrentTab = tabPage;
          return;
        }
      }
      if (this.EditFilePath != "" || this.TextUpdated || BatDebugger.Running)
        this.createNewEditTab();
      this.EditFilePath = filePath;
      this.Editor.Text = File.ReadAllText(this.EditFilePath, Encoding.GetEncoding("shift_jis"));
      this.Editor.TextBox.Focus();
    }

    private void mniFileOpen_Click(object sender, EventArgs e)
    {
      if (this.ofdEdit.FileName != null)
        this.ofdEdit.FileName = Path.GetFileName(this.ofdEdit.FileName);
      if (this.ofdEdit.ShowDialog() != DialogResult.OK)
        return;
      this.openFile(this.ofdEdit.FileName);
    }

    private void mniFileReload_Click(object sender, EventArgs e)
    {
      if (this.confirmDestructionEdit() == DialogResult.No)
        return;
      this.clearEditText();
      this.Editor.Text = File.ReadAllText(this.EditFilePath, Encoding.GetEncoding("shift_jis"));
      this.Editor.TextBox.Focus();
    }

    private void saveFile()
    {
      BatDebugger.WriteFile(this.EditFilePath, this.Editor.Text);
      this.TextEditState = this.Editor.TextBox.TextEditState;
      this.UpdateTitle();
    }

    private void mniFileSave_Click(object sender, EventArgs e)
    {
      if (this.EditFilePath == "")
      {
        int num = (int) this.showSaveFileDialog();
      }
      else
        this.saveFile();
    }

    private DialogResult showSaveFileDialog()
    {
      DialogResult dialogResult = this.sfdEdit.ShowDialog();
      if (dialogResult == DialogResult.OK)
      {
        this.EditFilePath = this.sfdEdit.FileName;
        this.saveFile();
      }
      return dialogResult;
    }

    private void mniFileSaveWithName_Click(object sender, EventArgs e)
    {
      int num = (int) this.showSaveFileDialog();
    }

    private void mniFileOpenDirOnEditFile_Click(object sender, EventArgs e)
    {
      Process.Start(Path.GetDirectoryName(this.EditFilePath));
    }

    private void mniFileOpenWorkDir_Click(object sender, EventArgs e)
    {
      Process.Start(this.txtWorkDir.Text);
    }

    private void mniFileExit_Click(object sender, EventArgs e)
    {
      this.quitFlag = true;
      this.Close();
    }

    private void mniEdit_DropDownOpening(object sender, EventArgs e)
    {
      this.Editor.CloseIntelliSense(false);
      this.mniEditUndo.Enabled = this.Editor.TextBox.CanUndo;
      this.mniEditRedo.Enabled = this.Editor.TextBox.CanRedo;
    }

    private void mniEditUndo_Click(object sender, EventArgs e) => this.Editor.TextBox.Undo();

    private void mniEditRedo_Click(object sender, EventArgs e) => this.Editor.TextBox.Redo();

    private void mniEditCut_Click(object sender, EventArgs e) => this.Editor.TextBox.Cut();

    private void mniEditCopy_Click(object sender, EventArgs e) => this.Editor.TextBox.Copy();

    private void mniEditPaste_Click(object sender, EventArgs e) => this.Editor.TextBox.Paste();

    private void mniEditDel_Click(object sender, EventArgs e) => this.Editor.TextBox.Delete();

    private void mniView_DropDownOpening(object sender, EventArgs e)
    {
      this.Editor.CloseIntelliSense(false);
    }

    private void mniViewToolBox_Click(object sender, EventArgs e)
    {
      this.sptRoot.Panel1Collapsed = !this.mniViewToolBox.Checked;
    }

    private void mniViewIdiom_Click(object sender, EventArgs e)
    {
      this.sptEditHorizontal.Panel2Collapsed = !this.mniViewIdiom.Checked;
    }

    private void mniViewCommandReference_Click(object sender, EventArgs e)
    {
      if (CommandReferenceDialog.CurrentInstance == null)
        new CommandReferenceDialog().Show();
      else
        CommandReferenceDialog.CurrentInstance.Activate();
    }

    private void mniViewTopMost_CheckedChanged(object sender, EventArgs e)
    {
      this.TopMost = this.mniViewTopMost.Checked;
      this.tslTopMost.Text = this.mniViewTopMost.Checked ? "常手前" : "";
    }

    private void mniSearch_DropDownOpening(object sender, EventArgs e)
    {
      this.Editor.CloseIntelliSense(false);
    }

    private void mniSearchFind_Click(object sender, EventArgs e)
    {
      if (FindDialog.CurrentInstance == null)
        new FindDialog(this.Editor.TextBox).Show((IWin32Window) this);
      else
        FindDialog.CurrentInstance.Activate();
    }

    private void mniSearchReplace_Click(object sender, EventArgs e)
    {
      if (ReplaceDialog.CurrentInstance == null)
        new ReplaceDialog(this.Editor.TextBox).Show((IWin32Window) this);
      else
        ReplaceDialog.CurrentInstance.Activate();
    }

    private void mniExecute_DropDownOpening(object sender, EventArgs e)
    {
      this.Editor.CloseIntelliSense(false);
    }

    private void run()
    {
      if (this.txtWorkDir.Text != "" && !Directory.Exists(this.txtWorkDir.Text))
      {
        int num = (int) MessageBox.Show("作業フォルダにアクセスできません。\n[" + this.txtWorkDir.Text + "]");
      }
      else
      {
        this.changeRunningState(true);
        this.Debugger.VerifyBreakPoint();
        this.Editor.LineNumberPanel.Invalidate();
        this.Debugger.Run(this.txtArguments.Text, this.txtWorkDir.Text, this.EditFilePath);
      }
    }

    private void mniExeRun_Click(object sender, EventArgs e)
    {
      BatDebugger.Debug = true;
      this.run();
    }

    private void mniExeRunWD_Click(object sender, EventArgs e)
    {
      BatDebugger.Debug = false;
      this.run();
    }

    private void mniExeStop_Click(object sender, EventArgs e)
    {
      this.ipcServer.RemoteObject.Stopped = true;
      BatDebugger.Stop();
    }

    private void mniDebug_DropDownOpening(object sender, EventArgs e)
    {
      this.Editor.CloseIntelliSense(false);
    }

    private void unbreak()
    {
      if (RunCommandDialog.CurrentInstance != null)
        RunCommandDialog.CurrentInstance.ChangeEnabledRunButton(false);
      this.tslBreakState.Text = "";
      this.Breaking = false;
      this.Editor.Unbreak();
      Dictionary<string, string> varDic = new Dictionary<string, string>();
      if (!this.dgvVarList.ReadOnly)
      {
        foreach (DataGridViewRow row in (IEnumerable) this.dgvVarList.Rows)
        {
          row.ReadOnly = true;
          string key = (string) row.Cells["ColumnName"].Value;
          string str = (string) row.Cells["ColumnValue"].Value;
          if (!key.StartsWith("%"))
          {
            if (!this.ipcServer.RemoteObject.BreakVariableDic.Contains((object) key) || str != (string) this.ipcServer.RemoteObject.BreakVariableDic[(object) key])
              varDic[key] = str ?? "";
            IDictionary dictionary = (IDictionary) this.lastTraceInfoList[this.lastTraceInfoList.Count - 1][3];
            if (str == null)
              dictionary.Remove((object) key);
            else
              dictionary[(object) key] = (object) str;
          }
        }
      }
      BatDebugger.WriteFeedBackVarBat((IDictionary) varDic);
      this.ipcServer.RemoteObject.ClearFeedBackData = true;
    }

    private void unbreakAsRunCommand()
    {
      if (RunCommandDialog.CurrentInstance != null)
        RunCommandDialog.CurrentInstance.ChangeEnabledRunButton(false);
      this.tslBreakState.Text = "";
      this.Editor.Unbreak();
    }

    private void mniDebugContinue_Click(object sender, EventArgs e)
    {
      if (this.ipcServer.RemoteObject.DebugCommand != DebugCommand.None)
        return;
      this.unbreak();
      this.ipcServer.RemoteObject.DebugCommand = DebugCommand.Continue;
    }

    private void mniDebugPause_Click(object sender, EventArgs e)
    {
      if (this.ipcServer.RemoteObject.DebugCommand != DebugCommand.Continue)
        return;
      this.ipcServer.RemoteObject.DebugCommand = DebugCommand.Step;
    }

    private void mniDebugStep_Click(object sender, EventArgs e)
    {
      if (this.ipcServer.RemoteObject.DebugCommand != DebugCommand.None)
        return;
      this.unbreak();
      this.ipcServer.RemoteObject.DebugCommand = DebugCommand.Step;
    }

    private void mniDebugInterruptCmd_Click(object sender, EventArgs e)
    {
      if (RunCommandDialog.CurrentInstance == null)
      {
        RunCommandDialog rcd = new RunCommandDialog();
        rcd.RunAction = (Action<string>) (command =>
        {
          if (rcd.RunningCommand)
            return;
          rcd.RunningCommand = true;
          BatDebugger.CreateBreakLoopCommandBat(command);
          this.unbreakAsRunCommand();
          RunCommandDialog.LastCommand = command;
          this.ipcServer.RemoteObject.DebugCommand = DebugCommand.Command;
        });
        rcd.Show((IWin32Window) this);
        rcd.ChangeEnabledRunButton(this.ipcServer.RemoteObject.DebugCommand == DebugCommand.None);
      }
      else
        RunCommandDialog.CurrentInstance.Activate();
    }

    private void mniDebugToggleBP_Click(object sender, EventArgs e)
    {
      this.Debugger.ToggleBreakPoint(this.Editor.TextBox.GetLineFromCharIndex(this.Editor.TextBox.SelectionStart) + 1);
      this.Editor.LineNumberPanel.Invalidate();
    }

    private void mniDebugClearBP_Click(object sender, EventArgs e)
    {
      this.Debugger.BPLineDic.Clear();
      this.Editor.LineNumberPanel.Invalidate();
    }

    private void mniBuild_DropDownOpening(object sender, EventArgs e)
    {
      this.mniBuildToExe.Enabled = this.Editor.Text.Length > 0;
      this.mniBuildToExeNoConsole.Enabled = this.Editor.Text.Length > 0;
    }

    private void mniBuildToExe_Click(object sender, EventArgs e)
    {
      if (this.EditFilePath != "")
      {
        this.sfdBuild.InitialDirectory = Path.GetDirectoryName(this.EditFilePath);
        this.sfdBuild.FileName = Path.GetFileNameWithoutExtension(this.EditFilePath) + ".exe";
      }
      this.sfdBuild.Title = "exeファイル作成";
      if (this.sfdBuild.ShowDialog() != DialogResult.OK)
        return;
      this.Debugger.ToExeFile(this.sfdBuild.FileName, Resources.VisualBat_Executer);
    }

    private void mniBuildToExeNoConsole_Click(object sender, EventArgs e)
    {
      if (this.EditFilePath != "")
      {
        this.sfdBuild.InitialDirectory = Path.GetDirectoryName(this.EditFilePath);
        this.sfdBuild.FileName = Path.GetFileNameWithoutExtension(this.EditFilePath) + ".exe";
      }
      this.sfdBuild.Title = "exeファイル作成(Console非表示)";
      if (this.sfdBuild.ShowDialog() != DialogResult.OK)
        return;
      this.Debugger.ToExeFile(this.sfdBuild.FileName, Resources.VisualBat_Executer_w);
    }

    private void mniSetting_DropDownOpening(object sender, EventArgs e)
    {
      this.Editor.CloseIntelliSense(false);
    }

    private void updateTextControlColor()
    {
      List<Control> controlList = new List<Control>();
      foreach (LinedRichTextBox allEditor in this.AllEditors)
        controlList.Add((Control) allEditor.TextBox);
      controlList.Add((Control) this.lstIdiomIndex);
      controlList.Add((Control) this.txtIdiomText);
      controlList.Add((Control) this.txtArguments);
      controlList.Add((Control) this.txtWorkDir);
      controlList.Add((Control) this.txtFilter);
      controlList.Add((Control) this.lstInfo);
      if (CommandReferenceDialog.CurrentInstance != null)
      {
        controlList.Add((Control) CommandReferenceDialog.CurrentInstance.LstReferenceIndex);
        controlList.Add((Control) CommandReferenceDialog.CurrentInstance.TxtReferenceText);
      }
      if (FindDialog.CurrentInstance != null)
        controlList.Add((Control) FindDialog.CurrentInstance.TxtData);
      if (ReplaceDialog.CurrentInstance != null)
      {
        controlList.Add((Control) ReplaceDialog.CurrentInstance.TxtBefore);
        controlList.Add((Control) ReplaceDialog.CurrentInstance.TxtAfter);
      }
      if (RunCommandDialog.CurrentInstance != null)
        controlList.Add((Control) RunCommandDialog.CurrentInstance.TxtCommand);
      foreach (Control control in controlList)
      {
        control.ForeColor = Setting.ForeColor;
        control.BackColor = Setting.BackColor;
      }
      this.dgvVarList.DefaultCellStyle.ForeColor = Setting.ForeColor;
      this.dgvVarList.DefaultCellStyle.BackColor = Setting.BackColor;
    }

    private void mniSettingOption_Click(object sender, EventArgs e)
    {
      using (OptionDialog optionDialog = new OptionDialog())
      {
        if (optionDialog.ShowDialog((IWin32Window) this) != DialogResult.OK)
          return;
        this.updateTextControlColor();
      }
    }

    private void mniHelp_DropDownOpening(object sender, EventArgs e)
    {
      this.Editor.CloseIntelliSense(false);
    }

    private void mniHelpVersion_Click(object sender, EventArgs e)
    {
      using (VersionInfoDialog versionInfoDialog = new VersionInfoDialog())
      {
        int num = (int) versionInfoDialog.ShowDialog();
      }
    }

    protected override void WndProc(ref Message m)
    {
      if (m.Msg == 163 && m.WParam.ToInt32() == 20)
        this.Close();
      base.WndProc(ref m);
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.quitFlag |= !Setting.CloseOnlyCurrentTab;
      this.editorParamListWithClosing = new List<Dictionary<string, object>>();
      this.editFilePathWithClosing = this.EditFilePath;
      for (int index = 0; index < this.dtcEdit.TabCount; ++index)
      {
        Dictionary<string, object> tag = (Dictionary<string, object>) ((Control) ((Dictionary<string, object>) this.dtcEdit.TabPages[index].Tag)["Editor"]).Tag;
        tag["EditFilePathClosing"] = tag["EditFilePath"];
        this.editorParamListWithClosing.Add(tag);
      }
      try
      {
        if (!this.quitFlag)
        {
          int tabCount = this.dtcEdit.TabCount;
          if (!this.closeEditTab())
          {
            e.Cancel = true;
            return;
          }
          if (this.dtcEdit.TabCount != tabCount)
          {
            e.Cancel = true;
            return;
          }
        }
        else
        {
          int tabCount;
          do
          {
            tabCount = this.dtcEdit.TabCount;
            if (!this.closeEditTab())
            {
              e.Cancel = true;
              return;
            }
          }
          while (this.dtcEdit.TabCount != tabCount);
        }
      }
      finally
      {
        this.quitFlag = false;
      }
      BatDebugger.Dispose();
      if (Setting.RememberLayout)
      {
        Setting.WasMaximum = this.WindowState == FormWindowState.Maximized;
        Setting.LastX = this.Location.X;
        Setting.LastY = this.Location.Y;
        Setting.LastWidth = this.Width;
        Setting.LastHeight = this.Height;
        Setting.ShownToolBox = this.mniViewToolBox.Checked;
        Setting.ShownIdiom = this.mniViewIdiom.Checked;
        Setting.ShownCommandReference = CommandReferenceDialog.CurrentInstance != null;
        if (Setting.ShownCommandReference)
          CommandReferenceDialog.CurrentInstance.SaveLastLayout();
        Setting.MainVertical = this.sptMainVertical.SplitterDistance;
        Setting.EditHorizontal = this.sptEditHorizontal.SplitterDistance;
        Setting.IdiomVertical = this.sptIdiomVertical.SplitterDistance;
        Setting.DebugHorizontal = this.sptDebugHorizontal.SplitterDistance;
        Setting.DumpVarGridNameWidth = this.dgvVarList.Columns["ColumnName"].Width;
      }
      if (Setting.RememberTab)
      {
        Setting.LastTabCount = this.editorParamListWithClosing.Count;
        Setting.LastFilePath = this.editFilePathWithClosing;
        Setting.LastFilePathList = new List<string>();
        foreach (Dictionary<string, object> dictionary in this.editorParamListWithClosing)
          Setting.LastFilePathList.Add((string) dictionary["EditFilePathClosing"]);
      }
      Setting.ShowTime = this.chkShowTime.Checked;
      Setting.ShowErrorLevel = this.chkShowErrorLevel.Checked;
      Setting.ExpandVar = this.chkExpandVar.Checked;
      Setting.WorkDirectory = this.txtWorkDir.Text;
      Setting.SaveSetting();
    }

    private void MainForm_DragEnter(object sender, DragEventArgs e)
    {
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
        e.Effect = DragDropEffects.None;
      else
        e.Effect = DragDropEffects.Move;
    }

    private void MainForm_DragDrop(object sender, DragEventArgs e)
    {
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
        return;
      foreach (string str in (string[]) e.Data.GetData(DataFormats.FileDrop, false))
      {
        if (File.Exists(str))
          this.openFile(str);
      }
    }

    private void txtArguments_DragEnter(object sender, DragEventArgs e)
    {
      if (BatDebugger.Running)
        e.Effect = DragDropEffects.None;
      else if (!e.Data.GetDataPresent(DataFormats.FileDrop))
        e.Effect = DragDropEffects.None;
      else
        e.Effect = DragDropEffects.Move;
    }

    private void txtArguments_DragDrop(object sender, DragEventArgs e)
    {
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
        return;
      this.txtArguments.Text = string.Join(" ", (string[]) e.Data.GetData(DataFormats.FileDrop, false));
    }

    private void txtWorkDir_DragEnter(object sender, DragEventArgs e)
    {
      if (BatDebugger.Running)
        e.Effect = DragDropEffects.None;
      else if (!e.Data.GetDataPresent(DataFormats.FileDrop))
        e.Effect = DragDropEffects.None;
      else if (((string[]) e.Data.GetData(DataFormats.FileDrop, false)).Length > 1)
        e.Effect = DragDropEffects.None;
      else
        e.Effect = DragDropEffects.Move;
    }

    private void txtWorkDir_DragDrop(object sender, DragEventArgs e)
    {
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
        return;
      string[] data = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
      if (data.Length > 1)
        return;
      string directoryName = data[0];
      if (!Directory.Exists(data[0]))
        directoryName = Path.GetDirectoryName(directoryName);
      this.txtWorkDir.Text = directoryName;
    }

    private void timWatchBreak_Tick(object sender, EventArgs e)
    {
      if (this.ipcServer.RemoteObject.TraceInfoCountReceived && this.ipcServer.RemoteObject.TraceInfoList.Count > 0)
      {
        this.lastTraceInfoList.AddRange((IEnumerable<object[]>) this.ipcServer.RemoteObject.TraceInfoList);
        this.ipcServer.RemoteObject.TraceInfoCount = this.ipcServer.RemoteObject.TraceInfoList.Count;
        this.ipcServer.RemoteObject.TraceInfoCountReceived = false;
      }
      this.updateTraceInfo();
      if (!this.ipcServer.RemoteObject.Breaking)
        return;
      if (this.RunningTab != this.CurrentTab)
        this.CurrentTab = this.RunningTab;
      this.ipcServer.RemoteObject.Breaking = false;
      if (RunCommandDialog.CurrentInstance != null)
      {
        RunCommandDialog.CurrentInstance.ChangeEnabledRunButton(true);
        if (RunCommandDialog.CurrentInstance.RunningCommand)
        {
          RunCommandDialog.CurrentInstance.Activate();
          RunCommandDialog.CurrentInstance.RunningCommand = false;
        }
        else
          this.Activate();
      }
      else
        this.Activate();
      this.tslBreakState.Text = "break";
      this.Breaking = true;
      this.Editor.Break(this.ipcServer.RemoteObject.BreakLine);
      this.updateVarList();
    }

    private void updateVarList()
    {
      this.dgvVarList.Rows.Clear();
      if (this.lstInfo.SelectedIndex == -1)
        return;
      this.dgvVarList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      int index = this.visibleTraceTextIndexDic[this.lstInfo.SelectedIndex];
      this.dgvVarList.ReadOnly = index != this.traceTextList.Count - 1 || !this.Breaking;
      SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
      IDictionary dictionary = (IDictionary) this.lastTraceInfoList[index][3];
      foreach (string key in (IEnumerable) dictionary.Keys)
        sortedDictionary[key] = (string) dictionary[(object) key];
      foreach (string key in sortedDictionary.Keys)
      {
        if (key.StartsWith("_arg_"))
        {
          this.dgvVarList.Rows.Add((object) ("%" + key.Substring(5)), dictionary[(object) key]);
          this.dgvVarList.Rows[this.dgvVarList.Rows.Count - 1].ReadOnly = true;
        }
        else if (key.StartsWith("_for_") && (string) dictionary[(object) key] != "%" + key.Substring(5))
        {
          this.dgvVarList.Rows.Add((object) ("%%" + key.Substring(5)), dictionary[(object) key]);
          this.dgvVarList.Rows[this.dgvVarList.Rows.Count - 1].ReadOnly = true;
        }
      }
      foreach (string key in sortedDictionary.Keys)
      {
        if (!(key == "_errorlevel") && !(key == "_getfor") && !key.StartsWith("_arg_") && !key.StartsWith("_for_") && !this.ipcServer.RemoteObject.SystemVariableDic.Contains((object) key))
          this.dgvVarList.Rows.Add((object) key, dictionary[(object) key]);
      }
      this.dgvVarList.CurrentCell = (DataGridViewCell) null;
      this.dgvVarList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void dgvVarList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      this.dgvVarList.CurrentCell = (DataGridViewCell) null;
    }

    private void dgvVarList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if (this.lstInfo.SelectedIndex == -1)
        return;
      IDictionary dictionary = (IDictionary) this.lastTraceInfoList[this.visibleTraceTextIndexDic[this.lstInfo.SelectedIndex]][3];
      if (!(this.dgvVarList.Columns[e.ColumnIndex].Name == "ColumnValue"))
        return;
      string key = (string) this.dgvVarList.Rows[e.RowIndex].Cells["ColumnName"].Value;
      string str = (string) this.dgvVarList.Rows[e.RowIndex].Cells["ColumnValue"].Value;
      if (key.StartsWith("%"))
        return;
      if ((string) dictionary[(object) key] != str && !this.dgvVarList.ReadOnly)
        e.CellStyle.BackColor = Color.Orange;
      else
        e.CellStyle.BackColor = this.dgvVarList.DefaultCellStyle.BackColor;
    }

    private void initTraceInfo()
    {
      int selectedIndex = this.lstInfo.SelectedIndex;
      int topIndex = this.lstInfo.TopIndex;
      this.lstInfo.Items.Clear();
      this.traceInfoIndex = 0;
      this.traceTextList = new List<string>();
      this.visibleTraceTextIndexDic = new Dictionary<int, int>();
      this.updateTraceInfo();
      if (this.lstInfo.Items.Count == 0)
        return;
      if (this.txtFilter.Text == "")
      {
        this.lstInfo.SelectedIndex = selectedIndex;
        this.lstInfo.TopIndex = topIndex;
      }
      else
      {
        this.lstInfo.SelectedIndex = -1;
        this.lstInfo.TopIndex = 0;
      }
    }

    private void chkShowTime_CheckedChanged(object sender, EventArgs e) => this.initTraceInfo();

    private void chkShowErrorLevel_CheckedChanged(object sender, EventArgs e)
    {
      this.initTraceInfo();
    }

    private void chkExpandVar_CheckedChanged(object sender, EventArgs e) => this.initTraceInfo();

    private void txtFilter_TextChanged(object sender, EventArgs e) => this.initTraceInfo();

    private void sptMainVertical_DoubleClick(object sender, EventArgs e)
    {
      if (this.sptMainVertical.Panel2.Width != 0)
        this.sptMainVertical.Tag = (object) this.sptMainVertical.SplitterDistance;
      this.sptMainVertical.SplitterDistance = this.sptMainVertical.Panel2.Width == 0 ? (int) (this.sptMainVertical.Tag ?? (object) Math.Max(this.sptMainVertical.Panel1MinSize, this.sptMainVertical.Width - 120)) : this.sptMainVertical.Width;
    }

    private void sptEditHorizontal_DoubleClick(object sender, EventArgs e)
    {
      if (this.sptEditHorizontal.Panel2.Height != 0)
        this.sptEditHorizontal.Tag = (object) this.sptEditHorizontal.SplitterDistance;
      this.sptEditHorizontal.SplitterDistance = this.sptEditHorizontal.Panel2.Height == 0 ? (int) (this.sptEditHorizontal.Tag ?? (object) Math.Max(this.sptEditHorizontal.Panel1MinSize, this.sptEditHorizontal.Height - 120)) : this.sptEditHorizontal.Height;
    }

    private void lstIdiomIndex_SelectedValueChanged(object sender, EventArgs e)
    {
      if (this.lstIdiomIndex.SelectedItem == null)
      {
        this.btnModifyIdiom.Enabled = false;
      }
      else
      {
        this.btnModifyIdiom.Enabled = true;
        this.txtIdiomText.Text = Setting.IdiomDic[(string) this.lstIdiomIndex.SelectedItem];
      }
    }

    private void lstIdiomIndex_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Return:
          if (e.Control)
          {
            this.mniCtxIdiomIndexModify_Click((object) null, (EventArgs) null);
            break;
          }
          this.mniCtxIdiomIndexInsert_Click((object) null, (EventArgs) null);
          break;
        case Keys.Delete:
          this.mniCtxIdiomIndexDelete_Click((object) null, (EventArgs) null);
          break;
      }
    }

    private void lstIdiomIndex_MouseDown(object sender, MouseEventArgs e)
    {
      this.lstIdiomIndex.Tag = (object) new int[2]
      {
        this.lstIdiomIndex.IndexFromPoint(e.X, e.Y),
        0
      };
    }

    private void lstIdiomIndex_MouseUp(object sender, MouseEventArgs e)
    {
      if (this.lstIdiomIndex.Tag != null && ((int[]) this.lstIdiomIndex.Tag)[1] == 1)
        Setting.SaveIdiom();
      this.lstIdiomIndex.Tag = (object) null;
    }

    private void lstIdiomIndex_MouseMove(object sender, MouseEventArgs e)
    {
      int index1 = this.lstIdiomIndex.IndexFromPoint(e.X, e.Y);
      int index2 = this.lstIdiomIndex.Tag != null ? ((int[]) this.lstIdiomIndex.Tag)[0] : -1;
      if (index2 != -1)
      {
        if (index1 == -1 || index1 == index2)
          return;
        string idiom = Setting.IdiomList[index1];
        Setting.IdiomList[index1] = Setting.IdiomList[index2];
        this.lstIdiomIndex.Items[index1] = this.lstIdiomIndex.Items[index2];
        Setting.IdiomList[index2] = idiom;
        this.lstIdiomIndex.Items[index2] = (object) idiom;
        this.lstIdiomIndex.Tag = (object) new int[2]
        {
          index1,
          1
        };
        this.lstIdiomIndex.SelectedIndex = index1;
      }
      else if (index1 == -1)
      {
        this.tipIdiomName.Active = false;
        this.tipIdiomName.Tag = (object) null;
      }
      else
      {
        string str = (string) this.lstIdiomIndex.Items[index1];
        if (TextRenderer.MeasureText(str, this.lstIdiomIndex.Font).Width <= this.lstIdiomIndex.Width)
        {
          this.tipIdiomName.Active = false;
          this.tipIdiomName.Tag = (object) null;
        }
        else
        {
          if (this.tipIdiomName.Tag != null && index1 == (int) this.tipIdiomName.Tag)
            return;
          if (!this.tipIdiomName.Active)
            this.tipIdiomName.Active = true;
          this.tipIdiomName.SetToolTip((Control) this.lstIdiomIndex, str);
          this.tipIdiomName.Tag = (object) index1;
        }
      }
    }

    private void showAddIdiomDialog(string name, string text)
    {
      using (AddIdiomDialog addIdiomDialog = new AddIdiomDialog())
      {
        if (name != null)
        {
          addIdiomDialog.Modify = true;
          addIdiomDialog.IdiomName = name;
          addIdiomDialog.IdiomText = Setting.IdiomDic[name];
        }
        if (text != null)
          addIdiomDialog.IdiomText = text;
        if (addIdiomDialog.ShowDialog() != DialogResult.OK)
          return;
        if (addIdiomDialog.Modify)
        {
          Setting.IdiomList[Setting.IdiomList.IndexOf(name)] = addIdiomDialog.IdiomName;
          Setting.IdiomDic.Remove(name);
        }
        else
          Setting.IdiomList.Add(addIdiomDialog.IdiomName);
        Setting.IdiomDic[addIdiomDialog.IdiomName] = addIdiomDialog.IdiomText;
        Setting.SaveIdiom();
        this.updateIdiom();
        if (!addIdiomDialog.Modify)
          return;
        this.lstIdiomIndex.SelectedItem = (object) addIdiomDialog.IdiomName;
      }
    }

    private void lstIdiomIndex_DoubleClick(object sender, EventArgs e)
    {
      this.btnModifyIdiom.PerformClick();
    }

    private void txtIdiomText_KeyDown(object sender, KeyEventArgs e)
    {
      TextBox textBox = (TextBox) sender;
      if (e.KeyCode != Keys.A || !e.Control)
        return;
      textBox.SelectAll();
    }

    private void txtIdiomText_Enter(object sender, EventArgs e)
    {
    }

    private void btnAddIdiom_Click(object sender, EventArgs e)
    {
      this.showAddIdiomDialog((string) null, (string) null);
    }

    private void btnModifyIdiom_Click(object sender, EventArgs e)
    {
      if (this.lstIdiomIndex.SelectedItem == null)
        return;
      this.showAddIdiomDialog((string) this.lstIdiomIndex.SelectedItem, (string) null);
    }

    private void cmsEdit_Opening(object sender, CancelEventArgs e)
    {
      if (BatDebugger.Running)
      {
        e.Cancel = true;
      }
      else
      {
        this.Editor.CloseIntelliSense(false);
        this.mniCtxEditUndo.Enabled = this.Editor.TextBox.CanUndo;
        this.mniCtxEditRedo.Enabled = this.Editor.TextBox.CanRedo;
      }
    }

    private void mniCtxEditAddIdiom_Click(object sender, EventArgs e)
    {
      this.showAddIdiomDialog((string) null, Regex.Replace(this.Editor.TextBox.SelectedText, "\\n", "\r\n"));
    }

    private void mniCtxIdiomIndexInsert_Click(object sender, EventArgs e)
    {
      if (this.lstIdiomIndex.SelectedItem == null || BatDebugger.Running)
        return;
      this.Editor.TextBox.ChangeSelectedText(this.txtIdiomText.Text);
      this.Editor.TextBox.Focus();
    }

    private void mniCtxIdiomIndexModify_Click(object sender, EventArgs e)
    {
      if (this.lstIdiomIndex.SelectedItem == null)
        return;
      this.btnModifyIdiom_Click((object) null, (EventArgs) null);
    }

    private void mniCtxIdiomIndexDelete_Click(object sender, EventArgs e)
    {
      if (this.lstIdiomIndex.SelectedItem == null)
        return;
      string selectedItem = (string) this.lstIdiomIndex.SelectedItem;
      if (MessageBox.Show("'" + selectedItem + "' を削除してよろしいですか？", "確認", MessageBoxButtons.OKCancel) != DialogResult.OK)
        return;
      Setting.IdiomList.Remove(selectedItem);
      Setting.IdiomDic.Remove(selectedItem);
      Setting.SaveIdiom();
      this.updateIdiom();
    }

    private void cmsIdiomIndex_Opening(object sender, CancelEventArgs e)
    {
      this.mniCtxIdiomIndexInsert.Enabled = !BatDebugger.Running;
    }

    private void dtcEdit_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.dtcEdit.TabCount == 0)
        return;
      if (this.LastTab != null)
        this.LastEditor.Visible = false;
      this.Editor.Visible = true;
      this.Editor.TextBox.Focus();
      this.LastTab = this.CurrentTab;
      this.Editor.CloseIntelliSense(false);
    }

    private void dtcEdit_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Middle)
        return;
      for (int index = 0; index < this.dtcEdit.TabCount; ++index)
      {
        if (this.dtcEdit.GetTabRect(index).Contains(e.X, e.Y))
        {
          if (BatDebugger.Running)
            this.dtcEdit.SelectedTab = this.dtcEdit.TabPages[index];
          LinedRichTextBox linedRichTextBox = (LinedRichTextBox) ((Dictionary<string, object>) this.dtcEdit.TabPages[index].Tag)["Editor"];
          if (((Dictionary<string, object>) linedRichTextBox.Tag)["TextEditState"] != linedRichTextBox.TextBox.TextEditState)
            this.dtcEdit.SelectedTab = this.dtcEdit.TabPages[index];
          this.closeEditTab(this.dtcEdit.TabPages[index]);
          break;
        }
      }
    }

    private void dtcEdit_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      this.dtcEdit_MouseClick(sender, e);
    }

    private void dtcEdit_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        for (int index = 0; index < this.dtcEdit.TabCount; ++index)
        {
          if (this.dtcEdit.GetTabRect(index).Contains(e.X, e.Y))
          {
            this.dtcEdit.SelectedTab = this.dtcEdit.TabPages[index];
            this.cmsEditTab.Show((Control) this.dtcEdit, e.X, e.Y);
          }
        }
      }
      else
      {
        int button = (int) e.Button;
      }
    }

    private void mniCtxEditTabClose_Click(object sender, EventArgs e) => this.closeEditTab();

    private void mniEditCloseTab_Click(object sender, EventArgs e) => this.closeEditTab();

    private void MainForm_Deactivate(object sender, EventArgs e)
    {
      this.Editor.CloseIntelliSense(false);
    }

    private void lstInfo_SelectedIndexChanged(object sender, EventArgs e) => this.updateVarList();

    private void lstIntellisense_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      int num = this.lstIntellisense.IndexFromPoint(e.X, e.Y);
      if (num == -1)
        return;
      this.lstIntellisense.SelectedIndex = num;
      this.Editor.CloseIntelliSense(true);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MainForm));
      this.sptMainVertical = new SplitContainer();
      this.sptEditHorizontal = new SplitContainer();
      this.pnlEdit = new Panel();
      this.dtcEdit = new DraggableTabControl();
      this.pnlEditLeft = new Panel();
      this.sptIdiomVertical = new SplitContainer();
      this.lstIdiomIndex = new ListBox();
      this.tlpIdiomControl = new TableLayoutPanel();
      this.btnAddIdiom = new Button();
      this.btnModifyIdiom = new Button();
      this.txtIdiomText = new TextBox();
      this.sptDebugHorizontal = new SplitContainer();
      this.dgvVarList = new DataGridView();
      this.ColumnName = new DataGridViewTextBoxColumn();
      this.ColumnValue = new DataGridViewTextBoxColumn();
      this.grpRunningCondition = new GroupBox();
      this.txtWorkDir = new TextBox();
      this.lblWorkDir = new Label();
      this.txtArguments = new TextBox();
      this.lblArguments = new Label();
      this.lstInfo = new ListBox();
      this.grpTraceSetting = new GroupBox();
      this.lblFilter = new Label();
      this.txtFilter = new TextBox();
      this.chkExpandVar = new CheckBox();
      this.chkShowErrorLevel = new CheckBox();
      this.chkShowTime = new CheckBox();
      this.stsMain = new StatusStrip();
      this.tslTopMost = new ToolStripStatusLabel();
      this.tslRunningState = new ToolStripStatusLabel();
      this.tslBreakState = new ToolStripStatusLabel();
      this.mnuMain = new MenuStrip();
      this.mniFile = new ToolStripMenuItem();
      this.mniFileNew = new ToolStripMenuItem();
      this.mniFileOpen = new ToolStripMenuItem();
      this.toolStripMenuItem7 = new ToolStripSeparator();
      this.mniFileReload = new ToolStripMenuItem();
      this.toolStripMenuItem4 = new ToolStripSeparator();
      this.mniFileSave = new ToolStripMenuItem();
      this.mniFileSaveWithName = new ToolStripMenuItem();
      this.toolStripMenuItem5 = new ToolStripSeparator();
      this.mniFileOpenDirOnEditFile = new ToolStripMenuItem();
      this.mniFileOpenWorkDir = new ToolStripMenuItem();
      this.toolStripMenuItem6 = new ToolStripSeparator();
      this.mniFileExit = new ToolStripMenuItem();
      this.mniEdit = new ToolStripMenuItem();
      this.mniEditCloseTab = new ToolStripMenuItem();
      this.toolStripMenuItem3 = new ToolStripSeparator();
      this.mniEditUndo = new ToolStripMenuItem();
      this.mniEditRedo = new ToolStripMenuItem();
      this.tsmEditSeparate = new ToolStripSeparator();
      this.mniEditCut = new ToolStripMenuItem();
      this.mniEditCopy = new ToolStripMenuItem();
      this.mniEditPaste = new ToolStripMenuItem();
      this.mniEditDel = new ToolStripMenuItem();
      this.toolStripMenuItem1 = new ToolStripSeparator();
      this.mniEditAddIdiom = new ToolStripMenuItem();
      this.mniView = new ToolStripMenuItem();
      this.mniViewToolBox = new ToolStripMenuItem();
      this.mniViewIdiom = new ToolStripMenuItem();
      this.mniViewCommandReference = new ToolStripMenuItem();
      this.mniViewTopMost = new ToolStripMenuItem();
      this.mniSearch = new ToolStripMenuItem();
      this.mniSearchFind = new ToolStripMenuItem();
      this.mniSearchReplace = new ToolStripMenuItem();
      this.mniExecute = new ToolStripMenuItem();
      this.mniExeRun = new ToolStripMenuItem();
      this.mniExeRunWD = new ToolStripMenuItem();
      this.mniExeStop = new ToolStripMenuItem();
      this.mniDebug = new ToolStripMenuItem();
      this.mniDebugContinue = new ToolStripMenuItem();
      this.mniDebugPause = new ToolStripMenuItem();
      this.mniDebugStep = new ToolStripMenuItem();
      this.tsmDebugSeparate = new ToolStripSeparator();
      this.mniDebugInterruptCmd = new ToolStripMenuItem();
      this.toolStripMenuItem2 = new ToolStripSeparator();
      this.mniDebugToggleBP = new ToolStripMenuItem();
      this.mniDebugClearBP = new ToolStripMenuItem();
      this.mniBuild = new ToolStripMenuItem();
      this.mniBuildToExe = new ToolStripMenuItem();
      this.mniBuildToExeNoConsole = new ToolStripMenuItem();
      this.mniSetting = new ToolStripMenuItem();
      this.mniSettingOption = new ToolStripMenuItem();
      this.mniHelp = new ToolStripMenuItem();
      this.mniHelpVersion = new ToolStripMenuItem();
      this.pnlRight = new Panel();
      this.ofdEdit = new OpenFileDialog();
      this.sfdEdit = new SaveFileDialog();
      this.timWatchBreak = new System.Windows.Forms.Timer(this.components);
      this.sfdBuild = new SaveFileDialog();
      this.cmsEdit = new ContextMenuStrip(this.components);
      this.mniCtxEditUndo = new ToolStripMenuItem();
      this.mniCtxEditRedo = new ToolStripMenuItem();
      this.tsmCtxEditSeparator1 = new ToolStripSeparator();
      this.mniCtxEditCut = new ToolStripMenuItem();
      this.mniCtxEditCopy = new ToolStripMenuItem();
      this.mniCtxEditPaste = new ToolStripMenuItem();
      this.mniCtxEditDelete = new ToolStripMenuItem();
      this.tsmCtxEditSeparator2 = new ToolStripSeparator();
      this.mniCtxEditAddIdiom = new ToolStripMenuItem();
      this.tipIdiomName = new ToolTip(this.components);
      this.cmsIdiomIndex = new ContextMenuStrip(this.components);
      this.mniCtxIdiomIndexInsert = new ToolStripMenuItem();
      this.mniCtxIdiomIndexModify = new ToolStripMenuItem();
      this.mniCtxIdiomIndexDelete = new ToolStripMenuItem();
      this.sptRoot = new SplitContainer();
      this.tstToolBox = new ToolStrip();
      this.tsbToolBoxNew = new ToolStripButton();
      this.tsbToolBoxOpen = new ToolStripButton();
      this.tsbToolBoxSave = new ToolStripButton();
      this.tsbToolBoxSaveNamed = new ToolStripButton();
      this.tssToolBoxSeparator1 = new ToolStripSeparator();
      this.tsbToolBoxUndo = new ToolStripButton();
      this.tsbToolBoxRedo = new ToolStripButton();
      this.tssToolBoxSeparator2 = new ToolStripSeparator();
      this.tsbToolBoxRun = new ToolStripButton();
      this.tsbToolBoxPause = new ToolStripButton();
      this.tsbToolBoxStop = new ToolStripButton();
      this.tssToolBoxSeparator3 = new ToolStripSeparator();
      this.tsbToolBoxContinue = new ToolStripButton();
      this.tsbToolBoxStep = new ToolStripButton();
      this.tssToolBoxSeparator4 = new ToolStripSeparator();
      this.tsbToolBoxBuild = new ToolStripButton();
      this.tsbToolBoxBuildNoConsole = new ToolStripButton();
      this.tssToolBoxSeparator5 = new ToolStripSeparator();
      this.tsbToolBoxOption = new ToolStripButton();
      this.cmsEditTab = new ContextMenuStrip(this.components);
      this.mniCtxEditTabClose = new ToolStripMenuItem();
      this.lstIntellisense = new ListBox();
      this.sptMainVertical.Panel1.SuspendLayout();
      this.sptMainVertical.Panel2.SuspendLayout();
      this.sptMainVertical.SuspendLayout();
      this.sptEditHorizontal.Panel1.SuspendLayout();
      this.sptEditHorizontal.Panel2.SuspendLayout();
      this.sptEditHorizontal.SuspendLayout();
      this.sptIdiomVertical.Panel1.SuspendLayout();
      this.sptIdiomVertical.Panel2.SuspendLayout();
      this.sptIdiomVertical.SuspendLayout();
      this.tlpIdiomControl.SuspendLayout();
      this.sptDebugHorizontal.Panel1.SuspendLayout();
      this.sptDebugHorizontal.Panel2.SuspendLayout();
      this.sptDebugHorizontal.SuspendLayout();
      ((ISupportInitialize) this.dgvVarList).BeginInit();
      this.grpRunningCondition.SuspendLayout();
      this.grpTraceSetting.SuspendLayout();
      this.stsMain.SuspendLayout();
      this.mnuMain.SuspendLayout();
      this.cmsEdit.SuspendLayout();
      this.cmsIdiomIndex.SuspendLayout();
      this.sptRoot.Panel1.SuspendLayout();
      this.sptRoot.Panel2.SuspendLayout();
      this.sptRoot.SuspendLayout();
      this.tstToolBox.SuspendLayout();
      this.cmsEditTab.SuspendLayout();
      this.SuspendLayout();
      this.sptMainVertical.Dock = DockStyle.Fill;
      this.sptMainVertical.Location = new Point(0, 0);
      this.sptMainVertical.Name = "sptMainVertical";
      this.sptMainVertical.Panel1.Controls.Add((Control) this.sptEditHorizontal);
      this.sptMainVertical.Panel2.Controls.Add((Control) this.sptDebugHorizontal);
      this.sptMainVertical.Panel2MinSize = 0;
      this.sptMainVertical.Size = new Size(798, 530);
      this.sptMainVertical.SplitterDistance = 450;
      this.sptMainVertical.TabIndex = 0;
      this.sptMainVertical.TabStop = false;
      this.sptMainVertical.DoubleClick += new EventHandler(this.sptMainVertical_DoubleClick);
      this.sptEditHorizontal.Dock = DockStyle.Fill;
      this.sptEditHorizontal.Location = new Point(0, 0);
      this.sptEditHorizontal.Name = "sptEditHorizontal";
      this.sptEditHorizontal.Orientation = Orientation.Horizontal;
      this.sptEditHorizontal.Panel1.Controls.Add((Control) this.pnlEdit);
      this.sptEditHorizontal.Panel1.Controls.Add((Control) this.dtcEdit);
      this.sptEditHorizontal.Panel1.Controls.Add((Control) this.pnlEditLeft);
      this.sptEditHorizontal.Panel2.Controls.Add((Control) this.sptIdiomVertical);
      this.sptEditHorizontal.Panel2MinSize = 0;
      this.sptEditHorizontal.Size = new Size(450, 530);
      this.sptEditHorizontal.SplitterDistance = 374;
      this.sptEditHorizontal.TabIndex = 1;
      this.sptEditHorizontal.TabStop = false;
      this.sptEditHorizontal.DoubleClick += new EventHandler(this.sptEditHorizontal_DoubleClick);
      this.pnlEdit.Dock = DockStyle.Fill;
      this.pnlEdit.Location = new Point(2, 18);
      this.pnlEdit.Name = "pnlEdit";
      this.pnlEdit.Size = new Size(448, 356);
      this.pnlEdit.TabIndex = 3;
      this.dtcEdit.AllowDrop = true;
      this.dtcEdit.Dock = DockStyle.Top;
      this.dtcEdit.HotTrack = true;
      this.dtcEdit.Location = new Point(2, 0);
      this.dtcEdit.Name = "dtcEdit";
      this.dtcEdit.SelectedIndex = 0;
      this.dtcEdit.Size = new Size(448, 18);
      this.dtcEdit.TabIndex = 1;
      this.dtcEdit.TabStop = false;
      this.dtcEdit.MouseDoubleClick += new MouseEventHandler(this.dtcEdit_MouseDoubleClick);
      this.dtcEdit.MouseClick += new MouseEventHandler(this.dtcEdit_MouseClick);
      this.dtcEdit.MouseDown += new MouseEventHandler(this.dtcEdit_MouseDown);
      this.dtcEdit.SelectedIndexChanged += new EventHandler(this.dtcEdit_SelectedIndexChanged);
      this.pnlEditLeft.Dock = DockStyle.Left;
      this.pnlEditLeft.Location = new Point(0, 0);
      this.pnlEditLeft.Name = "pnlEditLeft";
      this.pnlEditLeft.Size = new Size(2, 374);
      this.pnlEditLeft.TabIndex = 2;
      this.sptIdiomVertical.Dock = DockStyle.Fill;
      this.sptIdiomVertical.FixedPanel = FixedPanel.Panel1;
      this.sptIdiomVertical.Location = new Point(0, 0);
      this.sptIdiomVertical.Name = "sptIdiomVertical";
      this.sptIdiomVertical.Panel1.Controls.Add((Control) this.lstIdiomIndex);
      this.sptIdiomVertical.Panel1.Controls.Add((Control) this.tlpIdiomControl);
      this.sptIdiomVertical.Panel2.Controls.Add((Control) this.txtIdiomText);
      this.sptIdiomVertical.Size = new Size(450, 152);
      this.sptIdiomVertical.SplitterDistance = 120;
      this.sptIdiomVertical.TabIndex = 0;
      this.sptIdiomVertical.TabStop = false;
      this.lstIdiomIndex.AllowDrop = true;
      this.lstIdiomIndex.BorderStyle = BorderStyle.FixedSingle;
      this.lstIdiomIndex.Dock = DockStyle.Fill;
      this.lstIdiomIndex.Font = new Font("ＭＳ ゴシック", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.lstIdiomIndex.FormattingEnabled = true;
      this.lstIdiomIndex.ItemHeight = 12;
      this.lstIdiomIndex.Location = new Point(0, 31);
      this.lstIdiomIndex.Name = "lstIdiomIndex";
      this.lstIdiomIndex.Size = new Size(120, 110);
      this.lstIdiomIndex.TabIndex = 0;
      this.lstIdiomIndex.MouseUp += new MouseEventHandler(this.lstIdiomIndex_MouseUp);
      this.lstIdiomIndex.DoubleClick += new EventHandler(this.lstIdiomIndex_DoubleClick);
      this.lstIdiomIndex.MouseMove += new MouseEventHandler(this.lstIdiomIndex_MouseMove);
      this.lstIdiomIndex.MouseDown += new MouseEventHandler(this.lstIdiomIndex_MouseDown);
      this.lstIdiomIndex.SelectedValueChanged += new EventHandler(this.lstIdiomIndex_SelectedValueChanged);
      this.lstIdiomIndex.KeyDown += new KeyEventHandler(this.lstIdiomIndex_KeyDown);
      this.tlpIdiomControl.ColumnCount = 2;
      this.tlpIdiomControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tlpIdiomControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tlpIdiomControl.Controls.Add((Control) this.btnAddIdiom, 0, 0);
      this.tlpIdiomControl.Controls.Add((Control) this.btnModifyIdiom, 1, 0);
      this.tlpIdiomControl.Dock = DockStyle.Top;
      this.tlpIdiomControl.Location = new Point(0, 0);
      this.tlpIdiomControl.Name = "tlpIdiomControl";
      this.tlpIdiomControl.RowCount = 1;
      this.tlpIdiomControl.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tlpIdiomControl.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tlpIdiomControl.Size = new Size(120, 31);
      this.tlpIdiomControl.TabIndex = 1;
      this.btnAddIdiom.Dock = DockStyle.Fill;
      this.btnAddIdiom.Location = new Point(3, 3);
      this.btnAddIdiom.Name = "btnAddIdiom";
      this.btnAddIdiom.Size = new Size(54, 25);
      this.btnAddIdiom.TabIndex = 0;
      this.btnAddIdiom.TabStop = false;
      this.btnAddIdiom.Text = "追加...";
      this.btnAddIdiom.UseVisualStyleBackColor = true;
      this.btnAddIdiom.Click += new EventHandler(this.btnAddIdiom_Click);
      this.btnModifyIdiom.Dock = DockStyle.Fill;
      this.btnModifyIdiom.Location = new Point(63, 3);
      this.btnModifyIdiom.Name = "btnModifyIdiom";
      this.btnModifyIdiom.Size = new Size(54, 25);
      this.btnModifyIdiom.TabIndex = 1;
      this.btnModifyIdiom.TabStop = false;
      this.btnModifyIdiom.Text = "編集...";
      this.btnModifyIdiom.UseVisualStyleBackColor = true;
      this.btnModifyIdiom.Click += new EventHandler(this.btnModifyIdiom_Click);
      this.txtIdiomText.BackColor = Color.White;
      this.txtIdiomText.Dock = DockStyle.Fill;
      this.txtIdiomText.Font = new Font("ＭＳ ゴシック", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.txtIdiomText.Location = new Point(0, 0);
      this.txtIdiomText.Multiline = true;
      this.txtIdiomText.Name = "txtIdiomText";
      this.txtIdiomText.ReadOnly = true;
      this.txtIdiomText.ScrollBars = ScrollBars.Both;
      this.txtIdiomText.Size = new Size(326, 152);
      this.txtIdiomText.TabIndex = 0;
      this.txtIdiomText.WordWrap = false;
      this.txtIdiomText.KeyDown += new KeyEventHandler(this.txtIdiomText_KeyDown);
      this.txtIdiomText.Enter += new EventHandler(this.txtIdiomText_Enter);
      this.sptDebugHorizontal.Dock = DockStyle.Fill;
      this.sptDebugHorizontal.Location = new Point(0, 0);
      this.sptDebugHorizontal.Name = "sptDebugHorizontal";
      this.sptDebugHorizontal.Orientation = Orientation.Horizontal;
      this.sptDebugHorizontal.Panel1.Controls.Add((Control) this.dgvVarList);
      this.sptDebugHorizontal.Panel1.Controls.Add((Control) this.grpRunningCondition);
      this.sptDebugHorizontal.Panel2.Controls.Add((Control) this.lstInfo);
      this.sptDebugHorizontal.Panel2.Controls.Add((Control) this.grpTraceSetting);
      this.sptDebugHorizontal.Size = new Size(344, 530);
      this.sptDebugHorizontal.SplitterDistance = 251;
      this.sptDebugHorizontal.TabIndex = 0;
      this.sptDebugHorizontal.TabStop = false;
      this.dgvVarList.AllowUserToAddRows = false;
      this.dgvVarList.AllowUserToDeleteRows = false;
      this.dgvVarList.AllowUserToResizeRows = false;
      this.dgvVarList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvVarList.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = SystemColors.Control;
      gridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dgvVarList.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.dgvVarList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dgvVarList.Columns.AddRange((DataGridViewColumn) this.ColumnName, (DataGridViewColumn) this.ColumnValue);
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("ＭＳ ゴシック", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.dgvVarList.DefaultCellStyle = gridViewCellStyle2;
      this.dgvVarList.Dock = DockStyle.Fill;
      this.dgvVarList.Location = new Point(0, 70);
      this.dgvVarList.MultiSelect = false;
      this.dgvVarList.Name = "dgvVarList";
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle3.BackColor = SystemColors.Control;
      gridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      gridViewCellStyle3.ForeColor = SystemColors.WindowText;
      gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.dgvVarList.RowHeadersDefaultCellStyle = gridViewCellStyle3;
      this.dgvVarList.RowHeadersVisible = false;
      this.dgvVarList.RowTemplate.Height = 21;
      this.dgvVarList.SelectionMode = DataGridViewSelectionMode.CellSelect;
      this.dgvVarList.Size = new Size(344, 181);
      this.dgvVarList.TabIndex = 2;
      this.dgvVarList.CellValueChanged += new DataGridViewCellEventHandler(this.dgvVarList_CellValueChanged);
      this.dgvVarList.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dgvVarList_CellFormatting);
      this.ColumnName.FillWeight = 60f;
      this.ColumnName.HeaderText = "変数名";
      this.ColumnName.Name = "ColumnName";
      this.ColumnName.ReadOnly = true;
      this.ColumnValue.FillWeight = 120f;
      this.ColumnValue.HeaderText = "値";
      this.ColumnValue.Name = "ColumnValue";
      this.grpRunningCondition.Controls.Add((Control) this.txtWorkDir);
      this.grpRunningCondition.Controls.Add((Control) this.lblWorkDir);
      this.grpRunningCondition.Controls.Add((Control) this.txtArguments);
      this.grpRunningCondition.Controls.Add((Control) this.lblArguments);
      this.grpRunningCondition.Dock = DockStyle.Top;
      this.grpRunningCondition.Location = new Point(0, 0);
      this.grpRunningCondition.Name = "grpRunningCondition";
      this.grpRunningCondition.Size = new Size(344, 70);
      this.grpRunningCondition.TabIndex = 0;
      this.grpRunningCondition.TabStop = false;
      this.grpRunningCondition.Text = "実行条件";
      this.txtWorkDir.AllowDrop = true;
      this.txtWorkDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtWorkDir.Location = new Point(93, 39);
      this.txtWorkDir.Name = "txtWorkDir";
      this.txtWorkDir.Size = new Size(233, 19);
      this.txtWorkDir.TabIndex = 1;
      this.txtWorkDir.DragDrop += new DragEventHandler(this.txtWorkDir_DragDrop);
      this.txtWorkDir.DragEnter += new DragEventHandler(this.txtWorkDir_DragEnter);
      this.lblWorkDir.AutoSize = true;
      this.lblWorkDir.Location = new Point(17, 43);
      this.lblWorkDir.Name = "lblWorkDir";
      this.lblWorkDir.Size = new Size(64, 12);
      this.lblWorkDir.TabIndex = 2;
      this.lblWorkDir.Text = "作業フォルダ";
      this.txtArguments.AllowDrop = true;
      this.txtArguments.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtArguments.Location = new Point(93, 15);
      this.txtArguments.Name = "txtArguments";
      this.txtArguments.Size = new Size(233, 19);
      this.txtArguments.TabIndex = 0;
      this.txtArguments.DragDrop += new DragEventHandler(this.txtArguments_DragDrop);
      this.txtArguments.DragEnter += new DragEventHandler(this.txtArguments_DragEnter);
      this.lblArguments.AutoSize = true;
      this.lblArguments.Location = new Point(17, 19);
      this.lblArguments.Name = "lblArguments";
      this.lblArguments.Size = new Size(29, 12);
      this.lblArguments.TabIndex = 0;
      this.lblArguments.Text = "引数";
      this.lstInfo.Dock = DockStyle.Fill;
      this.lstInfo.Font = new Font("ＭＳ ゴシック", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lstInfo.FormattingEnabled = true;
      this.lstInfo.HorizontalScrollbar = true;
      this.lstInfo.ItemHeight = 12;
      this.lstInfo.Location = new Point(0, 59);
      this.lstInfo.Name = "lstInfo";
      this.lstInfo.Size = new Size(344, 208);
      this.lstInfo.TabIndex = 1;
      this.lstInfo.SelectedIndexChanged += new EventHandler(this.lstInfo_SelectedIndexChanged);
      this.grpTraceSetting.Controls.Add((Control) this.lblFilter);
      this.grpTraceSetting.Controls.Add((Control) this.txtFilter);
      this.grpTraceSetting.Controls.Add((Control) this.chkExpandVar);
      this.grpTraceSetting.Controls.Add((Control) this.chkShowErrorLevel);
      this.grpTraceSetting.Controls.Add((Control) this.chkShowTime);
      this.grpTraceSetting.Dock = DockStyle.Top;
      this.grpTraceSetting.Location = new Point(0, 0);
      this.grpTraceSetting.Name = "grpTraceSetting";
      this.grpTraceSetting.Size = new Size(344, 59);
      this.grpTraceSetting.TabIndex = 0;
      this.grpTraceSetting.TabStop = false;
      this.grpTraceSetting.Text = "トレース設定";
      this.lblFilter.AutoSize = true;
      this.lblFilter.Location = new Point(12, 39);
      this.lblFilter.Name = "lblFilter";
      this.lblFilter.Size = new Size(54, 12);
      this.lblFilter.TabIndex = 4;
      this.lblFilter.Text = "フィルター：";
      this.txtFilter.Font = new Font("ＭＳ ゴシック", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtFilter.Location = new Point(71, 36);
      this.txtFilter.Name = "txtFilter";
      this.txtFilter.Size = new Size(128, 19);
      this.txtFilter.TabIndex = 3;
      this.txtFilter.TextChanged += new EventHandler(this.txtFilter_TextChanged);
      this.chkExpandVar.AutoSize = true;
      this.chkExpandVar.Checked = true;
      this.chkExpandVar.CheckState = CheckState.Checked;
      this.chkExpandVar.Location = new Point(203, 17);
      this.chkExpandVar.Name = "chkExpandVar";
      this.chkExpandVar.Size = new Size(81, 16);
      this.chkExpandVar.TabIndex = 2;
      this.chkExpandVar.Text = "変数を展開";
      this.chkExpandVar.UseVisualStyleBackColor = true;
      this.chkExpandVar.CheckedChanged += new EventHandler(this.chkExpandVar_CheckedChanged);
      this.chkShowErrorLevel.AutoSize = true;
      this.chkShowErrorLevel.Checked = true;
      this.chkShowErrorLevel.CheckState = CheckState.Checked;
      this.chkShowErrorLevel.Location = new Point(97, 17);
      this.chkShowErrorLevel.Name = "chkShowErrorLevel";
      this.chkShowErrorLevel.Size = new Size(105, 16);
      this.chkShowErrorLevel.TabIndex = 1;
      this.chkShowErrorLevel.Text = "errorlevelを表示";
      this.chkShowErrorLevel.UseVisualStyleBackColor = true;
      this.chkShowErrorLevel.CheckedChanged += new EventHandler(this.chkShowErrorLevel_CheckedChanged);
      this.chkShowTime.AutoSize = true;
      this.chkShowTime.Checked = true;
      this.chkShowTime.CheckState = CheckState.Checked;
      this.chkShowTime.Location = new Point(10, 17);
      this.chkShowTime.Name = "chkShowTime";
      this.chkShowTime.Size = new Size(81, 16);
      this.chkShowTime.TabIndex = 0;
      this.chkShowTime.Text = "時刻を表示";
      this.chkShowTime.UseVisualStyleBackColor = true;
      this.chkShowTime.CheckedChanged += new EventHandler(this.chkShowTime_CheckedChanged);
      this.stsMain.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.tslTopMost,
        (ToolStripItem) this.tslRunningState,
        (ToolStripItem) this.tslBreakState
      });
      this.stsMain.Location = new Point(0, 581);
      this.stsMain.Name = "stsMain";
      this.stsMain.Size = new Size(802, 22);
      this.stsMain.TabIndex = 4;
      this.tslTopMost.Name = "tslTopMost";
      this.tslTopMost.Size = new Size(0, 17);
      this.tslRunningState.Name = "tslRunningState";
      this.tslRunningState.Size = new Size(0, 17);
      this.tslBreakState.Name = "tslBreakState";
      this.tslBreakState.Size = new Size(0, 17);
      this.mnuMain.Items.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this.mniFile,
        (ToolStripItem) this.mniEdit,
        (ToolStripItem) this.mniView,
        (ToolStripItem) this.mniSearch,
        (ToolStripItem) this.mniExecute,
        (ToolStripItem) this.mniDebug,
        (ToolStripItem) this.mniBuild,
        (ToolStripItem) this.mniSetting,
        (ToolStripItem) this.mniHelp
      });
      this.mnuMain.Location = new Point(0, 0);
      this.mnuMain.Name = "mnuMain";
      this.mnuMain.Size = new Size(802, 26);
      this.mnuMain.TabIndex = 0;
      this.mnuMain.Text = "menuStrip1";
      this.mniFile.DropDownItems.AddRange(new ToolStripItem[12]
      {
        (ToolStripItem) this.mniFileNew,
        (ToolStripItem) this.mniFileOpen,
        (ToolStripItem) this.toolStripMenuItem7,
        (ToolStripItem) this.mniFileReload,
        (ToolStripItem) this.toolStripMenuItem4,
        (ToolStripItem) this.mniFileSave,
        (ToolStripItem) this.mniFileSaveWithName,
        (ToolStripItem) this.toolStripMenuItem5,
        (ToolStripItem) this.mniFileOpenDirOnEditFile,
        (ToolStripItem) this.mniFileOpenWorkDir,
        (ToolStripItem) this.toolStripMenuItem6,
        (ToolStripItem) this.mniFileExit
      });
      this.mniFile.Name = "mniFile";
      this.mniFile.Size = new Size(85, 22);
      this.mniFile.Text = "ファイル(&F)";
      this.mniFile.DropDownOpening += new EventHandler(this.mniFile_DropDownOpening);
      this.mniFileNew.Name = "mniFileNew";
      this.mniFileNew.ShortcutKeyDisplayString = "";
      this.mniFileNew.ShortcutKeys = Keys.N | Keys.Control;
      this.mniFileNew.Size = new Size(356, 22);
      this.mniFileNew.Text = "新規作成(&N)";
      this.mniFileNew.Click += new EventHandler(this.mniFileNew_Click);
      this.mniFileOpen.Name = "mniFileOpen";
      this.mniFileOpen.ShortcutKeys = Keys.O | Keys.Control;
      this.mniFileOpen.Size = new Size(356, 22);
      this.mniFileOpen.Text = "開く(&O)...";
      this.mniFileOpen.Click += new EventHandler(this.mniFileOpen_Click);
      this.toolStripMenuItem7.Name = "toolStripMenuItem7";
      this.toolStripMenuItem7.Size = new Size(353, 6);
      this.mniFileReload.Name = "mniFileReload";
      this.mniFileReload.ShortcutKeys = Keys.L | Keys.Control;
      this.mniFileReload.Size = new Size(356, 22);
      this.mniFileReload.Text = "再読み込み(&L)";
      this.mniFileReload.Click += new EventHandler(this.mniFileReload_Click);
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new Size(353, 6);
      this.mniFileSave.Name = "mniFileSave";
      this.mniFileSave.ShortcutKeys = Keys.S | Keys.Control;
      this.mniFileSave.Size = new Size(356, 22);
      this.mniFileSave.Text = "保存(&S)";
      this.mniFileSave.Click += new EventHandler(this.mniFileSave_Click);
      this.mniFileSaveWithName.Name = "mniFileSaveWithName";
      this.mniFileSaveWithName.ShortcutKeys = Keys.S | Keys.Shift | Keys.Control;
      this.mniFileSaveWithName.Size = new Size(356, 22);
      this.mniFileSaveWithName.Text = "名前を付けて保存(&A)...";
      this.mniFileSaveWithName.Click += new EventHandler(this.mniFileSaveWithName_Click);
      this.toolStripMenuItem5.Name = "toolStripMenuItem5";
      this.toolStripMenuItem5.Size = new Size(353, 6);
      this.mniFileOpenDirOnEditFile.Name = "mniFileOpenDirOnEditFile";
      this.mniFileOpenDirOnEditFile.ShortcutKeys = Keys.E | Keys.Shift | Keys.Control;
      this.mniFileOpenDirOnEditFile.Size = new Size(356, 22);
      this.mniFileOpenDirOnEditFile.Text = "編集中ファイルのフォルダを開く(&E)";
      this.mniFileOpenDirOnEditFile.Click += new EventHandler(this.mniFileOpenDirOnEditFile_Click);
      this.mniFileOpenWorkDir.Name = "mniFileOpenWorkDir";
      this.mniFileOpenWorkDir.ShortcutKeys = Keys.W | Keys.Shift | Keys.Control;
      this.mniFileOpenWorkDir.Size = new Size(356, 22);
      this.mniFileOpenWorkDir.Text = "作業フォルダを開く(&W)";
      this.mniFileOpenWorkDir.Click += new EventHandler(this.mniFileOpenWorkDir_Click);
      this.toolStripMenuItem6.Name = "toolStripMenuItem6";
      this.toolStripMenuItem6.Size = new Size(353, 6);
      this.mniFileExit.Name = "mniFileExit";
      this.mniFileExit.ShortcutKeys = Keys.Q | Keys.Control;
      this.mniFileExit.Size = new Size(356, 22);
      this.mniFileExit.Text = "終了(&X)";
      this.mniFileExit.Click += new EventHandler(this.mniFileExit_Click);
      this.mniEdit.DropDownItems.AddRange(new ToolStripItem[11]
      {
        (ToolStripItem) this.mniEditCloseTab,
        (ToolStripItem) this.toolStripMenuItem3,
        (ToolStripItem) this.mniEditUndo,
        (ToolStripItem) this.mniEditRedo,
        (ToolStripItem) this.tsmEditSeparate,
        (ToolStripItem) this.mniEditCut,
        (ToolStripItem) this.mniEditCopy,
        (ToolStripItem) this.mniEditPaste,
        (ToolStripItem) this.mniEditDel,
        (ToolStripItem) this.toolStripMenuItem1,
        (ToolStripItem) this.mniEditAddIdiom
      });
      this.mniEdit.Name = "mniEdit";
      this.mniEdit.Size = new Size(61, 22);
      this.mniEdit.Text = "編集(&E)";
      this.mniEdit.DropDownOpening += new EventHandler(this.mniEdit_DropDownOpening);
      this.mniEditCloseTab.Name = "mniEditCloseTab";
      this.mniEditCloseTab.ShortcutKeys = Keys.W | Keys.Control;
      this.mniEditCloseTab.Size = new Size(266, 22);
      this.mniEditCloseTab.Text = "選択中のタブを閉じる(&Q)";
      this.mniEditCloseTab.Click += new EventHandler(this.mniEditCloseTab_Click);
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new Size(263, 6);
      this.mniEditUndo.Name = "mniEditUndo";
      this.mniEditUndo.ShortcutKeyDisplayString = "Ctrl+Z";
      this.mniEditUndo.Size = new Size(266, 22);
      this.mniEditUndo.Text = "元に戻す(&U)";
      this.mniEditUndo.Click += new EventHandler(this.mniEditUndo_Click);
      this.mniEditRedo.Name = "mniEditRedo";
      this.mniEditRedo.ShortcutKeyDisplayString = "Ctrl+Y";
      this.mniEditRedo.Size = new Size(266, 22);
      this.mniEditRedo.Text = "やり直し(&R)";
      this.mniEditRedo.Click += new EventHandler(this.mniEditRedo_Click);
      this.tsmEditSeparate.Name = "tsmEditSeparate";
      this.tsmEditSeparate.Size = new Size(263, 6);
      this.mniEditCut.Name = "mniEditCut";
      this.mniEditCut.ShortcutKeyDisplayString = "Ctrl+X";
      this.mniEditCut.Size = new Size(266, 22);
      this.mniEditCut.Text = "切り取り(&T)";
      this.mniEditCut.Click += new EventHandler(this.mniEditCut_Click);
      this.mniEditCopy.Name = "mniEditCopy";
      this.mniEditCopy.ShortcutKeyDisplayString = "Ctrl+C";
      this.mniEditCopy.Size = new Size(266, 22);
      this.mniEditCopy.Text = "コピー(&C)";
      this.mniEditCopy.Click += new EventHandler(this.mniEditCopy_Click);
      this.mniEditPaste.Name = "mniEditPaste";
      this.mniEditPaste.ShortcutKeyDisplayString = "Ctrl+P";
      this.mniEditPaste.Size = new Size(266, 22);
      this.mniEditPaste.Text = "貼り付け(&P)";
      this.mniEditPaste.Click += new EventHandler(this.mniEditPaste_Click);
      this.mniEditDel.Name = "mniEditDel";
      this.mniEditDel.ShortcutKeyDisplayString = "Del";
      this.mniEditDel.Size = new Size(266, 22);
      this.mniEditDel.Text = "削除(&D)";
      this.mniEditDel.Click += new EventHandler(this.mniEditDel_Click);
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new Size(263, 6);
      this.mniEditAddIdiom.Name = "mniEditAddIdiom";
      this.mniEditAddIdiom.ShortcutKeys = Keys.I | Keys.Control;
      this.mniEditAddIdiom.Size = new Size(266, 22);
      this.mniEditAddIdiom.Text = "イディオム登録(&I)...";
      this.mniEditAddIdiom.Click += new EventHandler(this.mniCtxEditAddIdiom_Click);
      this.mniView.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.mniViewToolBox,
        (ToolStripItem) this.mniViewIdiom,
        (ToolStripItem) this.mniViewCommandReference,
        (ToolStripItem) this.mniViewTopMost
      });
      this.mniView.Name = "mniView";
      this.mniView.Size = new Size(62, 22);
      this.mniView.Text = "表示(&V)";
      this.mniView.DropDownOpening += new EventHandler(this.mniView_DropDownOpening);
      this.mniViewToolBox.Checked = true;
      this.mniViewToolBox.CheckOnClick = true;
      this.mniViewToolBox.CheckState = CheckState.Checked;
      this.mniViewToolBox.Name = "mniViewToolBox";
      this.mniViewToolBox.ShortcutKeys = Keys.F1 | Keys.Control;
      this.mniViewToolBox.Size = new Size(273, 22);
      this.mniViewToolBox.Text = "ツールボックス(&T)";
      this.mniViewToolBox.Click += new EventHandler(this.mniViewToolBox_Click);
      this.mniViewIdiom.Checked = true;
      this.mniViewIdiom.CheckOnClick = true;
      this.mniViewIdiom.CheckState = CheckState.Checked;
      this.mniViewIdiom.Name = "mniViewIdiom";
      this.mniViewIdiom.ShortcutKeys = Keys.F2 | Keys.Control;
      this.mniViewIdiom.Size = new Size(273, 22);
      this.mniViewIdiom.Text = "イディオム(&I)";
      this.mniViewIdiom.Click += new EventHandler(this.mniViewIdiom_Click);
      this.mniViewCommandReference.Name = "mniViewCommandReference";
      this.mniViewCommandReference.ShortcutKeys = Keys.B | Keys.Control;
      this.mniViewCommandReference.Size = new Size(273, 22);
      this.mniViewCommandReference.Text = "コマンドリファレンス(&C)...";
      this.mniViewCommandReference.Click += new EventHandler(this.mniViewCommandReference_Click);
      this.mniViewTopMost.CheckOnClick = true;
      this.mniViewTopMost.Name = "mniViewTopMost";
      this.mniViewTopMost.ShortcutKeys = Keys.K | Keys.Control;
      this.mniViewTopMost.Size = new Size(273, 22);
      this.mniViewTopMost.Text = "常に手前に表示(&K)";
      this.mniViewTopMost.CheckedChanged += new EventHandler(this.mniViewTopMost_CheckedChanged);
      this.mniSearch.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.mniSearchFind,
        (ToolStripItem) this.mniSearchReplace
      });
      this.mniSearch.Name = "mniSearch";
      this.mniSearch.Size = new Size(62, 22);
      this.mniSearch.Text = "検索(&S)";
      this.mniSearch.DropDownOpening += new EventHandler(this.mniSearch_DropDownOpening);
      this.mniSearchFind.Name = "mniSearchFind";
      this.mniSearchFind.ShortcutKeys = Keys.F | Keys.Control;
      this.mniSearchFind.Size = new Size(177, 22);
      this.mniSearchFind.Text = "検索(&F)...";
      this.mniSearchFind.Click += new EventHandler(this.mniSearchFind_Click);
      this.mniSearchReplace.Name = "mniSearchReplace";
      this.mniSearchReplace.ShortcutKeys = Keys.R | Keys.Control;
      this.mniSearchReplace.Size = new Size(177, 22);
      this.mniSearchReplace.Text = "置換(&R)...";
      this.mniSearchReplace.Click += new EventHandler(this.mniSearchReplace_Click);
      this.mniExecute.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.mniExeRun,
        (ToolStripItem) this.mniExeRunWD,
        (ToolStripItem) this.mniExeStop
      });
      this.mniExecute.Name = "mniExecute";
      this.mniExecute.Size = new Size(62, 22);
      this.mniExecute.Text = "実行(&R)";
      this.mniExecute.DropDownOpening += new EventHandler(this.mniExecute_DropDownOpening);
      this.mniExeRun.Name = "mniExeRun";
      this.mniExeRun.ShortcutKeyDisplayString = "";
      this.mniExeRun.ShortcutKeys = Keys.F5;
      this.mniExeRun.Size = new Size(259, 22);
      this.mniExeRun.Text = "実行(&R)";
      this.mniExeRun.Click += new EventHandler(this.mniExeRun_Click);
      this.mniExeRunWD.Name = "mniExeRunWD";
      this.mniExeRunWD.ShortcutKeys = Keys.F5 | Keys.Control;
      this.mniExeRunWD.Size = new Size(259, 22);
      this.mniExeRunWD.Text = "デバッグなしで実行(&W)";
      this.mniExeRunWD.Click += new EventHandler(this.mniExeRunWD_Click);
      this.mniExeStop.Name = "mniExeStop";
      this.mniExeStop.ShortcutKeys = Keys.F5 | Keys.Shift;
      this.mniExeStop.Size = new Size(259, 22);
      this.mniExeStop.Text = "停止(&S)";
      this.mniExeStop.Click += new EventHandler(this.mniExeStop_Click);
      this.mniDebug.DropDownItems.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.mniDebugContinue,
        (ToolStripItem) this.mniDebugPause,
        (ToolStripItem) this.mniDebugStep,
        (ToolStripItem) this.tsmDebugSeparate,
        (ToolStripItem) this.mniDebugInterruptCmd,
        (ToolStripItem) this.toolStripMenuItem2,
        (ToolStripItem) this.mniDebugToggleBP,
        (ToolStripItem) this.mniDebugClearBP
      });
      this.mniDebug.Name = "mniDebug";
      this.mniDebug.Size = new Size(87, 22);
      this.mniDebug.Text = "デバッグ(&D)";
      this.mniDebug.DropDownOpening += new EventHandler(this.mniDebug_DropDownOpening);
      this.mniDebugContinue.Name = "mniDebugContinue";
      this.mniDebugContinue.ShortcutKeys = Keys.F9;
      this.mniDebugContinue.Size = new Size(329, 22);
      this.mniDebugContinue.Text = "続行(&C)";
      this.mniDebugContinue.Click += new EventHandler(this.mniDebugContinue_Click);
      this.mniDebugPause.Name = "mniDebugPause";
      this.mniDebugPause.ShortcutKeys = Keys.F9 | Keys.Shift;
      this.mniDebugPause.Size = new Size(329, 22);
      this.mniDebugPause.Text = "中断(&P)";
      this.mniDebugPause.Click += new EventHandler(this.mniDebugPause_Click);
      this.mniDebugStep.Name = "mniDebugStep";
      this.mniDebugStep.ShortcutKeys = Keys.F8;
      this.mniDebugStep.Size = new Size(329, 22);
      this.mniDebugStep.Text = "ステップ(&O)";
      this.mniDebugStep.Click += new EventHandler(this.mniDebugStep_Click);
      this.tsmDebugSeparate.Name = "tsmDebugSeparate";
      this.tsmDebugSeparate.Size = new Size(326, 6);
      this.mniDebugInterruptCmd.Name = "mniDebugInterruptCmd";
      this.mniDebugInterruptCmd.ShortcutKeys = Keys.M | Keys.Control;
      this.mniDebugInterruptCmd.Size = new Size(329, 22);
      this.mniDebugInterruptCmd.Text = "コマンド割り込み実行(&R)...";
      this.mniDebugInterruptCmd.Click += new EventHandler(this.mniDebugInterruptCmd_Click);
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new Size(326, 6);
      this.mniDebugToggleBP.Name = "mniDebugToggleBP";
      this.mniDebugToggleBP.ShortcutKeys = Keys.F2;
      this.mniDebugToggleBP.Size = new Size(329, 22);
      this.mniDebugToggleBP.Text = "ブレークポイントの設定/解除(&T)";
      this.mniDebugToggleBP.Click += new EventHandler(this.mniDebugToggleBP_Click);
      this.mniDebugClearBP.Name = "mniDebugClearBP";
      this.mniDebugClearBP.ShortcutKeys = Keys.F2 | Keys.Shift | Keys.Control;
      this.mniDebugClearBP.Size = new Size(329, 22);
      this.mniDebugClearBP.Text = "ブレークポイントの全解除(&Q)";
      this.mniDebugClearBP.Click += new EventHandler(this.mniDebugClearBP_Click);
      this.mniBuild.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.mniBuildToExe,
        (ToolStripItem) this.mniBuildToExeNoConsole
      });
      this.mniBuild.Name = "mniBuild";
      this.mniBuild.Size = new Size(74, 22);
      this.mniBuild.Text = "ビルド(&B)";
      this.mniBuild.DropDownOpening += new EventHandler(this.mniBuild_DropDownOpening);
      this.mniBuildToExe.Name = "mniBuildToExe";
      this.mniBuildToExe.ShortcutKeys = Keys.F6;
      this.mniBuildToExe.Size = new Size(244, 22);
      this.mniBuildToExe.Text = "exe化(&E)";
      this.mniBuildToExe.Click += new EventHandler(this.mniBuildToExe_Click);
      this.mniBuildToExeNoConsole.Name = "mniBuildToExeNoConsole";
      this.mniBuildToExeNoConsole.ShortcutKeys = Keys.F7;
      this.mniBuildToExeNoConsole.Size = new Size(244, 22);
      this.mniBuildToExeNoConsole.Text = "exe化(Console非表示)(&W)";
      this.mniBuildToExeNoConsole.Click += new EventHandler(this.mniBuildToExeNoConsole_Click);
      this.mniSetting.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.mniSettingOption
      });
      this.mniSetting.Name = "mniSetting";
      this.mniSetting.ShortcutKeys = Keys.T | Keys.Control;
      this.mniSetting.Size = new Size(62, 22);
      this.mniSetting.Text = "設定(&S)";
      this.mniSetting.DropDownOpening += new EventHandler(this.mniSetting_DropDownOpening);
      this.mniSettingOption.Name = "mniSettingOption";
      this.mniSettingOption.ShortcutKeys = Keys.D | Keys.Control;
      this.mniSettingOption.Size = new Size(215, 22);
      this.mniSettingOption.Text = "オプション(&O)...";
      this.mniSettingOption.Click += new EventHandler(this.mniSettingOption_Click);
      this.mniHelp.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.mniHelpVersion
      });
      this.mniHelp.Name = "mniHelp";
      this.mniHelp.Size = new Size(75, 22);
      this.mniHelp.Text = "ヘルプ(&H)";
      this.mniHelp.DropDownOpening += new EventHandler(this.mniHelp_DropDownOpening);
      this.mniHelpVersion.Name = "mniHelpVersion";
      this.mniHelpVersion.ShortcutKeys = Keys.F1 | Keys.Shift;
      this.mniHelpVersion.Size = new Size(249, 22);
      this.mniHelpVersion.Text = "バージョン情報(&A)...";
      this.mniHelpVersion.Click += new EventHandler(this.mniHelpVersion_Click);
      this.pnlRight.Dock = DockStyle.Right;
      this.pnlRight.Location = new Point(798, 26);
      this.pnlRight.Name = "pnlRight";
      this.pnlRight.Size = new Size(4, 555);
      this.pnlRight.TabIndex = 6;
      this.ofdEdit.DefaultExt = "bat";
      this.ofdEdit.Filter = "batファイル|*.bat;*.cmd|すべてのファイル|*.*";
      this.ofdEdit.SupportMultiDottedExtensions = true;
      this.ofdEdit.Title = "batファイルの選択";
      this.sfdEdit.DefaultExt = "bat";
      this.sfdEdit.Filter = "batファイル|*.bat|すべてのファイル|*.*";
      this.sfdEdit.SupportMultiDottedExtensions = true;
      this.sfdEdit.Title = "名前を付けて保存";
      this.timWatchBreak.Interval = 50;
      this.timWatchBreak.Tick += new EventHandler(this.timWatchBreak_Tick);
      this.sfdBuild.DefaultExt = "exe";
      this.sfdBuild.Filter = "exeファイル|*.exe";
      this.sfdBuild.OverwritePrompt = false;
      this.sfdBuild.Title = "exeファイル作成";
      this.cmsEdit.Items.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this.mniCtxEditUndo,
        (ToolStripItem) this.mniCtxEditRedo,
        (ToolStripItem) this.tsmCtxEditSeparator1,
        (ToolStripItem) this.mniCtxEditCut,
        (ToolStripItem) this.mniCtxEditCopy,
        (ToolStripItem) this.mniCtxEditPaste,
        (ToolStripItem) this.mniCtxEditDelete,
        (ToolStripItem) this.tsmCtxEditSeparator2,
        (ToolStripItem) this.mniCtxEditAddIdiom
      });
      this.cmsEdit.Name = "cmsEdit";
      this.cmsEdit.Size = new Size(188, 170);
      this.cmsEdit.Opening += new CancelEventHandler(this.cmsEdit_Opening);
      this.mniCtxEditUndo.Name = "mniCtxEditUndo";
      this.mniCtxEditUndo.Size = new Size(187, 22);
      this.mniCtxEditUndo.Text = "元に戻す(&U)";
      this.mniCtxEditUndo.Click += new EventHandler(this.mniEditUndo_Click);
      this.mniCtxEditRedo.Name = "mniCtxEditRedo";
      this.mniCtxEditRedo.Size = new Size(187, 22);
      this.mniCtxEditRedo.Text = "やり直し(&R)";
      this.mniCtxEditRedo.Click += new EventHandler(this.mniEditRedo_Click);
      this.tsmCtxEditSeparator1.Name = "tsmCtxEditSeparator1";
      this.tsmCtxEditSeparator1.Size = new Size(184, 6);
      this.mniCtxEditCut.Name = "mniCtxEditCut";
      this.mniCtxEditCut.Size = new Size(187, 22);
      this.mniCtxEditCut.Text = "切り取り(&T)";
      this.mniCtxEditCut.Click += new EventHandler(this.mniEditCut_Click);
      this.mniCtxEditCopy.Name = "mniCtxEditCopy";
      this.mniCtxEditCopy.Size = new Size(187, 22);
      this.mniCtxEditCopy.Text = "コピー(&C)";
      this.mniCtxEditCopy.Click += new EventHandler(this.mniEditCopy_Click);
      this.mniCtxEditPaste.Name = "mniCtxEditPaste";
      this.mniCtxEditPaste.Size = new Size(187, 22);
      this.mniCtxEditPaste.Text = "貼り付け(&P)";
      this.mniCtxEditPaste.Click += new EventHandler(this.mniEditPaste_Click);
      this.mniCtxEditDelete.Name = "mniCtxEditDelete";
      this.mniCtxEditDelete.Size = new Size(187, 22);
      this.mniCtxEditDelete.Text = "削除(&D)";
      this.mniCtxEditDelete.Click += new EventHandler(this.mniEditDel_Click);
      this.tsmCtxEditSeparator2.Name = "tsmCtxEditSeparator2";
      this.tsmCtxEditSeparator2.Size = new Size(184, 6);
      this.mniCtxEditAddIdiom.Name = "mniCtxEditAddIdiom";
      this.mniCtxEditAddIdiom.Size = new Size(187, 22);
      this.mniCtxEditAddIdiom.Text = "イディオム登録(&I)...";
      this.mniCtxEditAddIdiom.Click += new EventHandler(this.mniCtxEditAddIdiom_Click);
      this.tipIdiomName.AutoPopDelay = 10000;
      this.tipIdiomName.InitialDelay = 0;
      this.tipIdiomName.ReshowDelay = 100;
      this.cmsIdiomIndex.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.mniCtxIdiomIndexInsert,
        (ToolStripItem) this.mniCtxIdiomIndexModify,
        (ToolStripItem) this.mniCtxIdiomIndexDelete
      });
      this.cmsIdiomIndex.Name = "cmsIdiomIndex";
      this.cmsIdiomIndex.Size = new Size(200, 70);
      this.cmsIdiomIndex.Opening += new CancelEventHandler(this.cmsIdiomIndex_Opening);
      this.mniCtxIdiomIndexInsert.Name = "mniCtxIdiomIndexInsert";
      this.mniCtxIdiomIndexInsert.ShortcutKeyDisplayString = "Enter";
      this.mniCtxIdiomIndexInsert.Size = new Size(199, 22);
      this.mniCtxIdiomIndexInsert.Text = "挿入(&I)";
      this.mniCtxIdiomIndexInsert.Click += new EventHandler(this.mniCtxIdiomIndexInsert_Click);
      this.mniCtxIdiomIndexModify.Name = "mniCtxIdiomIndexModify";
      this.mniCtxIdiomIndexModify.ShortcutKeyDisplayString = "Ctrl+Enter";
      this.mniCtxIdiomIndexModify.Size = new Size(199, 22);
      this.mniCtxIdiomIndexModify.Text = "編集(&E)...";
      this.mniCtxIdiomIndexModify.Click += new EventHandler(this.mniCtxIdiomIndexModify_Click);
      this.mniCtxIdiomIndexDelete.Name = "mniCtxIdiomIndexDelete";
      this.mniCtxIdiomIndexDelete.ShortcutKeyDisplayString = "Del";
      this.mniCtxIdiomIndexDelete.Size = new Size(199, 22);
      this.mniCtxIdiomIndexDelete.Text = "削除(&D)";
      this.mniCtxIdiomIndexDelete.Click += new EventHandler(this.mniCtxIdiomIndexDelete_Click);
      this.sptRoot.Dock = DockStyle.Fill;
      this.sptRoot.FixedPanel = FixedPanel.Panel1;
      this.sptRoot.IsSplitterFixed = true;
      this.sptRoot.Location = new Point(0, 26);
      this.sptRoot.Margin = new Padding(0);
      this.sptRoot.Name = "sptRoot";
      this.sptRoot.Orientation = Orientation.Horizontal;
      this.sptRoot.Panel1.Controls.Add((Control) this.tstToolBox);
      this.sptRoot.Panel1MinSize = 1;
      this.sptRoot.Panel2.Controls.Add((Control) this.sptMainVertical);
      this.sptRoot.Size = new Size(798, 555);
      this.sptRoot.SplitterDistance = 23;
      this.sptRoot.SplitterWidth = 2;
      this.sptRoot.TabIndex = 1;
      this.sptRoot.TabStop = false;
      this.tstToolBox.CanOverflow = false;
      this.tstToolBox.Dock = DockStyle.Fill;
      this.tstToolBox.Items.AddRange(new ToolStripItem[19]
      {
        (ToolStripItem) this.tsbToolBoxNew,
        (ToolStripItem) this.tsbToolBoxOpen,
        (ToolStripItem) this.tsbToolBoxSave,
        (ToolStripItem) this.tsbToolBoxSaveNamed,
        (ToolStripItem) this.tssToolBoxSeparator1,
        (ToolStripItem) this.tsbToolBoxUndo,
        (ToolStripItem) this.tsbToolBoxRedo,
        (ToolStripItem) this.tssToolBoxSeparator2,
        (ToolStripItem) this.tsbToolBoxRun,
        (ToolStripItem) this.tsbToolBoxPause,
        (ToolStripItem) this.tsbToolBoxStop,
        (ToolStripItem) this.tssToolBoxSeparator3,
        (ToolStripItem) this.tsbToolBoxContinue,
        (ToolStripItem) this.tsbToolBoxStep,
        (ToolStripItem) this.tssToolBoxSeparator4,
        (ToolStripItem) this.tsbToolBoxBuild,
        (ToolStripItem) this.tsbToolBoxBuildNoConsole,
        (ToolStripItem) this.tssToolBoxSeparator5,
        (ToolStripItem) this.tsbToolBoxOption
      });
      this.tstToolBox.LayoutStyle = ToolStripLayoutStyle.Flow;
      this.tstToolBox.Location = new Point(0, 0);
      this.tstToolBox.Name = "tstToolBox";
      this.tstToolBox.Size = new Size(798, 23);
      this.tstToolBox.TabIndex = 5;
      this.tsbToolBoxNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbToolBoxNew.Image = (Image) componentResourceManager.GetObject("tsbToolBoxNew.Image");
      this.tsbToolBoxNew.ImageTransparentColor = Color.Magenta;
      this.tsbToolBoxNew.Name = "tsbToolBoxNew";
      this.tsbToolBoxNew.Size = new Size(23, 20);
      this.tsbToolBoxNew.Text = "新規作成";
      this.tsbToolBoxNew.Click += new EventHandler(this.mniFileNew_Click);
      this.tsbToolBoxOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbToolBoxOpen.Image = (Image) componentResourceManager.GetObject("tsbToolBoxOpen.Image");
      this.tsbToolBoxOpen.ImageTransparentColor = Color.Magenta;
      this.tsbToolBoxOpen.Name = "tsbToolBoxOpen";
      this.tsbToolBoxOpen.Size = new Size(23, 20);
      this.tsbToolBoxOpen.Text = "開く";
      this.tsbToolBoxOpen.Click += new EventHandler(this.mniFileOpen_Click);
      this.tsbToolBoxSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbToolBoxSave.Image = (Image) componentResourceManager.GetObject("tsbToolBoxSave.Image");
      this.tsbToolBoxSave.ImageTransparentColor = Color.Magenta;
      this.tsbToolBoxSave.Name = "tsbToolBoxSave";
      this.tsbToolBoxSave.Size = new Size(23, 20);
      this.tsbToolBoxSave.Text = "保存";
      this.tsbToolBoxSave.Click += new EventHandler(this.mniFileSave_Click);
      this.tsbToolBoxSaveNamed.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbToolBoxSaveNamed.Image = (Image) componentResourceManager.GetObject("tsbToolBoxSaveNamed.Image");
      this.tsbToolBoxSaveNamed.ImageTransparentColor = Color.Magenta;
      this.tsbToolBoxSaveNamed.Name = "tsbToolBoxSaveNamed";
      this.tsbToolBoxSaveNamed.Size = new Size(23, 20);
      this.tsbToolBoxSaveNamed.Text = "名前を付けて保存";
      this.tsbToolBoxSaveNamed.Click += new EventHandler(this.mniFileSaveWithName_Click);
      this.tssToolBoxSeparator1.Name = "tssToolBoxSeparator1";
      this.tssToolBoxSeparator1.Size = new Size(6, 23);
      this.tsbToolBoxUndo.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbToolBoxUndo.Image = (Image) componentResourceManager.GetObject("tsbToolBoxUndo.Image");
      this.tsbToolBoxUndo.ImageTransparentColor = Color.White;
      this.tsbToolBoxUndo.Name = "tsbToolBoxUndo";
      this.tsbToolBoxUndo.Size = new Size(23, 20);
      this.tsbToolBoxUndo.Text = "元に戻す";
      this.tsbToolBoxUndo.Click += new EventHandler(this.mniEditUndo_Click);
      this.tsbToolBoxRedo.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbToolBoxRedo.Image = (Image) componentResourceManager.GetObject("tsbToolBoxRedo.Image");
      this.tsbToolBoxRedo.ImageTransparentColor = Color.Magenta;
      this.tsbToolBoxRedo.Name = "tsbToolBoxRedo";
      this.tsbToolBoxRedo.Size = new Size(23, 20);
      this.tsbToolBoxRedo.Text = "やり直し";
      this.tsbToolBoxRedo.Click += new EventHandler(this.mniEditRedo_Click);
      this.tssToolBoxSeparator2.Name = "tssToolBoxSeparator2";
      this.tssToolBoxSeparator2.Size = new Size(6, 23);
      this.tsbToolBoxRun.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbToolBoxRun.Image = (Image) componentResourceManager.GetObject("tsbToolBoxRun.Image");
      this.tsbToolBoxRun.ImageTransparentColor = Color.Magenta;
      this.tsbToolBoxRun.Name = "tsbToolBoxRun";
      this.tsbToolBoxRun.Size = new Size(23, 20);
      this.tsbToolBoxRun.Text = "実行";
      this.tsbToolBoxRun.Click += new EventHandler(this.mniExeRun_Click);
      this.tsbToolBoxPause.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbToolBoxPause.Image = (Image) componentResourceManager.GetObject("tsbToolBoxPause.Image");
      this.tsbToolBoxPause.ImageTransparentColor = Color.Magenta;
      this.tsbToolBoxPause.Name = "tsbToolBoxPause";
      this.tsbToolBoxPause.Size = new Size(23, 20);
      this.tsbToolBoxPause.Text = "中断";
      this.tsbToolBoxPause.Click += new EventHandler(this.mniDebugPause_Click);
      this.tsbToolBoxStop.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbToolBoxStop.Image = (Image) componentResourceManager.GetObject("tsbToolBoxStop.Image");
      this.tsbToolBoxStop.ImageTransparentColor = Color.Magenta;
      this.tsbToolBoxStop.Name = "tsbToolBoxStop";
      this.tsbToolBoxStop.Size = new Size(23, 20);
      this.tsbToolBoxStop.Text = "停止";
      this.tsbToolBoxStop.Click += new EventHandler(this.mniExeStop_Click);
      this.tssToolBoxSeparator3.Name = "tssToolBoxSeparator3";
      this.tssToolBoxSeparator3.Size = new Size(6, 23);
      this.tsbToolBoxContinue.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbToolBoxContinue.Image = (Image) componentResourceManager.GetObject("tsbToolBoxContinue.Image");
      this.tsbToolBoxContinue.ImageTransparentColor = Color.Magenta;
      this.tsbToolBoxContinue.Name = "tsbToolBoxContinue";
      this.tsbToolBoxContinue.Size = new Size(23, 20);
      this.tsbToolBoxContinue.Text = "続行";
      this.tsbToolBoxContinue.Click += new EventHandler(this.mniDebugContinue_Click);
      this.tsbToolBoxStep.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbToolBoxStep.Image = (Image) componentResourceManager.GetObject("tsbToolBoxStep.Image");
      this.tsbToolBoxStep.ImageTransparentColor = Color.Magenta;
      this.tsbToolBoxStep.Name = "tsbToolBoxStep";
      this.tsbToolBoxStep.Size = new Size(23, 20);
      this.tsbToolBoxStep.Text = "ステップ";
      this.tsbToolBoxStep.Click += new EventHandler(this.mniDebugStep_Click);
      this.tssToolBoxSeparator4.Name = "tssToolBoxSeparator4";
      this.tssToolBoxSeparator4.Size = new Size(6, 23);
      this.tsbToolBoxBuild.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbToolBoxBuild.Image = (Image) componentResourceManager.GetObject("tsbToolBoxBuild.Image");
      this.tsbToolBoxBuild.ImageTransparentColor = Color.Magenta;
      this.tsbToolBoxBuild.Name = "tsbToolBoxBuild";
      this.tsbToolBoxBuild.Size = new Size(23, 20);
      this.tsbToolBoxBuild.Text = "exe化";
      this.tsbToolBoxBuild.Click += new EventHandler(this.mniBuildToExe_Click);
      this.tsbToolBoxBuildNoConsole.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbToolBoxBuildNoConsole.Image = (Image) componentResourceManager.GetObject("tsbToolBoxBuildNoConsole.Image");
      this.tsbToolBoxBuildNoConsole.ImageTransparentColor = Color.Magenta;
      this.tsbToolBoxBuildNoConsole.Name = "tsbToolBoxBuildNoConsole";
      this.tsbToolBoxBuildNoConsole.Size = new Size(23, 20);
      this.tsbToolBoxBuildNoConsole.Text = "exe化(Console非表示)";
      this.tsbToolBoxBuildNoConsole.Click += new EventHandler(this.mniBuildToExeNoConsole_Click);
      this.tssToolBoxSeparator5.Name = "tssToolBoxSeparator5";
      this.tssToolBoxSeparator5.Size = new Size(6, 23);
      this.tsbToolBoxOption.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbToolBoxOption.Image = (Image) componentResourceManager.GetObject("tsbToolBoxOption.Image");
      this.tsbToolBoxOption.ImageTransparentColor = Color.Magenta;
      this.tsbToolBoxOption.Name = "tsbToolBoxOption";
      this.tsbToolBoxOption.Size = new Size(23, 20);
      this.tsbToolBoxOption.Text = "オプション";
      this.tsbToolBoxOption.Click += new EventHandler(this.mniSettingOption_Click);
      this.cmsEditTab.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.mniCtxEditTabClose
      });
      this.cmsEditTab.Name = "cmsEditTab";
      this.cmsEditTab.Size = new Size(131, 26);
      this.mniCtxEditTabClose.Name = "mniCtxEditTabClose";
      this.mniCtxEditTabClose.Size = new Size(130, 22);
      this.mniCtxEditTabClose.Text = "閉じる(&C)";
      this.mniCtxEditTabClose.Click += new EventHandler(this.mniCtxEditTabClose_Click);
      this.lstIntellisense.FormattingEnabled = true;
      this.lstIntellisense.ItemHeight = 12;
      this.lstIntellisense.Location = new Point(61, 52);
      this.lstIntellisense.Name = "lstIntellisense";
      this.lstIntellisense.Size = new Size(120, 88);
      this.lstIntellisense.TabIndex = 0;
      this.lstIntellisense.Visible = false;
      this.lstIntellisense.MouseDown += new MouseEventHandler(this.lstIntellisense_MouseDown);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(802, 603);
      this.Controls.Add((Control) this.lstIntellisense);
      this.Controls.Add((Control) this.sptRoot);
      this.Controls.Add((Control) this.pnlRight);
      this.Controls.Add((Control) this.stsMain);
      this.Controls.Add((Control) this.mnuMain);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MainMenuStrip = this.mnuMain;
      this.MinimumSize = new Size(420, 346);
      this.Name = nameof (MainForm);
      this.Text = "VisualBat";
      this.Deactivate += new EventHandler(this.MainForm_Deactivate);
      this.Load += new EventHandler(this.MainForm_Load);
      this.DragDrop += new DragEventHandler(this.MainForm_DragDrop);
      this.DragEnter += new DragEventHandler(this.MainForm_DragEnter);
      this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
      this.sptMainVertical.Panel1.ResumeLayout(false);
      this.sptMainVertical.Panel2.ResumeLayout(false);
      this.sptMainVertical.ResumeLayout(false);
      this.sptEditHorizontal.Panel1.ResumeLayout(false);
      this.sptEditHorizontal.Panel2.ResumeLayout(false);
      this.sptEditHorizontal.ResumeLayout(false);
      this.sptIdiomVertical.Panel1.ResumeLayout(false);
      this.sptIdiomVertical.Panel2.ResumeLayout(false);
      this.sptIdiomVertical.Panel2.PerformLayout();
      this.sptIdiomVertical.ResumeLayout(false);
      this.tlpIdiomControl.ResumeLayout(false);
      this.sptDebugHorizontal.Panel1.ResumeLayout(false);
      this.sptDebugHorizontal.Panel2.ResumeLayout(false);
      this.sptDebugHorizontal.ResumeLayout(false);
      ((ISupportInitialize) this.dgvVarList).EndInit();
      this.grpRunningCondition.ResumeLayout(false);
      this.grpRunningCondition.PerformLayout();
      this.grpTraceSetting.ResumeLayout(false);
      this.grpTraceSetting.PerformLayout();
      this.stsMain.ResumeLayout(false);
      this.stsMain.PerformLayout();
      this.mnuMain.ResumeLayout(false);
      this.mnuMain.PerformLayout();
      this.cmsEdit.ResumeLayout(false);
      this.cmsIdiomIndex.ResumeLayout(false);
      this.sptRoot.Panel1.ResumeLayout(false);
      this.sptRoot.Panel1.PerformLayout();
      this.sptRoot.Panel2.ResumeLayout(false);
      this.sptRoot.ResumeLayout(false);
      this.tstToolBox.ResumeLayout(false);
      this.tstToolBox.PerformLayout();
      this.cmsEditTab.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private delegate R Func1<T1, R>(T1 t1);
  }
}

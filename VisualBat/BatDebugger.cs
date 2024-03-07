/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VisualBat.Properties;

#nullable disable
namespace VisualBat
{
  public class BatDebugger
  {
    private static readonly string appName = Assembly.GetExecutingAssembly().GetName().Name;
    private static readonly string breakExePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Breakpoint";
    private static readonly string feedBackVarBatPath;
    private static readonly string breakLoopBatPath;
    private static readonly string breakLoopCommandBatPath;
    private static Process process;
    private static string workBatPath;
    private string src;
    private Dictionary<int, bool> breakableLineDicCache;

    public static event EventHandler RunningCompleted;

    public static int BreakPointId { get; private set; }

    public static bool Debug { get; set; }

    public static bool Running { get; private set; }

    public static bool ErrorOccurred { get; private set; }

    public static int ExitCode { get; private set; }

    public static DateTime ExitTime { get; private set; }

    public static string LastCmdLine { get; private set; }

    public Dictionary<int, bool> BPLineDic { get; private set; }

    static BatDebugger()
    {
      BatDebugger.BreakPointId = Environment.TickCount;
      BatDebugger.feedBackVarBatPath = Path.GetTempPath() + BatDebugger.appName + (object) BatDebugger.BreakPointId + "_feedback.bat";
      BatDebugger.breakLoopBatPath = Path.GetTempPath() + BatDebugger.appName + (object) BatDebugger.BreakPointId + "_break.bat";
      BatDebugger.breakLoopCommandBatPath = Path.GetTempPath() + BatDebugger.appName + (object) BatDebugger.BreakPointId + "_command.bat";
    }

    public BatDebugger()
    {
      this.src = "";
      this.BPLineDic = new Dictionary<int, bool>();
    }

    public static void Dispose()
    {
      try
      {
        if (File.Exists(BatDebugger.feedBackVarBatPath))
          File.Delete(BatDebugger.feedBackVarBatPath);
        if (File.Exists(BatDebugger.breakLoopBatPath))
          File.Delete(BatDebugger.breakLoopBatPath);
        if (!File.Exists(BatDebugger.breakLoopCommandBatPath))
          return;
        File.Delete(BatDebugger.breakLoopCommandBatPath);
      }
      catch
      {
      }
    }

    public void ClearBreakPoint()
    {
      this.UpdatedSrc("");
      this.BPLineDic.Clear();
    }

    public void UpdatedSrc(string updatedSrc)
    {
      this.src = updatedSrc;
      this.breakableLineDicCache = (Dictionary<int, bool>) null;
    }

    public void ToggleBreakPoint(int line)
    {
      Dictionary<int, bool> breakableLineDic = this.GetBreakableLineDic();
      List<int> intList = new List<int>((IEnumerable<int>) breakableLineDic.Keys);
      if (breakableLineDic.Count == 0)
        return;
      int toggleLine = -1;
      intList.ForEach((Action<int>) (l =>
      {
        if (toggleLine >= l || l > line)
          return;
        toggleLine = l;
      }));
      if (toggleLine == -1)
        return;
      if (this.BPLineDic.ContainsKey(toggleLine))
        this.BPLineDic.Remove(toggleLine);
      else
        this.BPLineDic[toggleLine] = true;
    }

    public void VerifyBreakPoint()
    {
      Dictionary<int, bool> breakableLineDic = this.GetBreakableLineDic();
      foreach (int key in new List<int>((IEnumerable<int>) this.BPLineDic.Keys))
      {
        if (!breakableLineDic.ContainsKey(key))
          this.BPLineDic.Remove(key);
      }
    }

    public Dictionary<int, bool> GetBreakableLineDic()
    {
      if (this.breakableLineDicCache == null)
      {
        this.breakableLineDicCache = new Dictionary<int, bool>();
        string str = this.src;
        BatDebugger.ParseState parseState = BatDebugger.ParseState.Normal;
        int key = 1;
        int num = 0;
        while (num != -1)
        {
          num = str.IndexOf('\n');
          string input1 = str.Substring(0, num == -1 ? str.Length : num);
          switch (parseState)
          {
            case BatDebugger.ParseState.Normal:
              if (!Regex.IsMatch(input1, "^[ \\t]*$") && !Regex.IsMatch(input1, "^[ \\t]*(?::|@?rem[;:,. \\\\<>&|\\t])", RegexOptions.IgnoreCase))
              {
                this.breakableLineDicCache[key] = true;
                goto default;
              }
              else
                goto default;
            case BatDebugger.ParseState.EmptyEndEscape:
              if (input1 == "")
              {
                parseState = BatDebugger.ParseState.LineSkip;
                break;
              }
              input1 = input1.Substring(1);
              goto default;
            default:
              string input2 = input1.Replace("^^", "");
              parseState = Regex.IsMatch(input2, "\\^$") ? (Regex.IsMatch(input2, "^[ \\t]*\\^$") ? BatDebugger.ParseState.EmptyEndEscape : BatDebugger.ParseState.EndEscape) : BatDebugger.ParseState.Normal;
              break;
          }
          str = str.Substring(num + 1);
          ++key;
        }
      }
      return this.breakableLineDicCache;
    }

    public static void WriteFeedBackVarBat(IDictionary varDic)
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      if (varDic.Count > 0)
      {
        stringBuilder1.AppendLine("@goto _!!");
        stringBuilder1.AppendLine(":_!!");
        foreach (object key in (IEnumerable) varDic.Keys)
        {
          stringBuilder1.Append(string.Format("@set {0}=", key));
          foreach (char ch in (string) varDic[key])
            stringBuilder1.Append(ch == '%' ? '%' : '^').Append(ch);
          stringBuilder1.AppendLine();
        }
        stringBuilder1.AppendLine("@exit /b>\"%~f0\"");
        stringBuilder1.AppendLine(":_");
        foreach (object key in (IEnumerable) varDic.Keys)
        {
          stringBuilder1.Append(string.Format("@set {0}=", key));
          foreach (char ch in (string) varDic[key])
          {
            StringBuilder stringBuilder2 = stringBuilder1;
            string str;
            switch (ch)
            {
              case '!':
              case '^':
                str = "^^^";
                break;
              case '%':
                str = "%";
                break;
              default:
                str = "^";
                break;
            }
            stringBuilder2.Append(str).Append(ch);
          }
          stringBuilder1.AppendLine();
        }
        stringBuilder1.AppendLine("@exit /b>\"%~f0\"");
      }
      BatDebugger.WriteFile(BatDebugger.feedBackVarBatPath, stringBuilder1.ToString());
    }

    public void Run(string arg, string initDir, string srcPath)
    {
      if (BatDebugger.Running)
        return;
      BatDebugger.Running = true;
      BackgroundWorker backgroundWorker = new BackgroundWorker();
      backgroundWorker.RunWorkerCompleted += (RunWorkerCompletedEventHandler) ((sender, e) =>
      {
        if (BatDebugger.RunningCompleted != null)
          BatDebugger.RunningCompleted((object) this, new EventArgs());
        BatDebugger.deleteWorkBat();
        BatDebugger.Running = false;
      });
      backgroundWorker.DoWork += (DoWorkEventHandler) ((sender, e) =>
      {
        BatDebugger.ErrorOccurred = false;
        BatDebugger.DeleteBreakLoopCommandBat();
        StringBuilder stringBuilder1 = new StringBuilder();
        if (BatDebugger.Debug)
        {
          if (Setting.EnableInterruptCmd)
          {
            StringBuilder stringBuilder2 = new StringBuilder();
            stringBuilder2.AppendLine(":_");
            stringBuilder2.AppendLine(string.Format("@\"{0}\" {1} %1", (object) BatDebugger.breakExePath, (object) BatDebugger.BreakPointId));
            stringBuilder2.AppendLine(string.Format("@if not exist \"{0}\" exit /b %errorlevel%", (object) BatDebugger.breakLoopCommandBatPath));
            stringBuilder2.AppendLine(string.Format("@call \"{0}\"", (object) BatDebugger.breakLoopCommandBatPath));
            stringBuilder2.AppendLine("@set _errorlevel=%errorlevel%");
            stringBuilder2.AppendLine(string.Format("@del \"{0}\"", (object) BatDebugger.breakLoopCommandBatPath));
            stringBuilder2.AppendLine("@goto _");
            BatDebugger.WriteFile(BatDebugger.breakLoopBatPath, stringBuilder2.ToString());
          }
          Dictionary<int, bool> breakableLineDic = this.GetBreakableLineDic();
          int key = 0;
          stringBuilder1.AppendLine("@set _errorlevel=0");
          stringBuilder1.AppendLine(string.Format("@\"{0}\" {1} 0", (object) BatDebugger.breakExePath, (object) BatDebugger.BreakPointId));
          string src = this.src;
          char[] chArray = new char[1]{ '\n' };
          foreach (string str in src.Split(chArray))
          {
            ++key;
            if (!(str.Trim() == ""))
            {
              if (!breakableLineDic.ContainsKey(key))
              {
                stringBuilder1.AppendLine(str);
              }
              else
              {
                stringBuilder1.AppendLine("@call set _errorlevel=%%errorlevel%%");
                if (Setting.DumpForVar || Setting.DumpArg)
                {
                  if (!Setting.EnableInterruptCmd)
                    stringBuilder1.AppendLine("@setlocal disabledelayedexpansion");
                  if (Setting.DumpForVar)
                  {
                    foreach (char ch in Setting.ForVarChar)
                      stringBuilder1.AppendLine(string.Format("@set _for_{0}=%%{0}", (object) ch));
                  }
                  if (Setting.DumpArg)
                  {
                    for (int index = 0; index <= 9; ++index)
                      stringBuilder1.AppendLine(string.Format("@set _arg_{0}=%{0}", (object) index));
                  }
                  if (Setting.EnableInterruptCmd)
                  {
                    stringBuilder1.AppendLine(string.Format("@call \"{0}\" {1}", (object) BatDebugger.breakLoopBatPath, (object) key));
                  }
                  else
                  {
                    stringBuilder1.AppendLine(string.Format("@\"{0}\" {1} {2}", (object) BatDebugger.breakExePath, (object) BatDebugger.BreakPointId, (object) key));
                    stringBuilder1.AppendLine("@endlocal");
                  }
                }
                else if (Setting.EnableInterruptCmd)
                  stringBuilder1.AppendLine(string.Format("@call \"{0}\" {1}", (object) BatDebugger.breakLoopBatPath, (object) key));
                else
                  stringBuilder1.AppendLine(string.Format("@\"{0}\" {1} {2}", (object) BatDebugger.breakExePath, (object) BatDebugger.BreakPointId, (object) key));
                stringBuilder1.AppendLine(string.Format("@call \"{0}\"", (object) BatDebugger.feedBackVarBatPath));
                stringBuilder1.AppendLine(str);
              }
            }
          }
          stringBuilder1.AppendLine("@call set _errorlevel=%%errorlevel%%");
          stringBuilder1.AppendLine(string.Format("@\"{0}\" {1} -1", (object) BatDebugger.breakExePath, (object) BatDebugger.BreakPointId));
        }
        else
          stringBuilder1.Append(this.src);
        try
        {
          string str1 = (srcPath == "" ? "tmp" + (object) BatDebugger.BreakPointId : Path.GetFileNameWithoutExtension(srcPath)) + "_debug.bat";
          string str2 = initDir == "" ? (srcPath == "" ? Path.GetTempPath() : Path.GetDirectoryName(srcPath)) : initDir;
          if (!str2.EndsWith("\\"))
            str2 += "\\";
          BatDebugger.workBatPath = str2 + str1;
          BatDebugger.WriteFile(BatDebugger.workBatPath, stringBuilder1.ToString());
        }
        catch (Exception ex)
        {
          BatDebugger.ErrorOccurred = true;
          int num = (int) MessageBox.Show("デバッグ用batファイルが作成できません。\n" + (object) ex);
          return;
        }
        BatDebugger.WriteFile(BatDebugger.feedBackVarBatPath, "");
        BatDebugger.process = new Process();
        BatDebugger.process.StartInfo.FileName = "cmd";
        if (Setting.EndPause)
        {
          BatDebugger.process.StartInfo.Arguments = "/c \"cmd /c \"\"" + BatDebugger.workBatPath + "\" " + arg + " & call exit /b ^%errorlevel^%\"\" & pause & call exit /b ^%errorlevel^%";
          BatDebugger.LastCmdLine = BatDebugger.process.StartInfo.Arguments.Substring(4);
        }
        else
        {
          BatDebugger.process.StartInfo.Arguments = "/c \"\"" + BatDebugger.workBatPath + "\" " + arg + " & call exit /b ^%errorlevel^%\"";
          BatDebugger.LastCmdLine = "\"" + Environment.GetEnvironmentVariable("comspec") + "\" " + BatDebugger.process.StartInfo.Arguments;
        }
        BatDebugger.process.StartInfo.UseShellExecute = true;
        BatDebugger.process.StartInfo.CreateNoWindow = false;
        BatDebugger.process.StartInfo.WorkingDirectory = initDir == "" ? Path.GetDirectoryName(BatDebugger.workBatPath) : initDir;
        BatDebugger.process.Start();
        BatDebugger.process.WaitForExit();
        BatDebugger.ExitTime = BatDebugger.process.ExitTime;
        BatDebugger.ExitCode = BatDebugger.process.ExitCode;
        BatDebugger.process.Close();
        BatDebugger.process = (Process) null;
      });
      backgroundWorker.RunWorkerAsync();
    }

    public static void RunCommand(string command)
    {
      Process process = new Process();
      process.StartInfo.FileName = "cmd";
      process.StartInfo.Arguments = "/c \"" + command + "\"";
      process.StartInfo.UseShellExecute = true;
      process.StartInfo.CreateNoWindow = false;
      process.Start();
      process.WaitForExit();
      process.Close();
    }

    public static void Stop()
    {
      if (BatDebugger.process == null)
        return;
      IntPtr mainWindowHandle = BatDebugger.process.MainWindowHandle;
      BatDebugger.process.Kill();
      Win32Api.SendMessage(mainWindowHandle, 16U, UIntPtr.Zero, IntPtr.Zero);
    }

    public static void WriteFile(string path, string data)
    {
      File.WriteAllText(path, Regex.Replace(data, "(?<!\\r)\\n", "\r\n"), Encoding.GetEncoding("shift_jis"));
    }

    public void ToExeFile(string path, byte[] baseExeData)
    {
      byte[] bytes = Encoding.GetEncoding("shift_jis").GetBytes(this.src);
      for (int index = 0; index < bytes.Length; ++index)
        bytes[index] ^= byte.MaxValue;
      using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
      {
        fileStream.Write(baseExeData, 0, baseExeData.Length);
        fileStream.Write(bytes, 0, bytes.Length);
        fileStream.Write(BitConverter.GetBytes(bytes.Length), 0, 4);
      }
    }

    public static string GetCommandHelpText(CommandData cmdData)
    {
      if (cmdData.HelpType == HelpType.NoHelp)
        return "";
      if (cmdData.HelpType == HelpType.CanNotGet)
        return "取得できませんでした。";
      StringBuilder stringBuilder = new StringBuilder();
      string str = cmdData.HelpType == HelpType.Normal ? "/?" : "";
      if (cmdData.Name == "sc query" || cmdData.Name == "sc queryex")
        return Resources.ScQeuryHelp;
      if (cmdData.Name == "ftp")
        return Resources.FtpHelp;
      if (cmdData.Name == "runas")
        return Resources.RunasHelp;
      if (cmdData.Name == "telnet")
        return Resources.TelnetHelp;
      if (cmdData.Name != "doskey" && cmdData.Name != "chkntfs" && cmdData.Name != "find")
      {
        Process process = new Process();
        process.StartInfo.FileName = "cmd";
        process.StartInfo.Arguments = "/c \"" + cmdData.Name + " " + str + "\"";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.Start();
        stringBuilder.Append(process.StandardOutput.ReadToEnd());
        if (stringBuilder.Length == 0)
          stringBuilder.Append(process.StandardError.ReadToEnd());
        process.WaitForExit(1000);
        process.Close();
      }
      if (stringBuilder.ToString().Trim().Length == 0)
      {
        string path = Path.GetTempPath() + cmdData.Name + "_help.txt";
        Process process = new Process();
        process.StartInfo.FileName = "cmd";
        process.StartInfo.Arguments = "/c \"" + cmdData.Name + " " + str + " > \"" + path + "\"\"";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.Start();
        process.WaitForExit(3000);
        process.Close();
        try
        {
          stringBuilder.Append(File.ReadAllText(path, Encoding.GetEncoding("shift_jis")));
          File.Delete(path);
        }
        catch
        {
        }
      }
      return Regex.Replace(stringBuilder.ToString(), "(?<!\\r)\\n", "\r\n");
    }

    private static void deleteWorkBat()
    {
      try
      {
        if (!File.Exists(BatDebugger.workBatPath))
          return;
        File.Delete(BatDebugger.workBatPath);
      }
      catch
      {
      }
    }

    public static void DeleteBreakLoopCommandBat()
    {
      try
      {
        if (!File.Exists(BatDebugger.breakLoopCommandBatPath))
          return;
        File.Delete(BatDebugger.breakLoopCommandBatPath);
      }
      catch
      {
      }
    }

    public static void CreateBreakLoopCommandBat(string command)
    {
      BatDebugger.WriteFile(BatDebugger.breakLoopCommandBatPath, command + "\r\n\r\n\r\nexit /b %errorlevel%");
    }

    public static string GetCommandOutput(string command)
    {
      return BatDebugger.GetCommandOutput(command, Environment.CurrentDirectory);
    }

    public static string GetCommandOutput(string command, string workDir)
    {
      return BatDebugger.GetCommandOutput(command, workDir, false);
    }

    public static string GetCommandOutput(string command, string workDir, bool delayedExpansion)
    {
      Process process = new Process();
      process.StartInfo.FileName = "cmd";
      process.StartInfo.Arguments = (delayedExpansion ? "/v:on " : "") + "/c \"" + command + "\"";
      process.StartInfo.WorkingDirectory = workDir;
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.CreateNoWindow = true;
      process.StartInfo.RedirectStandardOutput = true;
      process.StartInfo.RedirectStandardError = true;
      process.Start();
      string commandOutput = process.StandardOutput.ReadToEnd().Trim();
      process.WaitForExit(1000);
      process.Close();
      return commandOutput;
    }

    private enum ParseState
    {
      Normal,
      EndEscape,
      EmptyEndEscape,
      LineSkip,
    }
  }
}

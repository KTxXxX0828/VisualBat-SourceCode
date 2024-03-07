/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System;
using System.Collections.Generic;
using System.Security.Principal;

#nullable disable
namespace VisualBat
{
  public static class BatKeyword
  {
    public static SortedDictionary<string, CommandData> Dic { get; private set; }

    private static void add(string name, CommandType cmdType)
    {
      BatKeyword.add(name, cmdType, HelpType.Normal);
    }

    private static void add(string name, CommandType cmdType, HelpType helpType)
    {
      BatKeyword.Dic[name] = new CommandData()
      {
        Name = name,
        CmdType = cmdType,
        HelpType = helpType
      };
    }

    static BatKeyword()
    {
      BatKeyword.Dic = new SortedDictionary<string, CommandData>();
      BatKeyword.add("dir", CommandType.Drive);
      BatKeyword.add("rename", CommandType.File);
      BatKeyword.add("ren", CommandType.File);
      BatKeyword.add("erase", CommandType.File);
      BatKeyword.add("del", CommandType.File);
      BatKeyword.add("type", CommandType.InOut);
      BatKeyword.add("copy", CommandType.File);
      BatKeyword.add("chdir", CommandType.Control);
      BatKeyword.add("cd", CommandType.Control);
      BatKeyword.add("mkdir", CommandType.File);
      BatKeyword.add("md", CommandType.File);
      BatKeyword.add("rmdir", CommandType.File);
      BatKeyword.add("rd", CommandType.File);
      BatKeyword.add("vol", CommandType.Drive);
      BatKeyword.add("pushd", CommandType.Control);
      BatKeyword.add("popd", CommandType.Control);
      BatKeyword.add("move", CommandType.File);
      BatKeyword.add("more", CommandType.InOut);
      BatKeyword.add("date", CommandType.System);
      BatKeyword.add("time", CommandType.System);
      BatKeyword.add("ver", CommandType.System);
      BatKeyword.add("call", CommandType.Control);
      BatKeyword.add("exit", CommandType.Control);
      BatKeyword.add("start", CommandType.Control);
      BatKeyword.add("break", CommandType.Other);
      BatKeyword.add("verify", CommandType.File);
      BatKeyword.add("set", CommandType.Control);
      BatKeyword.add("prompt", CommandType.Control);
      BatKeyword.add("path", CommandType.Control);
      BatKeyword.add("setlocal", CommandType.Control);
      BatKeyword.add("endlocal", CommandType.Control);
      BatKeyword.add("enableextensions", CommandType.Reserved);
      BatKeyword.add("disableextensions", CommandType.Reserved);
      BatKeyword.add("enabledelayedexpansion", CommandType.Reserved);
      BatKeyword.add("disabledelayedexpansion", CommandType.Reserved);
      BatKeyword.add("cls", CommandType.Control);
      BatKeyword.add("echo", CommandType.InOut);
      BatKeyword.add("pause", CommandType.Control);
      BatKeyword.add("chcp", CommandType.Control);
      BatKeyword.add("color", CommandType.Control);
      BatKeyword.add("title", CommandType.Control);
      BatKeyword.add("doskey", CommandType.Control);
      BatKeyword.add("keys", CommandType.Other);
      BatKeyword.add("shift", CommandType.Control);
      BatKeyword.add("goto", CommandType.Control);
      BatKeyword.add("if", CommandType.Control);
      BatKeyword.add("else", CommandType.Reserved);
      BatKeyword.add("not", CommandType.Reserved);
      BatKeyword.add("errorlevel", CommandType.Reserved);
      BatKeyword.add("exist", CommandType.Reserved);
      BatKeyword.add("defined", CommandType.Reserved);
      BatKeyword.add("cmdextversion", CommandType.Reserved);
      BatKeyword.add("random", CommandType.Reserved);
      BatKeyword.add("cmdcmdline", CommandType.Reserved);
      BatKeyword.add("geq", CommandType.Reserved);
      BatKeyword.add("gtr", CommandType.Reserved);
      BatKeyword.add("leq", CommandType.Reserved);
      BatKeyword.add("lss", CommandType.Reserved);
      BatKeyword.add("neq", CommandType.Reserved);
      BatKeyword.add("equ", CommandType.Reserved);
      BatKeyword.add("for", CommandType.Control);
      BatKeyword.add("in", CommandType.Reserved);
      BatKeyword.add("do", CommandType.Reserved);
      BatKeyword.add("tokens", CommandType.Reserved);
      BatKeyword.add("delims", CommandType.Reserved);
      BatKeyword.add("skip", CommandType.Reserved);
      BatKeyword.add("eol", CommandType.Reserved);
      BatKeyword.add("assoc", CommandType.File);
      BatKeyword.add("ftype", CommandType.File);
      BatKeyword.add("nul", CommandType.Reserved);
      BatKeyword.add("con", CommandType.Reserved);
      BatKeyword.add("aux", CommandType.Reserved);
      BatKeyword.add("prn", CommandType.Reserved);
      BatKeyword.add("on", CommandType.Reserved);
      BatKeyword.add("off", CommandType.Reserved);
      BatKeyword.add("cmd", CommandType.Control);
      BatKeyword.add("xcopy", CommandType.File);
      BatKeyword.add("schtasks", CommandType.System);
      BatKeyword.add("shutdown", CommandType.System);
      BatKeyword.add("attrib", CommandType.File);
      BatKeyword.add("comp", CommandType.File);
      BatKeyword.add("fc", CommandType.File);
      BatKeyword.add("compact", CommandType.File);
      BatKeyword.add("find", CommandType.InOut);
      BatKeyword.add("findstr", CommandType.InOut);
      BatKeyword.add("recover", CommandType.Drive);
      BatKeyword.add("replace", CommandType.File);
      BatKeyword.add("sort", CommandType.InOut);
      BatKeyword.add("tree", CommandType.File);
      BatKeyword.add("arp", CommandType.Network);
      BatKeyword.add("ftp", CommandType.Network);
      BatKeyword.add("getmac", CommandType.Network);
      BatKeyword.add("ipconfig", CommandType.Network);
      BatKeyword.add("msg", CommandType.Network);
      BatKeyword.add("nbtstat", CommandType.Network);
      BatKeyword.add("netsh", CommandType.Network);
      BatKeyword.add("netstat", CommandType.Network);
      BatKeyword.add("pathping", CommandType.Network);
      BatKeyword.add("ping", CommandType.Network);
      BatKeyword.add("rasdial", CommandType.Network);
      BatKeyword.add("route", CommandType.Network);
      BatKeyword.add("shadow", CommandType.Network);
      BatKeyword.add("tracert", CommandType.Network);
      BatKeyword.add("tscon", CommandType.Network);
      BatKeyword.add("tsdiscon", CommandType.Network);
      BatKeyword.add("tskill", CommandType.Network);
      BatKeyword.add("at", CommandType.System);
      BatKeyword.add("cscript", CommandType.Other);
      BatKeyword.add("driverquery", CommandType.System);
      BatKeyword.add("eventcreate", CommandType.System);
      BatKeyword.add("fsutil", CommandType.Drive);
      BatKeyword.add("gpresult", CommandType.System);
      BatKeyword.add("gpupdate", CommandType.System);
      BatKeyword.add("hostname", CommandType.System);
      BatKeyword.add("reg", CommandType.System);
      BatKeyword.add("runas", CommandType.Other);
      BatKeyword.add("rundll32", CommandType.Other);
      BatKeyword.add("systeminfo", CommandType.System);
      BatKeyword.add("taskkill", CommandType.System);
      BatKeyword.add("tasklist", CommandType.System);
      BatKeyword.add("cacls", CommandType.File);
      BatKeyword.add("lodctr", CommandType.System);
      BatKeyword.add("logman", CommandType.System);
      BatKeyword.add("net", CommandType.System);
      BatKeyword.add("net accounts", CommandType.System);
      BatKeyword.add("net config", CommandType.System);
      BatKeyword.add("net continue", CommandType.System);
      BatKeyword.add("net pause", CommandType.System);
      BatKeyword.add("net localgroup", CommandType.System);
      BatKeyword.add("net print", CommandType.System);
      BatKeyword.add("net session", CommandType.System);
      BatKeyword.add("net share", CommandType.System);
      BatKeyword.add("net stop", CommandType.System);
      BatKeyword.add("net time", CommandType.System);
      BatKeyword.add("net use", CommandType.System);
      BatKeyword.add("net user", CommandType.System);
      BatKeyword.add("net view", CommandType.System);
      BatKeyword.add("net start", CommandType.System);
      BatKeyword.add("net statistics", CommandType.System);
      BatKeyword.add("powercfg", CommandType.System);
      BatKeyword.add("qprocess", CommandType.System);
      BatKeyword.add("qwinsta", CommandType.System);
      BatKeyword.add("relog", CommandType.System);
      BatKeyword.add("reset", CommandType.System);
      BatKeyword.add("sc", CommandType.System, HelpType.CanNotGet);
      BatKeyword.add("sc config", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc continue", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc interrogate", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc pause", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc start", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc stop", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc control", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc create", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc enumdepend", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc failure", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc qfailure", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc getdisplayname", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc getkeyname", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc lock", CommandType.System, HelpType.CanNotGet);
      BatKeyword.add("sc querylock", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc qc", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc qsidtype", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc showsid", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc sidtype", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc query", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc queryex", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc boot", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc delete", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc description", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc qdescription", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc sdset", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc sdshow", CommandType.System, HelpType.NoArg);
      BatKeyword.add("schtasks", CommandType.System);
      BatKeyword.add("schtasks /create", CommandType.System);
      BatKeyword.add("schtasks /change", CommandType.System);
      BatKeyword.add("schtasks /query", CommandType.System);
      BatKeyword.add("schtasks /delete", CommandType.System);
      BatKeyword.add("schtasks /end", CommandType.System);
      BatKeyword.add("schtasks /run", CommandType.System);
      BatKeyword.add("sfc", CommandType.Drive);
      BatKeyword.add("vssadmin", CommandType.Drive);
      BatKeyword.add("w32tm", CommandType.System);
      BatKeyword.add("chkdsk", CommandType.Drive);
      BatKeyword.add("chkntfs", CommandType.Drive);
      BatKeyword.add("cipher", CommandType.File);
      BatKeyword.add("convert", CommandType.Drive);
      BatKeyword.add("diskperf", CommandType.System);
      BatKeyword.add("format", CommandType.Drive);
      BatKeyword.add("label", CommandType.Drive);
      BatKeyword.add("mountvol", CommandType.Drive);
      BatKeyword.add("openfiles", CommandType.File);
      BatKeyword.add("defrag", CommandType.Drive);
      if (new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
        BatKeyword.add("diskpart", CommandType.Drive);
      if (Environment.OSVersion.Version.Major <= 5)
      {
        BatKeyword.add("nslookup", CommandType.Network, HelpType.NoHelp);
        BatKeyword.add("telnet", CommandType.Network);
      }
      if (Environment.OSVersion.Version.Major < 6)
        return;
      BatKeyword.add("nslookup", CommandType.Network);
      BatKeyword.add("highestnumanodenumber", CommandType.Reserved);
      BatKeyword.add("powershell", CommandType.Other);
      BatKeyword.add("clip", CommandType.Other);
      BatKeyword.add("setx", CommandType.Control);
      BatKeyword.add("forfiles", CommandType.Control);
      BatKeyword.add("robocopy", CommandType.File);
      BatKeyword.add("where", CommandType.File);
      BatKeyword.add("netcfg", CommandType.Network);
      BatKeyword.add("change", CommandType.Network);
      BatKeyword.add("choice", CommandType.Control);
      BatKeyword.add("takeown", CommandType.File);
      BatKeyword.add("timeout", CommandType.Control);
      BatKeyword.add("auditpol", CommandType.System);
      BatKeyword.add("bitsadmin", CommandType.System);
      BatKeyword.add("icacls", CommandType.File);
      BatKeyword.add("query", CommandType.System);
      BatKeyword.add("quser", CommandType.System);
      BatKeyword.add("waitfor", CommandType.Control);
      BatKeyword.add("whoami", CommandType.System);
      BatKeyword.add("bcdedit", CommandType.System);
      BatKeyword.add("pnputil", CommandType.System);
      BatKeyword.add("cmdkey", CommandType.System);
      BatKeyword.add("sc failureflag", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc privs", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc qfailureflag", CommandType.System, HelpType.NoArg);
      BatKeyword.add("sc qprivs", CommandType.System, HelpType.NoArg);
    }
  }
}

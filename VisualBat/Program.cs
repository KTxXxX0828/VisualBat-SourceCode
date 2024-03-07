/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace VisualBat
{
  internal static class Program
  {
    public static string[] Args { get; set; }

    [STAThread]
    private static void Main(string[] args)
    {
      Program.Args = args;
      Win32Api.AllowSetForegroundWindow((uint) Process.GetCurrentProcess().Id);
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.ThreadException += new ThreadExceptionEventHandler(Program.Application_ThreadException);
      Application.Run((Form) new MainForm());
    }

    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
      int num = (int) MessageDialog.Show(MessageID.ERR_UNKNOWN, e.Exception.ToString());
    }
  }
}

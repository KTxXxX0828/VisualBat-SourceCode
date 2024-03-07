/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace VisualBat
{
  internal static class Win32Api
  {
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, uint wMsg, UIntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    public static extern bool InvalidateRect(IntPtr hWnd, ref Win32Api.RECT lpRect, bool bErase);

    [DllImport("user32.dll")]
    public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

    [DllImport("user32.DLL")]
    public static extern bool AllowSetForegroundWindow(uint dwProcessId);

    [DllImport("kernel32.DLL")]
    public static extern uint GetPrivateProfileString(
      string lpAppName,
      string lpKeyName,
      string lpDefault,
      StringBuilder lpReturnedString,
      uint nSize,
      string lpFileName);

    [DllImport("kernel32.DLL")]
    public static extern uint GetPrivateProfileInt(
      string lpAppName,
      string lpKeyName,
      int nDefault,
      string lpFileName);

    [DllImport("kernel32.DLL")]
    public static extern uint WritePrivateProfileString(
      string lpAppName,
      string lpKeyName,
      string lpString,
      string lpFileName);

    public struct RECT
    {
      public int left;
      public int top;
      public int right;
      public int bottom;
    }
  }
}

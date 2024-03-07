/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using IpcLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Threading;

#nullable disable
namespace Breakpoint
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      if (args.Length == 0)
        return;
      try
      {
        int id = int.Parse(args[0]);
        int breakLine1 = int.Parse(args[1]);
        int num = int.Parse(Environment.GetEnvironmentVariable("_errorlevel") ?? "0");
        Environment.ExitCode = num;
        IpcClient ipcClient = new IpcClient(id);
        if (breakLine1 == 0)
        {
          if (ipcClient.RemoteObject.SystemVariableDic != null)
            return;
          ipcClient.RemoteObject.SystemVariableDic = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);
          ipcClient.RemoteObject.ArrivedSrcEnd = false;
          ipcClient.RemoteObject.Stopped = false;
          ipcClient.RemoteObject.BreakLine = 0;
          ipcClient.RemoteObject.BreakVariableDic = (IDictionary) null;
        }
        else
        {
          if (ipcClient.RemoteObject.DebugCommand == DebugCommand.Command)
          {
            breakLine1 = ipcClient.RemoteObject.BreakLine;
            List<object[]> traceInfoList = ipcClient.RemoteObject.TraceInfoList;
            if (ipcClient.RemoteObject.TraceInfoCount != 0)
            {
              traceInfoList.RemoveRange(0, ipcClient.RemoteObject.TraceInfoCount);
              ipcClient.RemoteObject.TraceInfoCount = 0;
              ipcClient.RemoteObject.TraceInfoCountReceived = true;
            }
            traceInfoList.Add(new object[5]
            {
              (object) -2,
              (object) num,
              (object) DateTime.Now,
              (object) Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process),
              (object) Environment.CurrentDirectory
            });
            ipcClient.RemoteObject.TraceInfoList = traceInfoList;
          }
          else
          {
            int breakLine2 = ipcClient.RemoteObject.BreakLine;
            List<object[]> traceInfoList = ipcClient.RemoteObject.TraceInfoList;
            bool flag = false;
            if (ipcClient.RemoteObject.TraceInfoCount != 0)
            {
              traceInfoList.RemoveRange(0, ipcClient.RemoteObject.TraceInfoCount);
              ipcClient.RemoteObject.TraceInfoCount = 0;
              flag = true;
            }
            if (breakLine2 > 0)
              traceInfoList.Add(new object[5]
              {
                (object) breakLine2,
                (object) num,
                (object) DateTime.Now,
                (object) Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process),
                (object) Environment.CurrentDirectory
              });
            ipcClient.RemoteObject.TraceInfoList = traceInfoList;
            if (flag)
              ipcClient.RemoteObject.TraceInfoCountReceived = true;
            ipcClient.RemoteObject.BreakLine = breakLine1;
            if (breakLine1 == -1)
            {
              ipcClient.RemoteObject.ArrivedSrcEnd = true;
              return;
            }
            if (breakLine1 >= 1)
            {
              if (ipcClient.RemoteObject.ClearFeedBackData)
                ipcClient.RemoteObject.ClearFeedBackData = false;
              if (args.Length >= 3)
              {
                Environment.ExitCode = ipcClient.RemoteObject.DebugCommand == DebugCommand.Step || ipcClient.RemoteObject.BPLineDic.ContainsKey(breakLine1) ? 1 : 0;
                return;
              }
            }
          }
          if (ipcClient.RemoteObject.DebugCommand != DebugCommand.Command && ipcClient.RemoteObject.BreakVariableDic == null)
            ipcClient.RemoteObject.BreakVariableDic = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);
          if (ipcClient.RemoteObject.DebugCommand == DebugCommand.Step || ipcClient.RemoteObject.DebugCommand == DebugCommand.Command || ipcClient.RemoteObject.BPLineDic.ContainsKey(breakLine1))
            ipcClient.RemoteObject.DebugCommand = DebugCommand.None;
          while (ipcClient.RemoteObject.DebugCommand == DebugCommand.None)
          {
            if (ipcClient.RemoteObject.BatVariableDic == null)
            {
              ipcClient.RemoteObject.BatVariableDic = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);
              ipcClient.RemoteObject.Breaking = true;
            }
            Thread.Sleep(100);
          }
          if (ipcClient.RemoteObject.BatVariableDic == null)
            return;
          ipcClient.RemoteObject.BatVariableDic = (IDictionary) null;
        }
      }
      catch (FormatException ex)
      {
      }
      catch (RemotingException ex)
      {
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
      }
    }
  }
}

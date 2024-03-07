/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace IpcLib
{
  public class IpcData : MarshalByRefObject
  {
    public bool Breaking { get; set; }

    public bool Stopped { get; set; }

    public bool ClearFeedBackData { get; set; }

    public int BreakLine { get; set; }

    public Dictionary<int, bool> BPLineDic { get; set; }

    public DebugCommand DebugCommand { get; set; }

    public IDictionary SystemVariableDic { get; set; }

    public IDictionary BatVariableDic { get; set; }

    public IDictionary BreakVariableDic { get; set; }

    public List<object[]> TraceInfoList { get; set; }

    public bool ArrivedSrcEnd { get; set; }

    public int TraceInfoCount { get; set; }

    public bool TraceInfoCountReceived { get; set; }

    public override object InitializeLifetimeService() => (object) null;
  }
}

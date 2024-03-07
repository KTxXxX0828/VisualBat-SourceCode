/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

#nullable disable
namespace IpcLib
{
  public class IpcClient
  {
    public IpcData RemoteObject { get; set; }

    public IpcClient(int id)
    {
      ChannelServices.RegisterChannel((IChannel) new IpcClientChannel(), true);
      this.RemoteObject = Activator.GetObject(typeof (IpcData), "ipc://VisualBat" + (object) id + "/Breakpoint") as IpcData;
    }
  }
}

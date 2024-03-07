/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

#nullable disable
namespace IpcLib
{
  public class IpcServer
  {
    public IpcData RemoteObject { get; set; }

    public IpcServer(int id)
    {
      ChannelServices.RegisterChannel((IChannel) new IpcServerChannel("VisualBat" + (object) id), true);
      this.RemoteObject = new IpcData();
      RemotingServices.Marshal((MarshalByRefObject) this.RemoteObject, "Breakpoint", typeof (IpcData));
    }
  }
}

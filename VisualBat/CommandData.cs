/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

#nullable disable
namespace VisualBat
{
  public class CommandData
  {
    public string Name { get; set; }

    public CommandType CmdType { get; set; }

    public HelpType HelpType { get; set; }

    public string HelpText { get; set; }

    public override string ToString() => this.Name;
  }
}

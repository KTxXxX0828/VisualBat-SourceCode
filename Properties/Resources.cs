/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace VisualBat.Properties
{
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) VisualBat.Properties.Resources.resourceMan, (object) null))
          VisualBat.Properties.Resources.resourceMan = new ResourceManager("VisualBat.Properties.Resources", typeof (VisualBat.Properties.Resources).Assembly);
        return VisualBat.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => VisualBat.Properties.Resources.resourceCulture;
      set => VisualBat.Properties.Resources.resourceCulture = value;
    }

    internal static string DefaultIdiomXml
    {
      get
      {
        return VisualBat.Properties.Resources.ResourceManager.GetString(nameof (DefaultIdiomXml), VisualBat.Properties.Resources.resourceCulture);
      }
    }

    internal static string FtpHelp
    {
      get => VisualBat.Properties.Resources.ResourceManager.GetString(nameof (FtpHelp), VisualBat.Properties.Resources.resourceCulture);
    }

    internal static string RunasHelp
    {
      get => VisualBat.Properties.Resources.ResourceManager.GetString(nameof (RunasHelp), VisualBat.Properties.Resources.resourceCulture);
    }

    internal static string ScQeuryHelp
    {
      get => VisualBat.Properties.Resources.ResourceManager.GetString(nameof (ScQeuryHelp), VisualBat.Properties.Resources.resourceCulture);
    }

    internal static string TelnetHelp
    {
      get => VisualBat.Properties.Resources.ResourceManager.GetString(nameof (TelnetHelp), VisualBat.Properties.Resources.resourceCulture);
    }

    internal static byte[] VisualBat_Executer
    {
      get
      {
        return (byte[]) VisualBat.Properties.Resources.ResourceManager.GetObject(nameof (VisualBat_Executer), VisualBat.Properties.Resources.resourceCulture);
      }
    }

    internal static byte[] VisualBat_Executer_w
    {
      get
      {
        return (byte[]) VisualBat.Properties.Resources.ResourceManager.GetObject(nameof (VisualBat_Executer_w), VisualBat.Properties.Resources.resourceCulture);
      }
    }

    internal static Bitmap VisualBat_logo
    {
      get
      {
        return (Bitmap) VisualBat.Properties.Resources.ResourceManager.GetObject(nameof (VisualBat_logo), VisualBat.Properties.Resources.resourceCulture);
      }
    }
  }
}

/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System.Collections.Generic;
using System.Windows.Forms;

#nullable disable
namespace VisualBat
{
  internal static class ReentryBlock
  {
    private static Dictionary<object, bool> entryDic = new Dictionary<object, bool>();

    public static void Work(MethodInvoker mi, object key)
    {
      if (ReentryBlock.entryDic.ContainsKey(key))
        return;
      ReentryBlock.entryDic[key] = true;
      mi();
      ReentryBlock.entryDic.Remove(key);
    }
  }
}

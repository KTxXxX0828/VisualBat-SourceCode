/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System;
using System.Windows.Forms;

#nullable disable
namespace VisualBat
{
  public static class MessageDialog
  {
    private const int TYPE_INF = 0;
    private const int TYPE_CFM = 1;
    private const int TYPE_WAR = 2;
    private const int TYPE_ERR = 3;
    private static readonly string[] titleList = new string[4]
    {
      "情報",
      "確認",
      "警告",
      "エラー"
    };
    private static Form owner;

    public static Form Owner
    {
      set => MessageDialog.owner = value;
      get => MessageDialog.owner;
    }

    public static DialogResult Show(MessageID id, params string[] args)
    {
      int type = (int) id / 1000 - 1;
      MessageBoxButtons buttonType = MessageBoxButtons.OK;
      MessageBoxIcon messageIcon = MessageBoxIcon.None;
      MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
      switch (type)
      {
        case 0:
          messageIcon = MessageBoxIcon.Asterisk;
          break;
        case 1:
          messageIcon = MessageBoxIcon.Question;
          buttonType = MessageBoxButtons.YesNo;
          break;
        case 2:
          messageIcon = MessageBoxIcon.Exclamation;
          break;
        case 3:
          messageIcon = MessageBoxIcon.Hand;
          break;
      }
      string text = (string) null;
      switch (id)
      {
        case MessageID.CFM_SAVE_FILE:
          text = string.Format("\"{0}\"\nは更新されています。保存しますか？", (object) args[0]);
          buttonType = MessageBoxButtons.YesNoCancel;
          break;
        case MessageID.CFM_DESTRUCTION_EDIT:
          text = string.Format("更新内容は破棄されますが、よろしいですか？");
          break;
        case MessageID.CFM_STOP_RUNNING:
          text = string.Format("実行中のbatを停止してもよろしいですか？");
          messageIcon = MessageBoxIcon.Exclamation;
          break;
        case MessageID.ERR_UNKNOWN:
          text = "何かのエラーです。：\n" + args[0];
          break;
      }
      if (MessageDialog.owner == null)
        return MessageBox.Show(text, MessageDialog.titleList[type], buttonType, messageIcon, defaultButton);
      DialogResult result = DialogResult.None;
      MessageDialog.owner.Invoke((Delegate) (() => result = MessageBox.Show((IWin32Window) MessageDialog.owner, text, MessageDialog.titleList[type], buttonType, messageIcon, defaultButton)));
      return result;
    }
  }
}

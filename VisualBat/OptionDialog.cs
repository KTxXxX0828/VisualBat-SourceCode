/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace VisualBat
{
  public class OptionDialog : Form
  {
    private IContainer components;
    private Button btnOK;
    private Button btnCancel;
    private CheckBox chkDumpForVar;
    private CheckBox chkDumpArg;
    private CheckBox chkEndPause;
    private CheckBox chkEnableInterruptCmd;
    private TabControl tbcSetting;
    private TabPage tbpDebug;
    private Panel pnlControl;
    private TabPage tbpEditor;
    private Button btnFont;
    private FontDialog dlgEditFont;
    private Label lblFontPreview;
    private Panel pnlSetting;
    private TabPage tbpWindow;
    private CheckBox chkRememberLayout;
    private CheckBox chkShowFullPath;
    private CheckBox chkCloseOnlyCurrentTab;
    private CheckBox chkRememberTab;
    private TextBox txtForVarChar;
    private Panel pnlForeColor;
    private Panel pnlBackColor;
    private Button btnBackColor;
    private Button btnForeColor;
    private ColorDialog dlgColor;
    private MainForm mainForm;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.chkDumpForVar = new CheckBox();
      this.chkDumpArg = new CheckBox();
      this.chkEndPause = new CheckBox();
      this.chkEnableInterruptCmd = new CheckBox();
      this.tbcSetting = new TabControl();
      this.tbpWindow = new TabPage();
      this.pnlBackColor = new Panel();
      this.btnBackColor = new Button();
      this.pnlForeColor = new Panel();
      this.btnForeColor = new Button();
      this.chkCloseOnlyCurrentTab = new CheckBox();
      this.chkShowFullPath = new CheckBox();
      this.chkRememberLayout = new CheckBox();
      this.tbpEditor = new TabPage();
      this.chkRememberTab = new CheckBox();
      this.lblFontPreview = new Label();
      this.btnFont = new Button();
      this.tbpDebug = new TabPage();
      this.txtForVarChar = new TextBox();
      this.pnlControl = new Panel();
      this.dlgEditFont = new FontDialog();
      this.pnlSetting = new Panel();
      this.dlgColor = new ColorDialog();
      this.tbcSetting.SuspendLayout();
      this.tbpWindow.SuspendLayout();
      this.tbpEditor.SuspendLayout();
      this.tbpDebug.SuspendLayout();
      this.pnlControl.SuspendLayout();
      this.pnlSetting.SuspendLayout();
      this.SuspendLayout();
      this.btnOK.Anchor = AnchorStyles.None;
      this.btnOK.Location = new Point(112, 14);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 0;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.btnCancel.Anchor = AnchorStyles.None;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(211, 14);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "キャンセル";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.chkDumpForVar.AutoSize = true;
      this.chkDumpForVar.Location = new Point(29, 14);
      this.chkDumpForVar.Name = "chkDumpForVar";
      this.chkDumpForVar.Size = new Size(99, 17);
      this.chkDumpForVar.TabIndex = 0;
      this.chkDumpForVar.Text = "for変数のダンプ";
      this.chkDumpForVar.UseVisualStyleBackColor = true;
      this.chkDumpForVar.CheckedChanged += new EventHandler(this.chkDumpForVar_CheckedChanged);
      this.chkDumpArg.AutoSize = true;
      this.chkDumpArg.Location = new Point(29, 37);
      this.chkDumpArg.Name = "chkDumpArg";
      this.chkDumpArg.Size = new Size(87, 17);
      this.chkDumpArg.TabIndex = 2;
      this.chkDumpArg.Text = "引数のダンプ";
      this.chkDumpArg.UseVisualStyleBackColor = true;
      this.chkEndPause.AutoSize = true;
      this.chkEndPause.Location = new Point(29, 60);
      this.chkEndPause.Name = "chkEndPause";
      this.chkEndPause.Size = new Size(115, 17);
      this.chkEndPause.TabIndex = 3;
      this.chkEndPause.Text = "実行終了後pause";
      this.chkEndPause.UseVisualStyleBackColor = true;
      this.chkEnableInterruptCmd.AutoSize = true;
      this.chkEnableInterruptCmd.Location = new Point(29, 83);
      this.chkEnableInterruptCmd.Name = "chkEnableInterruptCmd";
      this.chkEnableInterruptCmd.Size = new Size(198, 17);
      this.chkEnableInterruptCmd.TabIndex = 4;
      this.chkEnableInterruptCmd.Text = "コマンド割り込み実行機能の有効化";
      this.chkEnableInterruptCmd.UseVisualStyleBackColor = true;
      this.tbcSetting.Controls.Add((Control) this.tbpWindow);
      this.tbcSetting.Controls.Add((Control) this.tbpEditor);
      this.tbcSetting.Controls.Add((Control) this.tbpDebug);
      this.tbcSetting.Dock = DockStyle.Fill;
      this.tbcSetting.Location = new Point(5, 5);
      this.tbcSetting.Name = "tbcSetting";
      this.tbcSetting.SelectedIndex = 0;
      this.tbcSetting.Size = new Size(389, 193);
      this.tbcSetting.TabIndex = 6;
      this.tbpWindow.Controls.Add((Control) this.pnlBackColor);
      this.tbpWindow.Controls.Add((Control) this.btnBackColor);
      this.tbpWindow.Controls.Add((Control) this.pnlForeColor);
      this.tbpWindow.Controls.Add((Control) this.btnForeColor);
      this.tbpWindow.Controls.Add((Control) this.chkCloseOnlyCurrentTab);
      this.tbpWindow.Controls.Add((Control) this.chkShowFullPath);
      this.tbpWindow.Controls.Add((Control) this.chkRememberLayout);
      this.tbpWindow.Location = new Point(4, 22);
      this.tbpWindow.Name = "tbpWindow";
      this.tbpWindow.Size = new Size(381, 167);
      this.tbpWindow.TabIndex = 2;
      this.tbpWindow.Text = "ウィンドウ";
      this.tbpWindow.UseVisualStyleBackColor = true;
      this.pnlBackColor.BorderStyle = BorderStyle.FixedSingle;
      this.pnlBackColor.Location = new Point(170, 86);
      this.pnlBackColor.Name = "pnlBackColor";
      this.pnlBackColor.Size = new Size(22, 22);
      this.pnlBackColor.TabIndex = 6;
      this.btnBackColor.Location = new Point(203, 85);
      this.btnBackColor.Name = "btnBackColor";
      this.btnBackColor.Size = new Size(75, 23);
      this.btnBackColor.TabIndex = 5;
      this.btnBackColor.Text = "背景色...";
      this.btnBackColor.UseVisualStyleBackColor = true;
      this.btnBackColor.Click += new EventHandler(this.btnBackColor_Click);
      this.pnlForeColor.BorderStyle = BorderStyle.FixedSingle;
      this.pnlForeColor.Location = new Point(35, 86);
      this.pnlForeColor.Name = "pnlForeColor";
      this.pnlForeColor.Size = new Size(22, 22);
      this.pnlForeColor.TabIndex = 4;
      this.btnForeColor.Location = new Point(68, 85);
      this.btnForeColor.Name = "btnForeColor";
      this.btnForeColor.Size = new Size(75, 23);
      this.btnForeColor.TabIndex = 3;
      this.btnForeColor.Text = "前景色...";
      this.btnForeColor.UseVisualStyleBackColor = true;
      this.btnForeColor.Click += new EventHandler(this.btnForeColor_Click);
      this.chkCloseOnlyCurrentTab.AutoSize = true;
      this.chkCloseOnlyCurrentTab.Location = new Point(29, 60);
      this.chkCloseOnlyCurrentTab.Name = "chkCloseOnlyCurrentTab";
      this.chkCloseOnlyCurrentTab.Size = new Size(204, 17);
      this.chkCloseOnlyCurrentTab.TabIndex = 2;
      this.chkCloseOnlyCurrentTab.Text = "「閉じる」操作で現在のタブのみ閉じる";
      this.chkCloseOnlyCurrentTab.UseVisualStyleBackColor = true;
      this.chkShowFullPath.AutoSize = true;
      this.chkShowFullPath.Location = new Point(29, 37);
      this.chkShowFullPath.Name = "chkShowFullPath";
      this.chkShowFullPath.Size = new Size(204, 17);
      this.chkShowFullPath.TabIndex = 1;
      this.chkShowFullPath.Text = "タイトルバーにファイルのフルパスを表示";
      this.chkShowFullPath.UseVisualStyleBackColor = true;
      this.chkRememberLayout.AutoSize = true;
      this.chkRememberLayout.Location = new Point(29, 14);
      this.chkRememberLayout.Name = "chkRememberLayout";
      this.chkRememberLayout.Size = new Size(238, 17);
      this.chkRememberLayout.TabIndex = 0;
      this.chkRememberLayout.Text = "前回表示時の位置・サイズ・レイアウトを記憶";
      this.chkRememberLayout.UseVisualStyleBackColor = true;
      this.tbpEditor.Controls.Add((Control) this.chkRememberTab);
      this.tbpEditor.Controls.Add((Control) this.lblFontPreview);
      this.tbpEditor.Controls.Add((Control) this.btnFont);
      this.tbpEditor.Location = new Point(4, 22);
      this.tbpEditor.Name = "tbpEditor";
      this.tbpEditor.Size = new Size(381, 167);
      this.tbpEditor.TabIndex = 1;
      this.tbpEditor.Text = "エディタ";
      this.tbpEditor.UseVisualStyleBackColor = true;
      this.chkRememberTab.AutoSize = true;
      this.chkRememberTab.Location = new Point(37, 69);
      this.chkRememberTab.Name = "chkRememberTab";
      this.chkRememberTab.Size = new Size(161, 17);
      this.chkRememberTab.TabIndex = 3;
      this.chkRememberTab.Text = "前回表示していたタブを復元";
      this.chkRememberTab.UseVisualStyleBackColor = true;
      this.lblFontPreview.AutoSize = true;
      this.lblFontPreview.Location = new Point(134, 33);
      this.lblFontPreview.Name = "lblFontPreview";
      this.lblFontPreview.Size = new Size(13, 13);
      this.lblFontPreview.TabIndex = 1;
      this.lblFontPreview.Text = "_";
      this.btnFont.Location = new Point(37, 28);
      this.btnFont.Name = "btnFont";
      this.btnFont.Size = new Size(75, 23);
      this.btnFont.TabIndex = 0;
      this.btnFont.Text = "フォント...";
      this.btnFont.UseVisualStyleBackColor = true;
      this.btnFont.Click += new EventHandler(this.btnFont_Click);
      this.tbpDebug.Controls.Add((Control) this.txtForVarChar);
      this.tbpDebug.Controls.Add((Control) this.chkDumpForVar);
      this.tbpDebug.Controls.Add((Control) this.chkEnableInterruptCmd);
      this.tbpDebug.Controls.Add((Control) this.chkDumpArg);
      this.tbpDebug.Controls.Add((Control) this.chkEndPause);
      this.tbpDebug.Location = new Point(4, 22);
      this.tbpDebug.Name = "tbpDebug";
      this.tbpDebug.Padding = new Padding(3);
      this.tbpDebug.Size = new Size(381, 167);
      this.tbpDebug.TabIndex = 0;
      this.tbpDebug.Text = "デバッグ";
      this.tbpDebug.UseVisualStyleBackColor = true;
      this.txtForVarChar.Location = new Point(144, 12);
      this.txtForVarChar.Name = "txtForVarChar";
      this.txtForVarChar.Size = new Size(188, 20);
      this.txtForVarChar.TabIndex = 1;
      this.pnlControl.Controls.Add((Control) this.btnCancel);
      this.pnlControl.Controls.Add((Control) this.btnOK);
      this.pnlControl.Dock = DockStyle.Bottom;
      this.pnlControl.Location = new Point(0, 198);
      this.pnlControl.Name = "pnlControl";
      this.pnlControl.Size = new Size(399, 50);
      this.pnlControl.TabIndex = 6;
      this.dlgEditFont.AllowScriptChange = false;
      this.dlgEditFont.AllowVerticalFonts = false;
      this.dlgEditFont.ScriptsOnly = true;
      this.dlgEditFont.ShowEffects = false;
      this.pnlSetting.Controls.Add((Control) this.tbcSetting);
      this.pnlSetting.Dock = DockStyle.Fill;
      this.pnlSetting.Location = new Point(0, 0);
      this.pnlSetting.Name = "pnlSetting";
      this.pnlSetting.Padding = new Padding(5, 5, 5, 0);
      this.pnlSetting.Size = new Size(399, 198);
      this.pnlSetting.TabIndex = 2;
      this.dlgColor.AnyColor = true;
      this.dlgColor.FullOpen = true;
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(399, 248);
      this.Controls.Add((Control) this.pnlSetting);
      this.Controls.Add((Control) this.pnlControl);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (OptionDialog);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "オプション";
      this.Load += new EventHandler(this.OptionDialog_Load);
      this.tbcSetting.ResumeLayout(false);
      this.tbpWindow.ResumeLayout(false);
      this.tbpWindow.PerformLayout();
      this.tbpEditor.ResumeLayout(false);
      this.tbpEditor.PerformLayout();
      this.tbpDebug.ResumeLayout(false);
      this.tbpDebug.PerformLayout();
      this.pnlControl.ResumeLayout(false);
      this.pnlSetting.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public OptionDialog() => this.InitializeComponent();

    private void OptionDialog_Load(object sender, EventArgs e)
    {
      this.mainForm = (MainForm) this.Owner;
      this.chkRememberLayout.Checked = Setting.RememberLayout;
      this.chkShowFullPath.Checked = Setting.ShowFullPath;
      this.chkCloseOnlyCurrentTab.Checked = Setting.CloseOnlyCurrentTab;
      this.pnlForeColor.BackColor = Setting.ForeColor;
      this.pnlBackColor.BackColor = Setting.BackColor;
      this.dlgEditFont.Font = this.mainForm.Editor.TextBox.Font;
      this.updateFontPreview(this.dlgEditFont.Font);
      this.chkRememberTab.Checked = Setting.RememberTab;
      this.chkDumpForVar.Checked = true;
      this.chkDumpForVar.Checked = Setting.DumpForVar;
      this.txtForVarChar.Text = Setting.ForVarChar;
      this.chkDumpArg.Checked = Setting.DumpArg;
      this.chkEndPause.Checked = Setting.EndPause;
      this.chkEnableInterruptCmd.Checked = Setting.EnableInterruptCmd;
      this.txtForVarChar.ForeColor = Setting.ForeColor;
      this.txtForVarChar.BackColor = Setting.BackColor;
    }

    private bool isUpdated()
    {
      return ((false | this.chkRememberLayout.Checked != Setting.RememberLayout | this.chkShowFullPath.Checked != Setting.ShowFullPath | this.chkCloseOnlyCurrentTab.Checked != Setting.CloseOnlyCurrentTab | this.pnlForeColor.BackColor != Setting.ForeColor | this.pnlBackColor.BackColor != Setting.BackColor | Setting.FontToStr(this.dlgEditFont.Font) != Setting.FontToStr(Setting.EditorFont) | this.chkRememberTab.Checked != Setting.RememberTab | this.chkDumpForVar.Checked != Setting.DumpForVar ? 1 : 0) | (!(this.txtForVarChar.Text != Setting.ForVarChar) ? 0 : (this.txtForVarChar.Enabled ? 1 : 0))) != 0 | this.chkDumpArg.Checked != Setting.DumpArg | this.chkEndPause.Checked != Setting.EndPause | this.chkEnableInterruptCmd.Checked != Setting.EnableInterruptCmd;
    }

    private void apply()
    {
      Setting.RememberLayout = this.chkRememberLayout.Checked;
      Setting.ShowFullPath = this.chkShowFullPath.Checked;
      this.mainForm.UpdateTitle();
      Setting.CloseOnlyCurrentTab = this.chkCloseOnlyCurrentTab.Checked;
      if (Setting.ForeColor != this.pnlForeColor.BackColor || Setting.BackColor != this.pnlBackColor.BackColor)
      {
        Setting.ForeColor = this.pnlForeColor.BackColor;
        Setting.BackColor = this.pnlBackColor.BackColor;
        foreach (LinedRichTextBox allEditor in this.mainForm.AllEditors)
          allEditor.UpdateKeywordHighlight();
      }
      Setting.RememberTab = this.chkRememberTab.Checked;
      if (Setting.FontToStr(this.dlgEditFont.Font) != Setting.FontToStr(Setting.EditorFont))
      {
        Setting.EditorFont = this.dlgEditFont.Font;
        foreach (LinedRichTextBox allEditor in this.mainForm.AllEditors)
          allEditor.TextBox.Font = this.dlgEditFont.Font;
      }
      this.mainForm.Editor.Update();
      Setting.DumpForVar = this.chkDumpForVar.Checked;
      Setting.ForVarChar = this.txtForVarChar.Text;
      Setting.DumpArg = this.chkDumpArg.Checked;
      Setting.EndPause = this.chkEndPause.Checked;
      Setting.EnableInterruptCmd = this.chkEnableInterruptCmd.Checked;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (this.isUpdated())
      {
        this.apply();
        Setting.SaveSetting();
      }
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e) => this.Close();

    private void updateFontPreview(Font font)
    {
      this.lblFontPreview.Text = font.FontFamily.Name + ", " + (object) font.SizeInPoints + "pt";
      this.lblFontPreview.Font = font;
      this.lblFontPreview.Top = this.btnFont.Bottom - (int) ((double) this.lblFontPreview.Height * 0.7) - 8;
    }

    private void btnFont_Click(object sender, EventArgs e)
    {
      if (this.dlgEditFont.ShowDialog() != DialogResult.OK)
        return;
      this.updateFontPreview(this.dlgEditFont.Font);
    }

    private void btnForeColor_Click(object sender, EventArgs e)
    {
      this.dlgColor.Color = this.pnlForeColor.BackColor;
      if (this.dlgColor.ShowDialog() != DialogResult.OK)
        return;
      this.pnlForeColor.BackColor = this.dlgColor.Color;
    }

    private void btnBackColor_Click(object sender, EventArgs e)
    {
      this.dlgColor.Color = this.pnlBackColor.BackColor;
      if (this.dlgColor.ShowDialog() != DialogResult.OK)
        return;
      this.pnlBackColor.BackColor = this.dlgColor.Color;
    }

    private void chkDumpForVar_CheckedChanged(object sender, EventArgs e)
    {
      this.txtForVarChar.Enabled = this.chkDumpForVar.Checked;
    }
  }
}

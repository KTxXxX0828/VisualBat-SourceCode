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
  public class RunCommandDialog : Form
  {
    private IContainer components;
    private Button btnRun;
    private Button btnClose;
    private Label lblCommand;
    private TextBox txtCommand;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.btnRun = new Button();
      this.btnClose = new Button();
      this.lblCommand = new Label();
      this.txtCommand = new TextBox();
      this.SuspendLayout();
      this.btnRun.Anchor = AnchorStyles.Bottom;
      this.btnRun.Enabled = false;
      this.btnRun.Location = new Point(76, 58);
      this.btnRun.Name = "btnRun";
      this.btnRun.Size = new Size(75, 23);
      this.btnRun.TabIndex = 1;
      this.btnRun.Text = "実行";
      this.btnRun.UseVisualStyleBackColor = true;
      this.btnRun.Click += new EventHandler(this.btnRun_Click);
      this.btnClose.Anchor = AnchorStyles.Bottom;
      this.btnClose.DialogResult = DialogResult.Cancel;
      this.btnClose.Location = new Point(172, 58);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(75, 23);
      this.btnClose.TabIndex = 2;
      this.btnClose.Text = "閉じる";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new EventHandler(this.btnClose_Click);
      this.lblCommand.AutoSize = true;
      this.lblCommand.Location = new Point(21, 22);
      this.lblCommand.Name = "lblCommand";
      this.lblCommand.Size = new Size(42, 13);
      this.lblCommand.TabIndex = 2;
      this.lblCommand.Text = "コマンド";
      this.txtCommand.Location = new Point(69, 19);
      this.txtCommand.Name = "txtCommand";
      this.txtCommand.Size = new Size(223, 20);
      this.txtCommand.TabIndex = 0;
      this.txtCommand.TextChanged += new EventHandler(this.txtCommand_TextChanged);
      this.AcceptButton = (IButtonControl) this.btnRun;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnClose;
      this.ClientSize = new Size(322, 93);
      this.Controls.Add((Control) this.txtCommand);
      this.Controls.Add((Control) this.lblCommand);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnRun);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (RunCommandDialog);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "コマンド割り込み実行";
      this.FormClosed += new FormClosedEventHandler(this.RunCommandDialog_FormClosed);
      this.Load += new EventHandler(this.RunCommandDialog_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public static RunCommandDialog CurrentInstance { get; set; }

    public static string LastCommand { get; set; }

    public Action<string> RunAction { get; set; }

    public bool RunningCommand { get; set; }

    public TextBox TxtCommand => this.txtCommand;

    public RunCommandDialog() => this.InitializeComponent();

    private void RunCommandDialog_Load(object sender, EventArgs e)
    {
      RunCommandDialog.CurrentInstance = this;
      this.Location = new Point(this.Owner.Location.X + (this.Owner.Width - this.Width) / 2 - 40, this.Owner.Location.Y + (this.Owner.Height - this.Height) / 2 + 40);
      if (RunCommandDialog.LastCommand != null)
        this.txtCommand.Text = RunCommandDialog.LastCommand;
      this.ActiveControl = (Control) this.txtCommand;
      this.txtCommand.ForeColor = Setting.ForeColor;
      this.txtCommand.BackColor = Setting.BackColor;
    }

    private void RunCommandDialog_FormClosed(object sender, FormClosedEventArgs e)
    {
      RunCommandDialog.CurrentInstance = (RunCommandDialog) null;
    }

    private void btnClose_Click(object sender, EventArgs e) => this.Close();

    private void btnRun_Click(object sender, EventArgs e)
    {
      if (this.txtCommand.Text.Length == 0)
        return;
      this.RunAction(this.txtCommand.Text);
    }

    private void txtCommand_TextChanged(object sender, EventArgs e)
    {
    }

    public void ChangeEnabledRunButton(bool enabled)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) (() => this.ChangeEnabledRunButton(enabled)));
      else
        this.btnRun.Enabled = enabled;
    }
  }
}

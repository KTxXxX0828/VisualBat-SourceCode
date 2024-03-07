/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace VisualBat
{
  public class LicenceDialog : Form
  {
    private IContainer components;
    private Label label1;
    private TabControl tabControl1;
    private TabPage tabPage2;
    private TextBox textBox2;
    private Button button1;

    public LicenceDialog() => this.InitializeComponent();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (LicenceDialog));
      this.label1 = new Label();
      this.tabControl1 = new TabControl();
      this.tabPage2 = new TabPage();
      this.textBox2 = new TextBox();
      this.button1 = new Button();
      this.tabControl1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(24, 15);
      this.label1.Name = "label1";
      this.label1.Size = new Size(286, 12);
      this.label1.TabIndex = 0;
      this.label1.Text = "VisualBatが利用しているライブラリ等のライセンス情報です。";
      this.tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tabControl1.Controls.Add((Control) this.tabPage2);
      this.tabControl1.Location = new Point(12, 39);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(551, 237);
      this.tabControl1.TabIndex = 1;
      this.tabPage2.Controls.Add((Control) this.textBox2);
      this.tabPage2.Location = new Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(3);
      this.tabPage2.Size = new Size(543, 211);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Fugue Icons";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.textBox2.Dock = DockStyle.Fill;
      this.textBox2.Location = new Point(3, 3);
      this.textBox2.Multiline = true;
      this.textBox2.Name = "textBox2";
      this.textBox2.ReadOnly = true;
      this.textBox2.Size = new Size(537, 205);
      this.textBox2.TabIndex = 1;
      this.textBox2.Text = componentResourceManager.GetString("textBox2.Text");
      this.textBox2.WordWrap = false;
      this.button1.Anchor = AnchorStyles.Bottom;
      this.button1.DialogResult = DialogResult.Cancel;
      this.button1.Location = new Point(250, 286);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 2;
      this.button1.Text = "OK";
      this.button1.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.button1;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.button1;
      this.ClientSize = new Size(575, 320);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.tabControl1);
      this.Controls.Add((Control) this.label1);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (LicenceDialog);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "ライセンス情報";
      this.tabControl1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}

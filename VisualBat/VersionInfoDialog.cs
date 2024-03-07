/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using VisualBat.Properties;

#nullable disable
namespace VisualBat
{
  public class VersionInfoDialog : Form
  {
    private IContainer components;
    private Button btnOK;
    private PictureBox pctLogo;
    private Label lblVersionText;
    private LinkLabel lnlDoudemoexe;
    private Label lblLastModified;
    private Button button1;

    public VersionInfoDialog() => this.InitializeComponent();

    private void VersionInfoDialog_Load(object sender, EventArgs e)
    {
      DateTime lastWriteTime = new FileInfo(Application.ExecutablePath).LastWriteTime;
      this.lblVersionText.Text = "VisualBat ver " + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
      this.lblLastModified.Text = "(Last Modified：" + (object) lastWriteTime + ")";
    }

    private void lnlDoudemoexe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.lnlDoudemoexe.LinkVisited = true;
      Process.Start(this.lnlDoudemoexe.Text);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      using (LicenceDialog licenceDialog = new LicenceDialog())
      {
        int num = (int) licenceDialog.ShowDialog();
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.btnOK = new Button();
      this.pctLogo = new PictureBox();
      this.lblVersionText = new Label();
      this.lnlDoudemoexe = new LinkLabel();
      this.lblLastModified = new Label();
      this.button1 = new Button();
      ((ISupportInitialize) this.pctLogo).BeginInit();
      this.SuspendLayout();
      this.btnOK.Anchor = AnchorStyles.Bottom;
      this.btnOK.DialogResult = DialogResult.Cancel;
      this.btnOK.Location = new Point(132, 143);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 25);
      this.btnOK.TabIndex = 0;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.pctLogo.BackgroundImage = (Image) Resources.VisualBat_logo;
      this.pctLogo.BackgroundImageLayout = ImageLayout.Stretch;
      this.pctLogo.Location = new Point(18, 39);
      this.pctLogo.Name = "pctLogo";
      this.pctLogo.Size = new Size(72, 72);
      this.pctLogo.TabIndex = 2;
      this.pctLogo.TabStop = false;
      this.lblVersionText.AutoSize = true;
      this.lblVersionText.Font = new Font("MS Reference Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblVersionText.Location = new Point(97, 39);
      this.lblVersionText.Name = "lblVersionText";
      this.lblVersionText.Size = new Size(25, 26);
      this.lblVersionText.TabIndex = 3;
      this.lblVersionText.Text = "_";
      this.lnlDoudemoexe.AutoSize = true;
      this.lnlDoudemoexe.Location = new Point(103, 97);
      this.lnlDoudemoexe.Name = "lnlDoudemoexe";
      this.lnlDoudemoexe.Size = new Size((int) sbyte.MaxValue, 13);
      this.lnlDoudemoexe.TabIndex = 4;
      ((Label) this.lnlDoudemoexe).TabStop = true;
      this.lnlDoudemoexe.Text = "http://doudemoexe.com/";
      this.lnlDoudemoexe.LinkClicked += new LinkLabelLinkClickedEventHandler(this.lnlDoudemoexe_LinkClicked);
      this.lblLastModified.AutoSize = true;
      this.lblLastModified.Font = new Font("メイリオ", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblLastModified.Location = new Point(100, 72);
      this.lblLastModified.Name = "lblLastModified";
      this.lblLastModified.Size = new Size(107, 18);
      this.lblLastModified.TabIndex = 5;
      this.lblLastModified.Text = "(Last Modified：)";
      this.button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.button1.AutoSize = true;
      this.button1.Location = new Point(12, 143);
      this.button1.Name = "button1";
      this.button1.Size = new Size(86, 25);
      this.button1.TabIndex = 6;
      this.button1.Text = "ライセンス情報";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Visible = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnOK;
      this.ClientSize = new Size(339, 181);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.lblLastModified);
      this.Controls.Add((Control) this.lnlDoudemoexe);
      this.Controls.Add((Control) this.lblVersionText);
      this.Controls.Add((Control) this.pctLogo);
      this.Controls.Add((Control) this.btnOK);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (VersionInfoDialog);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "バージョン情報";
      this.Load += new EventHandler(this.VersionInfoDialog_Load);
      ((ISupportInitialize) this.pctLogo).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}

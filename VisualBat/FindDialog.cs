/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

#nullable disable
namespace VisualBat
{
  public class FindDialog : Form
  {
    private IContainer components;
    private TextBox txtData;
    private Label lblData;
    private CheckBox chkRegex;
    private Button btnSearchUp;
    private Button btnSearchDown;
    private CheckBox chkIgnoreCase;
    private Button btnClose;
    private RichTextBoxEx textBox;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.txtData = new TextBox();
      this.lblData = new Label();
      this.chkRegex = new CheckBox();
      this.btnSearchUp = new Button();
      this.btnSearchDown = new Button();
      this.chkIgnoreCase = new CheckBox();
      this.btnClose = new Button();
      this.SuspendLayout();
      this.txtData.Location = new Point(59, 14);
      this.txtData.Name = "txtData";
      this.txtData.Size = new Size(135, 19);
      this.txtData.TabIndex = 1;
      this.lblData.AutoSize = true;
      this.lblData.Location = new Point(20, 16);
      this.lblData.Name = "lblData";
      this.lblData.Size = new Size(29, 12);
      this.lblData.TabIndex = 0;
      this.lblData.Text = "条件";
      this.chkRegex.AutoSize = true;
      this.chkRegex.Location = new Point(23, 61);
      this.chkRegex.Name = "chkRegex";
      this.chkRegex.Size = new Size(72, 16);
      this.chkRegex.TabIndex = 3;
      this.chkRegex.Text = "正規表現";
      this.chkRegex.UseVisualStyleBackColor = true;
      this.btnSearchUp.Location = new Point(211, 12);
      this.btnSearchUp.Name = "btnSearchUp";
      this.btnSearchUp.Size = new Size(75, 21);
      this.btnSearchUp.TabIndex = 4;
      this.btnSearchUp.Text = "上検索";
      this.btnSearchUp.UseVisualStyleBackColor = true;
      this.btnSearchUp.Click += new EventHandler(this.btnSearchUp_Click);
      this.btnSearchDown.Location = new Point(211, 40);
      this.btnSearchDown.Name = "btnSearchDown";
      this.btnSearchDown.Size = new Size(75, 21);
      this.btnSearchDown.TabIndex = 5;
      this.btnSearchDown.Text = "下検索";
      this.btnSearchDown.UseVisualStyleBackColor = true;
      this.btnSearchDown.Click += new EventHandler(this.btnSearchDown_Click);
      this.chkIgnoreCase.AutoSize = true;
      this.chkIgnoreCase.Checked = true;
      this.chkIgnoreCase.CheckState = CheckState.Checked;
      this.chkIgnoreCase.Location = new Point(23, 43);
      this.chkIgnoreCase.Name = "chkIgnoreCase";
      this.chkIgnoreCase.Size = new Size(136, 16);
      this.chkIgnoreCase.TabIndex = 2;
      this.chkIgnoreCase.Text = "大文字/小文字の区別";
      this.chkIgnoreCase.UseVisualStyleBackColor = true;
      this.btnClose.DialogResult = DialogResult.Cancel;
      this.btnClose.Location = new Point(211, 107);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(75, 21);
      this.btnClose.TabIndex = 6;
      this.btnClose.TabStop = false;
      this.btnClose.Text = "閉じる";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new EventHandler(this.btnClose_Click);
      this.AcceptButton = (IButtonControl) this.btnSearchDown;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnClose;
      this.ClientSize = new Size(298, 91);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.chkIgnoreCase);
      this.Controls.Add((Control) this.btnSearchDown);
      this.Controls.Add((Control) this.btnSearchUp);
      this.Controls.Add((Control) this.chkRegex);
      this.Controls.Add((Control) this.lblData);
      this.Controls.Add((Control) this.txtData);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (FindDialog);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "検索";
      this.Load += new EventHandler(this.FindDialog_Load);
      this.FormClosed += new FormClosedEventHandler(this.FindDialog_FormClosed);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public static FindDialog CurrentInstance { get; set; }

    public TextBox TxtData => this.txtData;

    public FindDialog(RichTextBoxEx initTextBox)
    {
      this.textBox = initTextBox;
      this.InitializeComponent();
    }

    private void FindDialog_Load(object sender, EventArgs e)
    {
      FindDialog.CurrentInstance = this;
      this.Location = new Point(this.Owner.Location.X + (this.Owner.Width - this.Width) / 2, this.Owner.Location.Y + (this.Owner.Height - this.Height) / 2);
      this.txtData.ForeColor = Setting.ForeColor;
      this.txtData.BackColor = Setting.BackColor;
    }

    private void FindDialog_FormClosed(object sender, FormClosedEventArgs e)
    {
      FindDialog.CurrentInstance = (FindDialog) null;
    }

    private void btnClose_Click(object sender, EventArgs e) => this.Close();

    private void search(int startIndex, string src, bool downSearch)
    {
      StringFinder stringFinder = new StringFinder();
      stringFinder.DownSearch = downSearch;
      stringFinder.Src = src;
      stringFinder.FindStr = this.txtData.Text;
      stringFinder.IgnoreCase = !this.chkIgnoreCase.Checked;
      stringFinder.UseRegex = this.chkRegex.Checked;
      stringFinder.Search();
      if (stringFinder.ResultIndex == -1)
      {
        SystemSounds.Beep.Play();
      }
      else
      {
        this.textBox.Select(startIndex + stringFinder.ResultIndex, stringFinder.ResultLength);
        this.textBox.ScrollToCaretDelg();
      }
    }

    private void btnSearchUp_Click(object sender, EventArgs e)
    {
      this.search(0, this.textBox.Text.Substring(0, this.textBox.SelectionStart), false);
    }

    private void btnSearchDown_Click(object sender, EventArgs e)
    {
      int startIndex = this.textBox.SelectionStart + this.textBox.SelectionLength;
      this.search(startIndex, this.textBox.Text.Substring(startIndex, this.textBox.Text.Length - startIndex), true);
    }
  }
}

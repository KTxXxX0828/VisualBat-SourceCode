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
  public class ReplaceDialog : Form
  {
    private IContainer components;
    private TextBox txtBefore;
    private Label lblBefore;
    private CheckBox chkRegex;
    private Button btnSearchUp;
    private Button btnSearchDown;
    private CheckBox chkIgnoreCase;
    private Label lblAfter;
    private TextBox txtAfter;
    private Button btnReplace;
    private Button btnReplaceAll;
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
      this.txtBefore = new TextBox();
      this.lblBefore = new Label();
      this.chkRegex = new CheckBox();
      this.btnSearchUp = new Button();
      this.btnSearchDown = new Button();
      this.chkIgnoreCase = new CheckBox();
      this.lblAfter = new Label();
      this.txtAfter = new TextBox();
      this.btnReplace = new Button();
      this.btnReplaceAll = new Button();
      this.btnClose = new Button();
      this.SuspendLayout();
      this.txtBefore.Location = new Point(59, 14);
      this.txtBefore.Name = "txtBefore";
      this.txtBefore.Size = new Size(135, 19);
      this.txtBefore.TabIndex = 1;
      this.lblBefore.AutoSize = true;
      this.lblBefore.Location = new Point(12, 16);
      this.lblBefore.Name = "lblBefore";
      this.lblBefore.Size = new Size(41, 12);
      this.lblBefore.TabIndex = 0;
      this.lblBefore.Text = "置換前";
      this.chkRegex.AutoSize = true;
      this.chkRegex.Location = new Point(23, 85);
      this.chkRegex.Name = "chkRegex";
      this.chkRegex.Size = new Size(72, 16);
      this.chkRegex.TabIndex = 5;
      this.chkRegex.Text = "正規表現";
      this.chkRegex.UseVisualStyleBackColor = true;
      this.btnSearchUp.Location = new Point(211, 12);
      this.btnSearchUp.Name = "btnSearchUp";
      this.btnSearchUp.Size = new Size(75, 21);
      this.btnSearchUp.TabIndex = 6;
      this.btnSearchUp.Text = "上検索";
      this.btnSearchUp.UseVisualStyleBackColor = true;
      this.btnSearchUp.Click += new EventHandler(this.btnSearchUp_Click);
      this.btnSearchDown.Location = new Point(211, 40);
      this.btnSearchDown.Name = "btnSearchDown";
      this.btnSearchDown.Size = new Size(75, 21);
      this.btnSearchDown.TabIndex = 7;
      this.btnSearchDown.Text = "下検索";
      this.btnSearchDown.UseVisualStyleBackColor = true;
      this.btnSearchDown.Click += new EventHandler(this.btnSearchDown_Click);
      this.chkIgnoreCase.AutoSize = true;
      this.chkIgnoreCase.Checked = true;
      this.chkIgnoreCase.CheckState = CheckState.Checked;
      this.chkIgnoreCase.Location = new Point(23, 67);
      this.chkIgnoreCase.Name = "chkIgnoreCase";
      this.chkIgnoreCase.Size = new Size(136, 16);
      this.chkIgnoreCase.TabIndex = 4;
      this.chkIgnoreCase.Text = "大文字/小文字の区別";
      this.chkIgnoreCase.UseVisualStyleBackColor = true;
      this.lblAfter.AutoSize = true;
      this.lblAfter.Location = new Point(12, 40);
      this.lblAfter.Name = "lblAfter";
      this.lblAfter.Size = new Size(41, 12);
      this.lblAfter.TabIndex = 2;
      this.lblAfter.Text = "置換後";
      this.txtAfter.Location = new Point(59, 37);
      this.txtAfter.Name = "txtAfter";
      this.txtAfter.Size = new Size(135, 19);
      this.txtAfter.TabIndex = 3;
      this.btnReplace.Location = new Point(211, 67);
      this.btnReplace.Name = "btnReplace";
      this.btnReplace.Size = new Size(75, 21);
      this.btnReplace.TabIndex = 8;
      this.btnReplace.Text = "置換";
      this.btnReplace.UseVisualStyleBackColor = true;
      this.btnReplace.Click += new EventHandler(this.btnReplace_Click);
      this.btnReplaceAll.Location = new Point(211, 95);
      this.btnReplaceAll.Name = "btnReplaceAll";
      this.btnReplaceAll.Size = new Size(75, 21);
      this.btnReplaceAll.TabIndex = 9;
      this.btnReplaceAll.Text = "全て置換";
      this.btnReplaceAll.UseVisualStyleBackColor = true;
      this.btnReplaceAll.Click += new EventHandler(this.btnReplaceAll_Click);
      this.btnClose.DialogResult = DialogResult.Cancel;
      this.btnClose.Location = new Point(211, 140);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(75, 21);
      this.btnClose.TabIndex = 10;
      this.btnClose.TabStop = false;
      this.btnClose.Text = "閉じる";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new EventHandler(this.btnClose_Click);
      this.AcceptButton = (IButtonControl) this.btnSearchDown;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnClose;
      this.ClientSize = new Size(298, 123);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnReplaceAll);
      this.Controls.Add((Control) this.btnReplace);
      this.Controls.Add((Control) this.txtAfter);
      this.Controls.Add((Control) this.lblAfter);
      this.Controls.Add((Control) this.chkIgnoreCase);
      this.Controls.Add((Control) this.btnSearchDown);
      this.Controls.Add((Control) this.btnSearchUp);
      this.Controls.Add((Control) this.chkRegex);
      this.Controls.Add((Control) this.lblBefore);
      this.Controls.Add((Control) this.txtBefore);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (ReplaceDialog);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "置換";
      this.Load += new EventHandler(this.ReplaceDialog_Load);
      this.FormClosed += new FormClosedEventHandler(this.ReplaceDialog_FormClosed);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public static ReplaceDialog CurrentInstance { get; set; }

    public TextBox TxtBefore => this.txtBefore;

    public TextBox TxtAfter => this.txtAfter;

    public ReplaceDialog(RichTextBoxEx initTextBox)
    {
      this.textBox = initTextBox;
      this.InitializeComponent();
    }

    private void ReplaceDialog_Load(object sender, EventArgs e)
    {
      ReplaceDialog.CurrentInstance = this;
      this.Location = new Point(this.Owner.Location.X + (this.Owner.Width - this.Width) / 2 + 40, this.Owner.Location.Y + (this.Owner.Height - this.Height) / 2);
      this.txtBefore.ForeColor = Setting.ForeColor;
      this.txtBefore.BackColor = Setting.BackColor;
      this.txtAfter.ForeColor = Setting.ForeColor;
      this.txtAfter.BackColor = Setting.BackColor;
    }

    private void ReplaceDialog_FormClosed(object sender, FormClosedEventArgs e)
    {
      ReplaceDialog.CurrentInstance = (ReplaceDialog) null;
    }

    private void btnClose_Click(object sender, EventArgs e) => this.Close();

    private StringFinder search(int startIndex, string src, bool downSearch)
    {
      StringFinder stringFinder = new StringFinder();
      stringFinder.DownSearch = downSearch;
      stringFinder.Src = src;
      stringFinder.FindStr = this.txtBefore.Text;
      stringFinder.ReplaceStr = this.txtAfter.Text;
      stringFinder.IgnoreCase = !this.chkIgnoreCase.Checked;
      stringFinder.UseRegex = this.chkRegex.Checked;
      stringFinder.Search();
      if (startIndex != -1)
      {
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
      return stringFinder;
    }

    private void replace()
    {
      StringFinder stringFinder = this.search(-1, this.textBox.SelectedText, true);
      if (stringFinder.ResultIndex != -1)
      {
        this.textBox.ChangeSelectedText(stringFinder.ResultReplaceStr);
      }
      else
      {
        this.textBox.Select(this.textBox.SelectionStart, 0);
        this.textBox.ScrollToCaretDelg();
      }
      this.btnSearchDown_Click((object) null, (EventArgs) null);
    }

    private void btnSearchUp_Click(object sender, EventArgs e)
    {
      this.search(0, this.textBox.Text.Substring(0, this.textBox.SelectionStart), false);
    }

    private void btnSearchDown_Click(object sender, EventArgs e)
    {
      int startIndex = this.textBox.SelectionStart + this.textBox.SelectionLength;
      string src = this.textBox.Text.Substring(startIndex, this.textBox.Text.Length - startIndex);
      this.search(startIndex, src, true);
    }

    private void btnReplace_Click(object sender, EventArgs e) => this.replace();

    private void btnReplaceAll_Click(object sender, EventArgs e)
    {
      this.textBox.EnableRedrawLock(true);
      this.textBox.Select(0, 0);
      do
      {
        this.replace();
      }
      while (this.textBox.SelectionLength > 0);
      this.textBox.EnableRedrawLock(false);
    }
  }
}

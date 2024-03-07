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
  public class AddIdiomDialog : Form
  {
    private IContainer components;
    private Button btnOK;
    private Button btnCancel;
    private Label lblIdiomName;
    private TextBox txtIdiomName;
    private Label lblIdiomText;
    private TextBox txtIdiomText;

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
      this.lblIdiomName = new Label();
      this.txtIdiomName = new TextBox();
      this.lblIdiomText = new Label();
      this.txtIdiomText = new TextBox();
      this.SuspendLayout();
      this.btnOK.Anchor = AnchorStyles.Bottom;
      this.btnOK.Location = new Point(123, 236);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 21);
      this.btnOK.TabIndex = 0;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.btnCancel.Anchor = AnchorStyles.Bottom;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(220, 236);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 21);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "キャンセル";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.lblIdiomName.AutoSize = true;
      this.lblIdiomName.Location = new Point(19, 24);
      this.lblIdiomName.Name = "lblIdiomName";
      this.lblIdiomName.Size = new Size(29, 12);
      this.lblIdiomName.TabIndex = 2;
      this.lblIdiomName.Text = "名前";
      this.txtIdiomName.Font = new Font("ＭＳ ゴシック", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtIdiomName.Location = new Point(69, 21);
      this.txtIdiomName.Name = "txtIdiomName";
      this.txtIdiomName.Size = new Size(260, 19);
      this.txtIdiomName.TabIndex = 3;
      this.lblIdiomText.AutoSize = true;
      this.lblIdiomText.Location = new Point(19, 55);
      this.lblIdiomText.Name = "lblIdiomText";
      this.lblIdiomText.Size = new Size(29, 12);
      this.lblIdiomText.TabIndex = 4;
      this.lblIdiomText.Text = "内容";
      this.txtIdiomText.AcceptsReturn = true;
      this.txtIdiomText.Font = new Font("ＭＳ ゴシック", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.txtIdiomText.Location = new Point(69, 53);
      this.txtIdiomText.Multiline = true;
      this.txtIdiomText.Name = "txtIdiomText";
      this.txtIdiomText.ScrollBars = ScrollBars.Both;
      this.txtIdiomText.Size = new Size(318, 171);
      this.txtIdiomText.TabIndex = 5;
      this.txtIdiomText.WordWrap = false;
      this.txtIdiomText.KeyDown += new KeyEventHandler(this.txtIdiomText_KeyDown);
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(418, 269);
      this.Controls.Add((Control) this.txtIdiomText);
      this.Controls.Add((Control) this.lblIdiomText);
      this.Controls.Add((Control) this.txtIdiomName);
      this.Controls.Add((Control) this.lblIdiomName);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (AddIdiomDialog);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "イディオムの追加";
      this.Load += new EventHandler(this.AddIdiomDialog_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public string IdiomName
    {
      get => this.txtIdiomName.Text;
      set => this.txtIdiomName.Text = value;
    }

    public string IdiomText
    {
      get => this.txtIdiomText.Text;
      set => this.txtIdiomText.Text = value;
    }

    public bool Modify { get; set; }

    public AddIdiomDialog() => this.InitializeComponent();

    private void AddIdiomDialog_Load(object sender, EventArgs e)
    {
      if (this.Modify)
      {
        this.Text = "イディオムの編集";
        this.ActiveControl = (Control) this.txtIdiomText;
        this.txtIdiomText.Select(0, 0);
      }
      else
        this.ActiveControl = (Control) this.txtIdiomName;
      this.txtIdiomName.ForeColor = Setting.ForeColor;
      this.txtIdiomName.BackColor = Setting.BackColor;
      this.txtIdiomText.ForeColor = Setting.ForeColor;
      this.txtIdiomText.BackColor = Setting.BackColor;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (this.txtIdiomName.Text == "")
      {
        int num = (int) MessageBox.Show("名前が未入力です。");
        this.txtIdiomName.Focus();
      }
      else if (this.txtIdiomText.Text == "")
      {
        int num = (int) MessageBox.Show("内容が未入力です。");
        this.txtIdiomText.Focus();
      }
      else
      {
        if (!this.Modify && Setting.IdiomDic.ContainsKey(this.txtIdiomName.Text) && MessageBox.Show("指定された名前のイディオムはすでに登録されています。\n内容を上書きしてよろしいですか？", "確認", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
          return;
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private void btnCancel_Click(object sender, EventArgs e) => this.Close();

    private void txtIdiomText_KeyDown(object sender, KeyEventArgs e)
    {
      TextBox textBox = (TextBox) sender;
      switch (e.KeyCode)
      {
        case Keys.Return:
          if (!e.Control)
            break;
          this.btnOK.PerformClick();
          break;
        case Keys.A:
          if (!e.Control)
            break;
          textBox.SelectAll();
          break;
      }
    }
  }
}

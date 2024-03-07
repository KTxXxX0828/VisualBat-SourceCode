/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace VisualBat
{
  public class CommandReferenceDialog : Form
  {
    private IContainer components;
    private Button btnCancel;
    private SplitContainer sptReferenceVertical;
    private ListBox lstReferenceIndex;
    private TextBox txtReferenceText;
    private ComboBox cmbSelectType;
    private Panel pnlSelectType;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.btnCancel = new Button();
      this.sptReferenceVertical = new SplitContainer();
      this.lstReferenceIndex = new ListBox();
      this.pnlSelectType = new Panel();
      this.cmbSelectType = new ComboBox();
      this.txtReferenceText = new TextBox();
      this.sptReferenceVertical.Panel1.SuspendLayout();
      this.sptReferenceVertical.Panel2.SuspendLayout();
      this.sptReferenceVertical.SuspendLayout();
      this.pnlSelectType.SuspendLayout();
      this.SuspendLayout();
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.Location = new Point(12, 12);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 0;
      this.btnCancel.TabStop = false;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.sptReferenceVertical.Dock = DockStyle.Fill;
      this.sptReferenceVertical.FixedPanel = FixedPanel.Panel1;
      this.sptReferenceVertical.Location = new Point(0, 0);
      this.sptReferenceVertical.Name = "sptReferenceVertical";
      this.sptReferenceVertical.Panel1.Controls.Add((Control) this.lstReferenceIndex);
      this.sptReferenceVertical.Panel1.Controls.Add((Control) this.pnlSelectType);
      this.sptReferenceVertical.Panel2.Controls.Add((Control) this.txtReferenceText);
      this.sptReferenceVertical.Size = new Size(615, 468);
      this.sptReferenceVertical.SplitterDistance = 110;
      this.sptReferenceVertical.TabIndex = 1;
      this.lstReferenceIndex.BorderStyle = BorderStyle.FixedSingle;
      this.lstReferenceIndex.Dock = DockStyle.Fill;
      this.lstReferenceIndex.Font = new Font("ＭＳ ゴシック", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.lstReferenceIndex.FormattingEnabled = true;
      this.lstReferenceIndex.ItemHeight = 12;
      this.lstReferenceIndex.Location = new Point(0, 28);
      this.lstReferenceIndex.Name = "lstReferenceIndex";
      this.lstReferenceIndex.Size = new Size(110, 434);
      this.lstReferenceIndex.TabIndex = 0;
      this.lstReferenceIndex.SelectedValueChanged += new EventHandler(this.lstReferenceIndex_SelectedValueChanged);
      this.pnlSelectType.Controls.Add((Control) this.cmbSelectType);
      this.pnlSelectType.Dock = DockStyle.Top;
      this.pnlSelectType.Location = new Point(0, 0);
      this.pnlSelectType.Name = "pnlSelectType";
      this.pnlSelectType.Padding = new Padding(4);
      this.pnlSelectType.Size = new Size(110, 28);
      this.pnlSelectType.TabIndex = 2;
      this.cmbSelectType.Dock = DockStyle.Fill;
      this.cmbSelectType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cmbSelectType.FormattingEnabled = true;
      this.cmbSelectType.Location = new Point(4, 4);
      this.cmbSelectType.Name = "cmbSelectType";
      this.cmbSelectType.Size = new Size(102, 20);
      this.cmbSelectType.TabIndex = 1;
      this.cmbSelectType.SelectedValueChanged += new EventHandler(this.cmbSelectType_SelectedValueChanged);
      this.txtReferenceText.BackColor = Color.White;
      this.txtReferenceText.Dock = DockStyle.Fill;
      this.txtReferenceText.Font = new Font("ＭＳ ゴシック", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.txtReferenceText.Location = new Point(0, 0);
      this.txtReferenceText.Multiline = true;
      this.txtReferenceText.Name = "txtReferenceText";
      this.txtReferenceText.ReadOnly = true;
      this.txtReferenceText.ScrollBars = ScrollBars.Both;
      this.txtReferenceText.Size = new Size(501, 468);
      this.txtReferenceText.TabIndex = 0;
      this.txtReferenceText.WordWrap = false;
      this.txtReferenceText.KeyDown += new KeyEventHandler(this.txtReferenceText_KeyDown);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(615, 468);
      this.Controls.Add((Control) this.sptReferenceVertical);
      this.Controls.Add((Control) this.btnCancel);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (CommandReferenceDialog);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "コマンドリファレンス";
      this.Load += new EventHandler(this.CommandReferenceDialog_Load);
      this.FormClosed += new FormClosedEventHandler(this.CommandReferenceDialog_FormClosed);
      this.FormClosing += new FormClosingEventHandler(this.CommandReferenceDialog_FormClosing);
      this.sptReferenceVertical.Panel1.ResumeLayout(false);
      this.sptReferenceVertical.Panel2.ResumeLayout(false);
      this.sptReferenceVertical.Panel2.PerformLayout();
      this.sptReferenceVertical.ResumeLayout(false);
      this.pnlSelectType.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public static CommandReferenceDialog CurrentInstance { get; set; }

    public ListBox LstReferenceIndex => this.lstReferenceIndex;

    public TextBox TxtReferenceText => this.txtReferenceText;

    public CommandReferenceDialog() => this.InitializeComponent();

    private void CommandReferenceDialog_Load(object sender, EventArgs e)
    {
      CommandReferenceDialog.CurrentInstance = this;
      this.btnCancel.Location = new Point(-100, 0);
      this.cmbSelectType.Items.Add((object) new CommandReferenceDialog.CommandTypeComboElem(CommandType.All));
      this.cmbSelectType.Items.Add((object) new CommandReferenceDialog.CommandTypeComboElem(CommandType.Control));
      this.cmbSelectType.Items.Add((object) new CommandReferenceDialog.CommandTypeComboElem(CommandType.InOut));
      this.cmbSelectType.Items.Add((object) new CommandReferenceDialog.CommandTypeComboElem(CommandType.File));
      this.cmbSelectType.Items.Add((object) new CommandReferenceDialog.CommandTypeComboElem(CommandType.Drive));
      this.cmbSelectType.Items.Add((object) new CommandReferenceDialog.CommandTypeComboElem(CommandType.System));
      this.cmbSelectType.Items.Add((object) new CommandReferenceDialog.CommandTypeComboElem(CommandType.Network));
      this.cmbSelectType.Items.Add((object) new CommandReferenceDialog.CommandTypeComboElem(CommandType.Other));
      this.cmbSelectType.SelectedItem = this.cmbSelectType.Items[0];
      if (Setting.RememberLayout && Setting.LastCRWidth > 0)
      {
        this.SetDesktopLocation(Setting.LastCRX, Setting.LastCRY);
        this.Width = Setting.LastCRWidth;
        this.Height = Setting.LastCRHeight;
        this.sptReferenceVertical.SplitterDistance = Setting.CRReferenceVertical;
      }
      this.lstReferenceIndex.ForeColor = Setting.ForeColor;
      this.lstReferenceIndex.BackColor = Setting.BackColor;
      this.txtReferenceText.ForeColor = Setting.ForeColor;
      this.txtReferenceText.BackColor = Setting.BackColor;
    }

    public void SaveLastLayout()
    {
      Setting.LastCRX = this.Location.X;
      Setting.LastCRY = this.Location.Y;
      Setting.LastCRWidth = this.Width;
      Setting.LastCRHeight = this.Height;
      Setting.CRReferenceVertical = this.sptReferenceVertical.SplitterDistance;
    }

    private void CommandReferenceDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.SaveLastLayout();
    }

    private void CommandReferenceDialog_FormClosed(object sender, FormClosedEventArgs e)
    {
      CommandReferenceDialog.CurrentInstance = (CommandReferenceDialog) null;
    }

    private void btnCancel_Click(object sender, EventArgs e) => this.Close();

    private void cmbSelectType_SelectedValueChanged(object sender, EventArgs e)
    {
      CommandType cmdType = (this.cmbSelectType.SelectedItem as CommandReferenceDialog.CommandTypeComboElem).CmdType;
      this.lstReferenceIndex.Items.Clear();
      foreach (KeyValuePair<string, CommandData> keyValuePair in BatKeyword.Dic)
      {
        if (keyValuePair.Value.CmdType != CommandType.Reserved && (cmdType == CommandType.All || cmdType == keyValuePair.Value.CmdType))
          this.lstReferenceIndex.Items.Add((object) keyValuePair.Value);
      }
    }

    private void lstReferenceIndex_SelectedValueChanged(object sender, EventArgs e)
    {
      if (this.lstReferenceIndex.SelectedItem == null)
        return;
      CommandData command = (CommandData) this.lstReferenceIndex.SelectedItem;
      new Thread((ThreadStart) (() =>
      {
        if (string.IsNullOrEmpty(command.HelpText))
          command.HelpText = BatDebugger.GetCommandHelpText(command);
        this.Invoke((Delegate) (() =>
        {
          if (command != (CommandData) this.lstReferenceIndex.SelectedItem)
            return;
          this.txtReferenceText.Text = command.HelpText == "" ? "(no data)" : command.HelpText;
        }));
      }))
      {
        IsBackground = true
      }.Start();
    }

    private void txtReferenceText_KeyDown(object sender, KeyEventArgs e)
    {
      TextBox textBox = (TextBox) sender;
      if (e.KeyCode != Keys.A || !e.Control)
        return;
      textBox.SelectAll();
    }

    public void SelectItem(string command)
    {
      this.cmbSelectType.SelectedItem = this.cmbSelectType.Items[0];
      if (!BatKeyword.Dic.ContainsKey(command) || !this.lstReferenceIndex.Items.Contains((object) BatKeyword.Dic[command]))
        return;
      this.lstReferenceIndex.SelectedItem = (object) BatKeyword.Dic[command];
    }

    private class CommandTypeComboElem
    {
      public CommandType CmdType { get; private set; }

      public CommandTypeComboElem(CommandType cmdType) => this.CmdType = cmdType;

      public override string ToString()
      {
        switch (this.CmdType)
        {
          case CommandType.Control:
            return "制御系";
          case CommandType.InOut:
            return "入出力系";
          case CommandType.File:
            return "ファイル系";
          case CommandType.Drive:
            return "ドライブ系";
          case CommandType.System:
            return "システム系";
          case CommandType.Network:
            return "ネットワーク系";
          case CommandType.Other:
            return "コマンド/その他";
          case CommandType.All:
            return "ALL";
          default:
            return "";
        }
      }
    }
  }
}

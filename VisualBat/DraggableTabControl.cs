/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace VisualBat
{
  internal class DraggableTabControl : TabControl
  {
    private int mouseDownPointX;
    private int mouseDownPointY;
    private Rectangle dragBoxFromMouseDown = Rectangle.Empty;
    private bool dragCancel;

    private TabPage GetTabPageByTab(Point pt)
    {
      TabPage tabPageByTab = (TabPage) null;
      for (int index = 0; index < this.TabPages.Count; ++index)
      {
        if (this.GetTabRect(index).Contains(pt))
        {
          tabPageByTab = this.TabPages[index];
          break;
        }
      }
      return tabPageByTab;
    }

    private int FindIndex(TabPage page)
    {
      for (int index = 0; index < this.TabPages.Count; ++index)
      {
        if (this.TabPages[index] == page)
          return index;
      }
      return -1;
    }

    protected override void OnDragOver(DragEventArgs e)
    {
      base.OnDragOver(e);
      TabPage tabPageByTab = this.GetTabPageByTab(this.PointToClient(new Point(e.X, e.Y)));
      if (tabPageByTab != null)
      {
        if (!e.Data.GetDataPresent(typeof (TabPage)))
          return;
        e.Effect = DragDropEffects.Move;
        TabPage data = (TabPage) e.Data.GetData(typeof (TabPage));
        int index1 = this.FindIndex(data);
        int index2 = this.FindIndex(tabPageByTab);
        if (index1 == index2)
        {
          this.dragCancel = false;
        }
        else
        {
          if (this.dragCancel)
            return;
          this.SuspendLayout();
          TabPage tabPage = this.TabPages[index1];
          this.TabPages[index1] = this.TabPages[index2];
          this.TabPages[index2] = tabPage;
          this.SelectedTab = data;
          this.ResumeLayout();
          this.dragCancel = true;
        }
      }
      else
        e.Effect = DragDropEffects.None;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      if (!(this.dragBoxFromMouseDown != Rectangle.Empty) || this.dragBoxFromMouseDown.Contains(e.X, e.Y) || this.TabCount <= 1)
        return;
      TabPage tabPageByTab = this.GetTabPageByTab(new Point(this.mouseDownPointX, this.mouseDownPointY));
      if (tabPageByTab == null)
        return;
      int num = (int) this.DoDragDrop((object) tabPageByTab, DragDropEffects.All);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      this.ClearDragTarget();
      if (e.Button != MouseButtons.Left || e.Clicks >= 2)
        return;
      this.SetupDragTarget(e.X, e.Y);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      this.ClearDragTarget();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);
      this.ClearDragTarget();
    }

    private void ClearDragTarget()
    {
      this.dragBoxFromMouseDown = Rectangle.Empty;
      this.mouseDownPointX = 0;
      this.mouseDownPointY = 0;
    }

    private void SetupDragTarget(int x, int y)
    {
      Size dragSize = SystemInformation.DragSize;
      this.dragBoxFromMouseDown = new Rectangle(new Point(x - dragSize.Width / 2, y - dragSize.Height / 2), dragSize);
      this.mouseDownPointX = x;
      this.mouseDownPointY = y;
    }
  }
}

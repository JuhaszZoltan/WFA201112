/*
	private void LbOktatok_DrawItem(object sender, DrawItemEventArgs e)
	{
		e.DrawBackground();
		Graphics g = e.Graphics;
		Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
		Brushes.Orange : new SolidBrush(e.BackColor);
		g.FillRectangle(brush, e.Bounds);
		e.Graphics.DrawString(
		(sender as ListBox).Items[e.Index].ToString(), e.Font, 
			new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
		e.DrawFocusRectangle();
	}
*/
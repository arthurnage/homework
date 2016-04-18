using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	private bool sign; // 0 when it's X, 1 when it's O
	private short count; //when count is 9 the game ends

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	protected void OnButtonClicked(object sender, EventArgs e)
	{
		var button = (Button)sender;
		if (button.Label == null)
		{
			button.Label = sign ? "O" : "X";
			sign = !sign;
			count++;
			if (count == 9)
			{
				resultScreen.Text = "the end";
			}
		}
	}
}
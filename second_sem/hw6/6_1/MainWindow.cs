using System;
using Gtk;
using MyWorks;

public partial class MainWindow: Gtk.Window
{
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
		if (button.Label == "0")
		{
			if (screen.Text.Length > 3 && screen.Text[screen.Text.Length - 2] == '/')
			{
				screen.Text = "infinity, press clear";
				return;
			}
		}
		screen.Text = screen.Text + button.Label;
	}

	protected void OnButtonOperationClicked(object sender, EventArgs e)
	{
		if (screen.Text == "")
		{
			return;
		}
		var button = (Button)sender;
		if (screen.Text[screen.Text.Length - 1] == ' ')
		{
			screen.Text = screen.Text.Remove(screen.Text.Length - 3);
		}
		screen.Text = CalculateMachine.Calculate(screen.Text);
		screen.Text = screen.Text + " " + button.Label + " ";
	}

	protected void OnButtonResultClicked(object sender, EventArgs e)
	{
		screen.Text = CalculateMachine.Calculate(screen.Text);
	}

	protected void OnButtonClearClicked(object sender, EventArgs e)
	{
		screen.Text = "";
	}
}
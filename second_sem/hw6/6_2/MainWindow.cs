using System;
using Gtk;
using System.Timers;

public partial class MainWindow: Gtk.Window
{
	private Timer timer;

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		timer = new Timer();
		timer.Start();
		timer.Elapsed += SetTime;
		Build();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	protected void SetTime(object sender, EventArgs e)
	{
		watch.Text = DateTime.Now.ToString();
	}
}

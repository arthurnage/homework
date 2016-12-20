using System;
using Gtk;

namespace MyWorks
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Application.Init();
			var window = new MainWindow();
			window.Show();
			Application.Run();
		}
	}
}
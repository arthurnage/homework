using System;
using Gtk;
using System.Reflection;

namespace MyWorks
{
	/// <summary>
	/// Main class.
	/// </summary>
	class MainClass
	{
		private static Button chooseButton;
		private static Table table;
		private static ComboBox classes;
		private static ComboBox methods;
		private static ComboBox paramethers;
		private static Assembly assembly;
		private static Window win;

		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main(string[] args)
		{
			Application.Init();
			win = new Window("viewer");
			win.Resize(500, 300);
			chooseButton = new Button("choose");
			var classStore = new ListStore(typeof(string));
			var methodStore = new ListStore(typeof(string));
			var parametherStore = new ListStore(typeof(string));
			classes = new ComboBox(classStore);
			methods = new ComboBox(methodStore);
			paramethers = new ComboBox(parametherStore);
			classes = ComboBox.NewText();
			methods = ComboBox.NewText();
			paramethers = ComboBox.NewText();

			win.DeleteEvent += new DeleteEventHandler(OnWinDelete);
			chooseButton.Clicked += AddClass;
			classes.Changed += AddMethods;
			methods.Changed += AddParamethers;

			table = new Table(4, 1, false);
			table.Attach(chooseButton, 0, 1, 0, 1);
			table.Attach(classes, 0, 1, 1, 2);
			table.Attach(methods, 0, 1, 2, 3);
			table.Attach(paramethers, 0, 1, 3, 4);
			win.Add(table);
			win.ShowAll();
			Application.Run();
		}

		/// <summary>
		/// Adds the class.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private static void AddClass(object sender, EventArgs e)
		{
			Gtk.FileChooserDialog fileChooser = new Gtk.FileChooserDialog
					("Choose the file to open",
					win, 
					FileChooserAction.Open,
					"Cancel", ResponseType.Cancel,
					"Open", ResponseType.Accept);
			fileChooser.Filter = new FileFilter();
			fileChooser.Filter.AddPattern("*.exe");
			fileChooser.Filter.AddPattern("*.dll");
			if (fileChooser.Run() == (int)ResponseType.Accept) 
			{
				try
				{
					Console.WriteLine();
					assembly = Assembly.LoadFile(fileChooser.Filename);	
				}
				catch (System.IO.FileNotFoundException) { return; }
				catch (System.ArgumentNullException) { return; }
				Clear(classes);
				Clear(methods);
				Clear(paramethers);
				foreach (var singleClass in assembly.GetTypes()) 
				{
					classes.AppendText(singleClass.FullName);
				}
			}
			fileChooser.Destroy();
		}

		/// <summary>
		/// Adds the methods.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private static void AddMethods(object sender, EventArgs e)
		{
			var name = classes.ActiveText.ToString();
			var currentClass = assembly.GetType(name);
			Clear(methods);
			Clear(paramethers);
			foreach (var method in currentClass.GetMethods())
			{
				methods.AppendText(method.Name);
			}
		}

		/// <summary>
		/// Adds the paramethers.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private static void AddParamethers(object sender, EventArgs e)
		{
			var currentClassName = classes.ActiveText.ToString();
			var currentClass = assembly.GetType(currentClassName);
			var currentMethodName = methods.ActiveText.ToString();
			var currentMethod = currentClass.GetMethod(currentMethodName);
			Clear(paramethers);
			foreach (var paramether in currentMethod.GetParameters())
			{
				paramethers.AppendText(paramether.Name);
			}
		}
			
		/// <summary>
		/// Clear the specified box.
		/// </summary>
		/// <param name="box">Box.</param>
		private static void Clear(ComboBox box)
		{
			var score = new ListStore(typeof(string));
			box.Model = score;
		}

		/// <summary>
		/// Raises the window delete event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private static void OnWinDelete(object sender, EventArgs e)
		{
			Application.Quit();
		}
	}
}

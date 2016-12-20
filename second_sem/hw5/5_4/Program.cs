using System;

namespace MyWorks
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var cursorMover = new CursorMover(Console.CursorLeft, Console.CursorTop);
			var eventLoop = new EventLoop();
			eventLoop.UpHandler += cursorMover.UpArrowPressed;
			eventLoop.DownHandler += cursorMover.DownArrowPressed;
			eventLoop.LeftHandler += cursorMover.LeftArrowPressed;
			eventLoop.RightHandler += cursorMover.RightArrowPressed;
			eventLoop.Run();
		}
	}
}

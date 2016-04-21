using System;

namespace MyWorks
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var eventLoop = new EventLoop();
			eventLoop.Run();
		}
	}
}

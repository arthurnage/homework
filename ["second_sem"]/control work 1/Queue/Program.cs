using System;

namespace MyWorks
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Queue queue = new Queue();
			queue.Enqueue(1, 1);
			queue.Enqueue(2, 2);
			queue.Enqueue(3, 4);
			queue.Enqueue(999, -1);
			queue.Print();
			Console.WriteLine(queue.Dequeue());
			queue.Print();
		}
	}
}

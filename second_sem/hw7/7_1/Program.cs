using System;

namespace MyWorks
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			List<int> list = new List<int>();
			//list.Pop();
			list.Push(1);
			list.Push(2);
			list.Push(3);
			list.Push(4);

			list.Remove(2);
		}
	}
}

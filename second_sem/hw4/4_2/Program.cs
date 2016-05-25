using System;

namespace MyWorks
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			UniqueList list = new UniqueList();
			list.Push(5);
			list.Push(3);
			list.Push(2);
			list.Remove(3);
		}
	}
}

using System;

namespace MyWorks
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Tree tree = new Tree("( / ( - 5 2 ) ( - 3 3 ) )");
			Console.WriteLine(tree.Calculate());
		}
	}
}

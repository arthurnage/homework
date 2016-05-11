using System;

namespace MyWorks
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var set = new Set<int>();
			var newSet = new Set<int>();
			set.Add(1);
			set.Add(2);
			set.Add(3);
			newSet.Add(3);
			newSet.Add(4);
			newSet.Add(5);
			newSet = set.Union(newSet);
			for (int i = 1; i <= 5; ++i)
			{
				Console.WriteLine(newSet.IsBelong(i));
			}
		}
	}
}

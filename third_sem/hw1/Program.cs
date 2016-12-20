using System;
using System.Collections.Generic;
using System.Collections;

namespace MyWorks
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var tree = new Tree<int>();
            tree.Add(10);
            tree.Add(4);
            tree.Add(5);
            tree.Add(11);
            int sum = 0;
            foreach (int value in tree)
            {
                sum += value;
            }
            Console.WriteLine(sum);
		}
	}
}

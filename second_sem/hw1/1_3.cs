using System;
namespace _3
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int[] array = new int[100];
			Console.WriteLine("enter a number of array elements");
			int n = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("enter array elements");
			for (int i = 0; i < n; ++i) 
			{
				array [i] = Convert.ToInt32(Console.ReadLine());
			}
			Console.WriteLine("array:");
			for (int i = 0; i < n; ++i) 
			{
				Console.Write(array [i]);
				Console.Write(" ");
			}
			Console.WriteLine();
			for (int i = 0; i < n - 1; ++i) {
				for (int j = 0; j < n - i - 1; ++j) {
					if (array [j] > array [j + 1]) {
						int k = array [j + 1];
						array [j + 1] = array [j];
						array [j] = k;
					}
				}
			}
			Console.WriteLine("sorted array:");
			for (int i = 0; i < n; ++i) 
			{
				Console.Write(array [i]);
				Console.Write(" ");
			}
		}
	}
	//class for array sorting by using bubblesort
}

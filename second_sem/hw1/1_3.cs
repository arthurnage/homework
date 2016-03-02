using System;

namespace MyWorks
{
	// class for sorting an array
	class MainClass
	{
		// main method
		public static void Main (string[] args)
		{
			int[] array = new int[100];
			Console.WriteLine("enter a number of array elements");
			int n = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("enter array elements");
			for (int i = 0; i < n; ++i) 
			{
				array[i] = Convert.ToInt32(Console.ReadLine());
			}
			Console.WriteLine("array:");
			for (int i = 0; i < n; ++i) 
			{
				Console.Write(array [i]);
				Console.Write(" ");
			}
			Console.WriteLine();
			array = BubbleSort(array, n);
			// out
			Console.WriteLine("sorted array:");
			for (int i = 0; i < n; ++i) 
			{
				Console.Write(array[i]);
				Console.Write(" ");
			}
		}

		// function for bubblesorting
		public static int[] BubbleSort(int[] array)
		{
			for (int i = 0; i < array.GetLength() - 1; ++i) 
			{
				for (int j = 0; j < array.GetLength() - i - 1; ++j) 
				{
					if (array[j] > array[j + 1]) 
					{
						int k = array[j + 1];
						array[j + 1] = array[j];
						array[j] = k;
					}
				}
			}
			return array;
		}
	}
}
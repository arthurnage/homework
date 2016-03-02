using System;

namespace MyWorks
{
	// class for calculating a fibonacci numbers
	class MainClass
	{
		// main method
		public static void Main(string[] args)
		{
			Console.WriteLine("enter a number");
			int i = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine(Fibonacci(i));
		}

		// a function for calculating fibonacci numbers
		public static long Fibonacci(int n)
		{
			long previousNumber = 1;
			long sum = 2;
			for (int i = 3; i < n; ++i)
			{
				long currentSum = sum + previousNumber;
				previousNumber = sum;
				sum = currentSum;
			}
			if (n < 3)
			{
				return 1;
			}
			else
			{
				return sum;
			}
		}
	}
}

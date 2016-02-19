using System;
namespace Fibonacci
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("enter a number");
			int i = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine(Fibonacci(i));
		}

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
		// function for calculating the fibonacci number
	}
	//class MainClass for calculating the fibonacci number
}

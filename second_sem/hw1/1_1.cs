using System;

namespace MyWorks
{
	// main class for calculating a factorial of number
	class MainClass
	{
		// main method
		public static void Main(string[] args)
		{
			int number = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine();
			Console.WriteLine(number);
			Console.WriteLine(Factorial(number));
		}

		// function for calculating a factorial of number
		private static int Factorial(int n)
		{
			if (n > 0)
			{
				return n * Factorial(n - 1);
			}
			else
			{
				return 1;
			}
		}
	}
}

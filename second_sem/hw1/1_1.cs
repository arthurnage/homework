using System;
namespace Programm
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int number = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine();
			Console.WriteLine(number);
			Console.WriteLine(Factorial(number));
		}

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
		// function for calculating the factorial
	}
	// class for calculating the factorial
}

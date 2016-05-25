using System;

namespace MyWorks
{
	//class for using callculator
	class MainClass
	{
		// main method
		public static void Main(string[] args)
		{
			Calculator calculator = new Calculator();
			calculator.Push(5);
			calculator.Push(3);
			calculator.Multiply(); // 3 * 5
			calculator.Push(2);
			calculator.Add(); // 2 + 15
			calculator.Push(6);
			calculator.RemainderDivide();// 17 % 6 = 5
			Console.WriteLine(calculator.Result());
		}
	}
}

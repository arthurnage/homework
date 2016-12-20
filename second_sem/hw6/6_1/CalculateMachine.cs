using System;

namespace MyWorks
{
	// a class for calculating expressions by using StackCalculator class
	public class CalculateMachine
	{
		// calculating an expression
		public static string Calculate(string expression)
		{
			string firstNum = "";
			char operation;
			string secondNum = "";
			int index = 0;
			while (index < expression.Length && expression[index] != ' ')
			{
				firstNum = firstNum + expression[index++];
			}
			if (index == expression.Length)
			{
				return firstNum;
			}
			index++; // red a spacebar
			operation = expression[index++];
			index++; // red another spacebar
			while (index < expression.Length && expression[index] != ' ')
			{
				secondNum = secondNum + expression[index++];
			}
			int first = Convert.ToInt32(firstNum);
			int second = Convert.ToInt32(secondNum);
			Calculator calculator = new Calculator();
			calculator.Push(first);
			calculator.Push(second);
			switch (operation)
			{
			case '+':
				{
					calculator.Add();
				}
				break;
			case '-':
				{
					calculator.Substract();
				}
				break;
			case '*':
				{
					calculator.Multiply();
				}
				break;
			case '/':
				{
					calculator.IntDivide();
				}
				break;
			default:
				{
					throw new Exception("wrong line format");
				}
			}
			return Convert.ToString(calculator.Result());

		}
	}
}


using System;

namespace MyWorks
{
	// class appears as a stack calculator
	public class Calculator
	{
		// stack of numbers
		private List stack;

		// constructor
		public Calculator()
		{
			stack = new List();
		}

		// adding a number to the stack
		public void Push(int number)
		{
			stack.Push(number);
		}

		// pops 2 numbers from the stack, adds them and pushes the sum to the stack
		public void Add()
		{
			int first = stack.Pop();
			int second = stack.Pop();
			stack.Push(first + second);
		}

		// pops 2 numbers from the stack, multiplies them and pushes the multiplication to the stack
		public void Multiply()
		{
			int first = stack.Pop();
			int second = stack.Pop();
			stack.Push(first * second);
		}

		// pops 2 numbers from the stack, substract first number from the second one and pushes the difference to the stack
		public void Substract()
		{
			int first = stack.Pop();
			int second = stack.Pop();
			stack.Push(second - first);
		}

		// pops 2 numbers from the stack, divides the second one by the first and pushes the quotient to the stack
		public void IntDivide()
		{
			int first = stack.Pop();
			int second = stack.Pop();
			stack.Push(second / first);
		}

		// pops 2 numbers from the stack, divides the first one by the second and pushes the remainder to the stack
		public void RemainderDivide()
		{
			int first = stack.Pop();
			int second = stack.Pop();
			stack.Push(second % first);
		}

		// returns a number from stack
		public int Result()
		{
			return stack.Value();
		}
	}
}


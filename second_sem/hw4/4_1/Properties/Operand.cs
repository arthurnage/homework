 using System;

namespace MyWorks
{
	// class realising a tree node
	public class Operand : ITreeNode
	{
		// constructor
		public Operand(int value)
		{
			Value = value;
		}

		// value of the operand
		public int Value { set; get; }

		// prints an operand
		public void Print()
		{
			Console.Write(Value + ' ');
		}

		// this method returns an argument to operator
		public int Calculate()
		{
			return Value;
		}
	}
}
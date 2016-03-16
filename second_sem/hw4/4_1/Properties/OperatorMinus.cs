using System;

namespace MyWorks
{
	public class OperatorMinus : Operator
	{
		public override void Print()
		{
			Console.Write("( - ");
			this.Left.Print();
			this.Right.Print();
			Console.Write(") ");
		}

		public override int Calculate()
		{
			return this.Left.Calculate() - this.Right.Calculate();
		}
	}
}


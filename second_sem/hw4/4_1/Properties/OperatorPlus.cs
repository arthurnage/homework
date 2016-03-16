using System;

namespace MyWorks
{
	public class OperatorPlus : Operator
	{
		public override void Print()
		{
			Console.Write("( + ");
			this.Left.Print();
			this.Right.Print();
			Console.Write(") ");
		}

		public override int Calculate()
		{
			return this.Right.Calculate() + this.Left.Calculate();
		}
	}
}


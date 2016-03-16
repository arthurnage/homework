using System;

namespace MyWorks
{
	public class OperatorDivide : Operator
	{
		public override void Print()
		{
			Console.Write("( / ");
			this.Left.Print();
			this.Right.Print();
			Console.Write(") ");
		}

		public override int Calculate()
		{
			if (this.Right.Calculate() == 0)
			{
				Console.WriteLine("division by zero!");
				throw new Exception("division by 0");
			}
			return this.Left.Calculate() / this.Right.Calculate();
		}
	}
}


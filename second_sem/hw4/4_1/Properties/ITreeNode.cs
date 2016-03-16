using System;

namespace MyWorks
{
	// inteface for the tree node
	// it can be operand or operator
	public interface ITreeNode
	{
		// prints an expression
		void Print();

		// calculates an expression
		int Calculate();
	}
}


using System;

namespace MyWorks
{
	// class realising a tree node
	public class Operator : ITreeNode
	{
		//properties
		public ITreeNode Left { set; get; }
		public ITreeNode Right { set; get; }
		// the result

		// prints expression in such form: ( operator Left Right )
		public virtual void Print()
		{
		}

		// calculates expression from Left and Right tree nodes
		public virtual int Calculate()
		{
			throw new Exception();
		}
	}
}


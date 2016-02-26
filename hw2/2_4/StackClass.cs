using System;
using StackInterface;

namespace StackNamespace
{
	public class Stack : IStack
	{
		StackElement top;

		// class appearing as a stack element
		private class StackElement
		{
			private int data;
			private StackElement next;

			// constructor
			public StackElement(int value, StackElement nextElement)
			{
				data = value;
				next = nextElement;
			}

			//access to data of a stack element
			public int Value
			{
				get { return data; }
				set { data = value; }
			}

			//access to next stack element
			public StackElement Next
			{
				get { return next; }
				set { next = value; }
			}
		}

		// constructor
		public Stack()
		{
			top = null;
		}

		// returns value in the top of the stack
		public int Value()
		{
			return top.Value;
		}

		// deletes an element in the top of the stack
		public int Pop()
		{
			int value = top.Value;
			top = top.Next;
			return value;
		}

		// adds an element to the top of the stack
		public void Push(int value)
		{
			StackElement newElement = new StackElement(value, top);
			top = newElement;
		}

		// checks is the stack empty
		public bool IsEmpty()
		{
			if (top == null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}


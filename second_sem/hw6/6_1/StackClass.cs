using System;

namespace MyWorks
{
	public class Stack
	{
		StackElement top;

		// class appearing as a stack element
		private class StackElement
		{
			public int Value { set; get; }
			public StackElement Next { set; get; }

			// constructor
			public StackElement(int value, StackElement nextElement)
			{
				Value = value;
				Next = nextElement;
			}
		}

		// constructor
		public Stack() { }

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
			return top == null;
		}
	}
}


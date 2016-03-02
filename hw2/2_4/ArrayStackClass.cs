using System;

namespace MyWorks
{
	// class for using an array stack
	public class ArrayStack : IStack
	{
		private int[] array;
		private int index;
		public ArrayStack()
		{
			array = new int[50];
			index = 0;
		}

		// adds an element to the top of the stack
		public void Push(int value)
		{
			if (index == 49)
			{
				Console.WriteLine("stack overflow");
				return;
			}
			array[index++] = value;
		}

		// deletes an element in the top of the stack
		public int Pop()
		{
			if (index == 0)
			{
				Console.WriteLine("a stack is empty");
				return 0;
			}
			int value = array[index--];
			return value;
		}

		// checks is the stack empty
		public	bool IsEmpty()
		{
			return (index == 0);
		}

		// returns value from the top of stack
		public int Value()
		{
			return array[index];
		}
	}
}


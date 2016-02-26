using System;
using StackInterface;

namespace ArrayStackClass
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
			array[++index] = value;
		}

		// deletes an element in the top of the stack
		public int Pop()
		{
			int value = array[index];
			index--;
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


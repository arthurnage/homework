using System;

namespace MyWorks
{
	// interface for working with a stack
	public interface IStack
	{
		// adds an element to the top of the stack
		void Push(int value);

		// deletes an element in the top of the stack
		int Pop();

		// checks is the stack empty
		bool IsEmpty();
	}
}
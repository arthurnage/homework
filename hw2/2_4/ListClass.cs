using System;

namespace MyWorks
{
	// class for keeping data in a list and working with it
	public class List
	{
		private ListElement top;

		// class appearing as a list element
		private class ListElement
		{
			//auto properties
			public int Value { get; set; }
			public ListElement Next { get; set; }

			//constructor
			public ListElement(int value, ListElement nextElement)
			{
				Value = value;
				Next = nextElement;
			}
		}

		// constructor
		public List() { }

		// adds a new element to the list
		public void Push(int value)
		{
			ListElement newElement = new ListElement(value, top);
			newElement.Next = top;
			top = newElement;
		}

		// deletes a top element; returns its value
		public int Pop()
		{
			int value = top.Value;
			top = top.Next;
			return value;
		}

		// returns value from the top of the list
		public int Value()
		{
			return top.Value;
		}

		// checks is the list empty
		public bool IsEmpty()
		{
			return top == null;
		}
	}
}


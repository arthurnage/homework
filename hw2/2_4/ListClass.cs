using System;

namespace ListNamespace
{
	// class for keeping data in a list and working with it
	public class List
	{
		ListElement top;

		// class appearing as a list element
		private class ListElement
		{
			private int data;
			private ListElement next;

			//constructor
			public ListElement(int value)
			{
				data = value;
			}

			//access to data of list element
			public int Value
			{
				get { return data; }
				set { data = value; }
			}

			//access to next list element
			public ListElement Next
			{
				get { return next; }
				set { next = value; }
			}
		}

		// constructor
		public List()
		{
			top = null;
		}

		// adds a new element to the list
		public void Push(int value)
		{
			ListElement newElement = new ListElement(value);
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


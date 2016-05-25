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
			public string Data { get; set }
			private ListElement Next { get; set; }

			//constructor
			public ListElement(string value, ListElement nextElement)
			{
				data = value;
				next = nextElement;
			}
		}

		// constructor
		public List() { }

		// adds a new element to the list
		public void Push(string value)
		{
			ListElement newElement = new ListElement(value, top);
			newElement.Next = top;
			top = newElement;
		}

		// deletes a top element; returns its value
		public string Pop()
		{
			string value = top.Value;
			top = top.Next;
			return value;
		}

		// returns a value of the top of the list
		public string Value()
		{
			return top.Value;
		}

		// checks is the list empty
		public bool IsEmpty()
		{
			return (top == null);
		}

		// print list
		public void Print()
		{
			ListElement current = top;
			while (current != null)
			{
				Console.Write("{0} ", current.Value);
				current = current.Next;
			}
		}

		// checks does element belong to the list
		public bool CheckForBelong(string line)
		{
			ListElement current = top;
			while (current != null)
			{
				if (string.Equals(current.Value, line))
				{
					break;
				}
				current = current.Next;
			}
			return (current == null);
		}

		public void Remove(string line)
		{
			ListElement current = top;
			if (string.Equals(current.Value, line) && current.Next == null)
			{
				top = null;
				return;
			}
			if (string.Equals(current.Next.Value, line) && current.Next.Next == null)
			{
				current.Next = null;
				return;
			}
			while (current.Next.Next != null)
			{
				if (string.Equals(current.Next.Value, line))
				{
					current.Next = current.Next.Next;
					return;
				}
				current = current.Next;
			}
		}
	}
}


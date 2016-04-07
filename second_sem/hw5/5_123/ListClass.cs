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
		public virtual void Push(int value)
		{
			ListElement newElement = new ListElement(value, top);
			newElement.Next = top;
			top = newElement;
		}

		// deletes a top element; returns its value
		public int Pop()
		{
			if (top == null)
			{
				Console.WriteLine("list is empty");
				return 0;
			}
			int value = top.Value;
			top = top.Next;
			return value;
		}

		// returns a value of the top of the list
		public int Value()
		{
			return top.Value;
		}

		// checks is the list empty
		public bool IsEmpty()
		{
			return top == null;
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
		public bool CheckForBelong(int value)
		{
			ListElement current = top;
			while (current != null)
			{
				if (current.Value == value)
				{
					break;
				}
				current = current.Next;
			}
			return current != null;
		}

		// removes element from the list
		public virtual void Remove(int value)
		{
			ListElement current = top;
			if (current.Value == value)
			{
				top = current.Next;
			}
			while (current.Next != null)
			{
				if (current.Next.Value == value)
				{
					current.Next = current.Next.Next;
					return;
				}
				current = current.Next;
			}
		}

		// returns length of the list
		public int GetLength()
		{
			int count = 0;
			ListElement current = top;
			while (current != null)
			{
				count++;
				current = current.Next;
			}
			return count;
		}

		// gets access to each element through it's index
		public int GetIndexedValue(int index)
		{
			ListElement current = top;
			if (index >= this.GetLength())
			{
				throw new Exception("out of list");
			}
			else
			{
				for (int i = 0; i < index; ++i)
				{
					current = current.Next;
				}
			}
			return current.Value;
		}
	}
}
using System;
using System.Collections;
using System.Collections.Generic;

namespace MyWorks
{
	// class for keeping data in a list and working with it
	// T is a type of data
	public class List<T> : IEnumerable
	{
		private ListElement top;
		private int elementsNumber;

		// class appearing as a list element
		private class ListElement
		{
			//auto properties
			public T Value { get; set; }
			public ListElement Next { get; set; }

			//constructor
			public ListElement(T value, ListElement nextElement)
			{
				Value = value;
				Next = nextElement;
			}
		}

		// constructor
		public List() { }

		// adds a new element to the list
		public void Push(T value)
		{
			ListElement newElement = new ListElement(value, top);
			newElement.Next = top;
			top = newElement;
			elementsNumber++;
		}

		// adds an element in position
		public void AddInPosition(T value, int position)
		{
			if (position > elementsNumber)
			{
				position = elementsNumber + 1;
			}
			if (position <= 0)
			{
				this.Push(value);
			}
			else
			{
				var current = top;
				for (int i = 1; i < position; ++i)
				{
					current = current.Next;
				}
				var newListElement = new ListElement(value, current.Next);
				current.Next = newListElement;
			}
			elementsNumber++;
		}

		// deletes a top element; returns its value
		public T Pop()
		{
			if (top == null)
			{
				throw new Exception("the list is empty");
			}
			else
			{
				T value = top.Value;
				top = top.Next;
				elementsNumber--;
				return value;
			}
		}

		// returns a value of the top of the list
		public T Value() => top.Value;

		// returns a number of list elements
		public int Length() => elementsNumber;

		// checks is the list empty
		public bool IsEmpty() => (top == null);

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
		public bool IsBelong(T value)
		{
			ListElement current = top;
			while (current != null)
			{
				if (current.Value.Equals(value))
				{
					break;
				}
				current = current.Next;
			}
			return current != null;
		}

		// removes element from the list
		public void Remove(T value)
		{
			if (IsBelong(value) == false)
			{
				Console.WriteLine("element not found");
				return;
			}
			ListElement current = top;
			if (current.Value.Equals(value))
			{
				top = current.Next;
				elementsNumber--;
				return;
			}
			while (current.Next != null)
			{
				if (current.Next.Value.Equals(value))
				{
					current.Next = current.Next.Next;
					elementsNumber--;
					return;
				}
				current = current.Next;
			}
		}

		// removes an element from position
		public void RemoveFromPosition(int position)
		{
			if (position >= elementsNumber)
			{
				position = elementsNumber - 1;
			}
			if (position == 0)
			{
				this.Pop();
				elementsNumber--;
				return;
			}
			var current = top;
			for (int i = 1; i < position; ++i)
			{
				current = current.Next;
			}
			current.Next = current.Next.Next;
			elementsNumber--;
			return;

		}

		// implementation for the GetEnumerator method
		IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();

		public ListEnumerator GetEnumerator() => new ListEnumerator(this);

		// implementation of Ienumerator for the list
		public class ListEnumerator : IEnumerator
		{
			private List<T> list;
			private int position = -1;
			private ListElement current;

			// constructor
			public ListEnumerator(List<T> newList)
			{
				list = newList;
				current = null;
			}

			// moves to the next list element
			public bool MoveNext()
			{
				position++;
				current = current == null ? list.top : current.Next;
				return position < list.Length();
			}

			// returns the enumerator to the position previous to the first element
			public void Reset()
			{
				position = -1;
				current = null;
			}
				
			object IEnumerator.Current
			{
				get { return Current; }
			}

			// returns a value of the current element of list
			public T Current
			{
				get
				{
					try
					{
						return current.Value;
					}
					catch (IndexOutOfRangeException)
					{
						throw new InvalidOperationException();
					}
				}
			}
		}
	}
}

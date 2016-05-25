using System;

namespace MyWorks
{
	// class Queue with priorities, each element here has an own priority
	public class Queue
	{
		private QueueElement top;

		// private class appearing as a Queue element
		private class QueueElement
		{
			// prorerties
			public int Value { set; get; }
			public int Priority {set; get;}
			public QueueElement Next { set; get; }

			// constructor
			public QueueElement(int value, int priority, QueueElement next)
			{
				Value = value;
				Priority = priority;
				Next = next;
			}
		}

		// constructor
		public Queue() { }

		// add an enement with it's priority to queue
		public void Enqueue(int value, int priority)
		{
			QueueElement newElement = new QueueElement(value, priority, top);
			top = newElement;
		}

		// remove an element with the biggest priority from the queue
		public int Dequeue()
		{
			QueueElement current = top;
			int maxPriority = -300;
			while (current != null)
			{
				if (current.Priority > maxPriority)
				{
					maxPriority = current.Priority;
				}
				current = current.Next;
			}
			current = top;
			if (current.Priority == maxPriority)
			{
				maxPriority = current.Value;
				top = top.Next;
				return maxPriority; // return value (there is no need to create another variable for this)
			}
			while (current.Next != null)
			{
				if (current.Next.Priority == maxPriority)
				{
					maxPriority = current.Next.Value;
					current.Next = current.Next.Next;
					return maxPriority; // the same thing
				}
			}
			throw new DeletingFromTheEmptyQueueException("queue is empty");
		}

		// print the Queue
		public void Print()
		{
			QueueElement current = top;
			while (current != null)
			{
				Console.Write("({0}, {1}) ", current.Value, current.Priority);
				current = current.Next;
			}
			Console.WriteLine();
		}

		// checks does an element belong to queue
		public bool IsBelong(int value, int priority)
		{
			QueueElement current = top;
			while (current != null)
			{
				if (current.Value == value && current.Priority == priority)
				{
					return true;
				}
				current = current.Next;
			}
			return false;
		}
	}
}

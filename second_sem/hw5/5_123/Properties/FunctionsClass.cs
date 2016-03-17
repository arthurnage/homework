using System;

namespace MyWorks
{
	// class for using generic-delegats functions
	public class Function
	{
		// changes all the list elements
		public static List Map(List list, Func<int, int> Function)
		{
			List newList = new List();
			while (!list.IsEmpty())
			{
				newList.Push(Function(list.Pop()));
			}
			while (!newList.IsEmpty())
			{
				list.Push(newList.Pop());
			}
			return list;
		}

		// deletes elements froms list in dependance of bool function
		public static List Filter(List list, Func<int, bool> Function)
		{
			List newList = new List();
			while (!list.IsEmpty())
			{
				int value = list.Pop();
				if (Function(value))
				{
					newList.Push(value);
				}
			}
			while (!newList.IsEmpty())
			{
				list.Push(newList.Pop());
			}
			return list;
		}

		// returns a multiplicated value from the list elements
		public static int Fold(List list, int value, Func<int, int, int> Function)
		{
			while (!list.IsEmpty())
			{
				int number = list.Pop();
				value = Function(value, number);
			}
			return value;
		}
	}
}


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
			for (int i = 0; i < list.GetLength(); ++i)
			{
				newList.Push(Function(list.GetIndexedValue(list.GetLength() - 1 - i)));
			}
			return newList;
		}

		// deletes elements from the list in dependance of bool function
		public static List Filter(List list, Func<int, bool> Function)
		{
			List newList = new List();
			for (int i = 0; i < list.GetLength(); ++i)
			{
				if (Function(list.GetIndexedValue(list.GetLength() - 1 - i)))
				{
					newList.Push(list.GetIndexedValue(list.GetLength() - 1 - i));
				}
			}
			return newList;
		}

		// returns a multiplicated value from the list elements
		public static int Fold(List list, int value, Func<int, int, int> Function)
		{
			for (int i = 0; i < list.GetLength(); ++i)
			{
				int number = list.GetIndexedValue(i);
				value = Function(value, number);
			}
			return value;
		}
	}
}
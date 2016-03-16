using System;

namespace MyWorks
{
	// a list class without the equal elements
	public class UniqueList : List
	{
		// adding an exception to Push method
		public override void Push(int value)
		{
			if (CheckForBelong(value))
			{
				throw new AddingElementException("the list already has this element");
			}
			else
			{
				base.Push(value);
			}
		}

		// adding an exception to Remove method
		public override void Remove(int value)
		{
			if (!CheckForBelong(value))
			{
				throw new DeletingElementException("the list does not have this element");
			}
			else
			{
				base.Remove(value);
			}
		}
	}
}


using System;
using NUnit.Framework;

namespace MyWorks
{
	[TestFixture()]
	public class UniqueListTest
	{
		private UniqueList list;

		[SetUp()]
		public void Initialise()
		{
			list = new UniqueList();
		}

		[Test()]
		[ExpectedException(typeof(AddingElementException))]
		public void PushTest()
		{
			list.Push(1);
			list.Push(1);
		}

		[Test()]
		[ExpectedException(typeof(DeletingElementException))]
		public void RemoveAndPopTest()
		{
			list.Remove(2);
			list.Push(3);
			list.Pop();
		}
	}
}


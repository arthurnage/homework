using NUnit.Framework;
using System;

namespace MyWorks
{
	[TestFixture()]
	public class ListTest
	{
		private List list;

		[SetUp()]
		public void Initialise()
		{
			list = new List();
			list.Push(1);
			list.Push(2);
			list.Push(3);
		}

		[Test()]
		public void CheckForBelongTest()
		{
			Assert.IsTrue(list.CheckForBelong(1));
			Assert.IsTrue(list.CheckForBelong(2));
			Assert.IsTrue(list.CheckForBelong(3));
			Assert.IsFalse(list.CheckForBelong(4));
		}

		[Test()]
		public void RemoveTest()
		{
			list.Remove(2);
			Assert.IsFalse(list.CheckForBelong(2));
			list.Remove(3);
			Assert.IsFalse(list.CheckForBelong(3));
		}

		[Test()]
		public void PushTest()
		{
			Assert.AreEqual(3, list.Value());
			list.Push(4);
			Assert.AreEqual(4, list.Value());

		}

		[Test()]
		public void PopTest()
		{
			Assert.AreEqual(3, list.Pop());
			Assert.AreEqual(2, list.Pop());
			Assert.AreEqual(1, list.Pop());
		}
	}
}


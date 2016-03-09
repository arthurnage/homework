using NUnit.Framework;
using System;

namespace MyWorks
{
	[TestFixture()]
	public class StringListClassTest
	{
		private StringList list;

		[SetUp()]
		public void Initialise()
		{
			list = new StringList();
		}

		[Test()]
		public void PopTest()
		{
			list.Push("test");
			Assert.AreSame("test", list.Pop());
		}

		[Test()]
		public void PushTest()
		{
			list.Push("a");
			Assert.IsFalse(list.IsEmpty());
		}

		[Test()]
		public void TwoElementsPopTest()
		{
			list.Push("a");
			list.Push("b");
			Assert.AreSame("b", list.Pop());
			Assert.AreSame("a", list.Pop());
		}

		[Test()]
		public void RemoveTest(string line)
		{
			list.Push("test");
			list.Push("test1");
			list.Push("test2");
			list.Push("test3");
			list.Remove("test");
			Assert.IsFalse(list.CheckForBelong("test"));
			list.Remove("test2");
			Assert.IsFalse(list.CheckForBelong("test2"));
			list.Remove("test3");
			Assert.IsFalse(list.CheckForBelong("test3"));
		}

		[Test()]
		public void CheckForBelongTest(string line)
		{
			list.Push("test");
			list.Push("test1");
			list.Push("test2");
			Assert.IsTrue(list.CheckForBelong("test"));
			Assert.IsTrue(list.CheckForBelong("test1"));
			Assert.IsTrue(list.CheckForBelong("test2"));
		}

		[Test()]
		public void ValueTest()
		{
			list.Push("test");
			Assert.AreSame("test", list.Value());
		}
	}
}


using NUnit.Framework;
using System;

namespace MyWorks
{
	[TestFixture()]
	public class Test
	{
		private List list;

		[SetUp()]
		public void Initialise()
		{
			list = new List();
			list.Push(5);
			list.Push(5);
			list.Push(4);
			list.Push(3);
		}

		[Test()]
		public void MapTest()
		{
			list = Function.Map(list, x => x * x);
			Assert.AreEqual(9, list.Pop());
			Assert.AreEqual(16, list.Pop());
			Assert.AreEqual(25, list.Pop());
			Assert.AreEqual(25, list.Pop());
		}

		[Test()]
		public void FilterTest()
		{
			list = Function.Filter(list, x => (x % 2 == 0));
			Assert.AreEqual(4, list.Pop());
		}

		[Test()]
		public void FoldTest()
		{
			Assert.AreEqual(600, Function.Fold(list, 2, (number, listElement) => number * listElement));
		}
	}
}


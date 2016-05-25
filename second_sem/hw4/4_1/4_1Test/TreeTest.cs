using NUnit.Framework;
using System;

namespace MyWorks
{
	[TestFixture()]
	public class TreeTest
	{
		[Test()]
		public void MultiplicateTest()
		{
			Tree tree = new Tree("( * 3 6 ");
			Assert.AreEqual(18, tree.Calculate());
		}

		[Test()]
		public void ComplicatedTest1()
		{
			Tree tree = new Tree("( + ( - 4 ( / 5 3 ) ) 3 )");
			Assert.AreEqual(6, tree.Calculate());
		}

		[Test()]
		public void SubstractTest1()
		{
			Tree tree = new Tree("( - 5 3 )");
			Assert.AreEqual(2, tree.Calculate());
		}

		[Test()]
		public void DivideTest()
		{
			Tree tree = new Tree("( / 5 3 )");
			Assert.AreEqual(1, tree.Calculate());
		}

		[Test()]
		public void SubstractTest2()
		{
			Tree tree = new Tree("( - 2 3 )");
			Assert.AreEqual(-1, tree.Calculate());
		}
	}
}
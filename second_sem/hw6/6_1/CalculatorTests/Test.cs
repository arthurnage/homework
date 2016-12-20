using NUnit.Framework;
using System;

namespace MyWorks
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void TestAdd()
		{
			Assert.AreEqual("5", CalculateMachine.Calculate("1 + 4"));
		}

		[Test()]
		public void TestNoOperation()
		{
			Assert.AreEqual("5", CalculateMachine.Calculate("5"));
		}

		[Test()]
		public void TestSubstract()
		{
			Assert.AreEqual("5", CalculateMachine.Calculate("9 - 4"));
		}

		[Test()]
		public void TestMultiply()
		{
			Assert.AreEqual("25", CalculateMachine.Calculate("5 * 5"));
		}
	}
}


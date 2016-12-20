using NUnit.Framework;
using System;

namespace MyWorks
{
	[TestFixture()]
	public class CalculatorTest
	{
		[SetUp()]
		public void Initialize()
		{
			calculator = new Calculator();
		}

		[Test()]
		public void PushTest() // the same to ResultTest()
		{
			calculator.Push(5);
			Assert.AreEqual(5, calculator.Result());
		}

		[Test()]
		public void AddTest()
		{
			calculator.Push(3);
			calculator.Push(4);
			calculator.Add();
			Assert.AreEqual(7, calculator.Result());
		}

		[Test()]
		public void MyltiplyTest()
		{
			calculator.Push(3);
			calculator.Push(4);
			calculator.Multiply();
			Assert.AreEqual(12, calculator.Result());
		}

		[Test()]
		public void SubstractTest()
		{
			calculator.Push(3);
			calculator.Push(4);
			calculator.Substract();
			Assert.AreEqual(-1, calculator.Result());
		}

		[Test()]
		public void IntDivideTest()
		{
			calculator.Push(13);
			calculator.Push(4);
			calculator.IntDivide();
			Assert.AreEqual(3, calculator.Result());
		}

		[Test()]
		public void RemainderDivideTest()
		{
			calculator.Push(13);
			calculator.Push(4);
			calculator.RemainderDivide();
			Assert.AreEqual(1, calculator.Result());
		}

		private Calculator calculator;
	}
}


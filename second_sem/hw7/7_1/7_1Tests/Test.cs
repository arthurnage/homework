using NUnit.Framework;
using System;

namespace MyWorks
{
	[TestFixture()]
	public class Test
	{
		private List<int> list;

		[SetUp()]
		public void Initialise()
		{
			list = new List<int>();
		}

		[Test()]
		public void PopTest()
		{
			list.Push(1);
			Assert.AreEqual(1, list.Pop());
		}

//		[Test()]
//		[ExpectedException(typeof(EmptyListException))]
//		public void PopFromTheEmptyListTest()
//		{
//			list.Pop();
//		}

		[Test()]
		public void PushTest()
		{
			list.Push(2);
			Assert.IsFalse(list.IsEmpty());
		}

		[Test()]
		public void TwoElementsPopTest()
		{
			list.Push(1);
			list.Push(2);
			Assert.AreEqual(2, list.Pop());
			Assert.AreEqual(1, list.Pop());
		}

		[Test()]
		public void RemoveTest()
		{
			list.Push(1);
			list.Push(2);
			list.Push(3);
			list.Push(4);
			list.Remove(2);
			Assert.IsFalse(list.IsBelong(2));
			list.Remove(3);
			Assert.IsFalse(list.IsBelong(3));
			list.Remove(2);
			Assert.IsFalse(list.IsBelong(2));
		}

		[Test()]
		public void IsBelongTest()
		{
			list.Push(1);
			list.Push(2);
			list.Push(3);
			Assert.IsTrue(list.IsBelong(1));
			Assert.IsTrue(list.IsBelong(2));
			Assert.IsTrue(list.IsBelong(3));
		}

		[Test()]
		public void LengthTest()
		{
			list.Push(1);
			list.Push(2);
			list.Push(3);
			Assert.AreEqual(3, list.Length());
		}

		[Test()]
		public void RemoveFromPositoinTest()
		{
			list.Push(1);
			list.Push(2);
			list.Push(3);
			list.Push(4);
			list.RemoveFromPosition(3);
			list.RemoveFromPosition(0);
			Assert.IsFalse(list.IsBelong(4));
			Assert.IsFalse(list.IsBelong(1));
		}

		[Test()]
		public void AddInPositionTest()
		{
			list.Push(1);
			list.Push(2);
			list.Push(3);
			list.AddInPosition(44, 1);
			list.Pop();
			Assert.AreEqual(44, list.Pop());
		}

		[Test()]
		public void ValueTest()
		{
			list.Push(2);
			Assert.AreEqual(2, list.Value());
		}

		[Test()]
		public void EnumTest()
		{
			list.Push(1);
			list.Push(2);
			list.Push(3);
			int sum = 0;
			foreach (int value in list)
			{
				sum += value;
			}
			Assert.AreEqual(6, sum);
		}
	}
}


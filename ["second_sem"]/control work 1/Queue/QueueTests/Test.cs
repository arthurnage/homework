using NUnit.Framework;
using System;

namespace MyWorks
{
	[TestFixture()]
	public class QueueTest
	{
		private Queue queue;

		[SetUp()]
		public void Initialise()
		{
			queue = new Queue();
			queue.Enqueue(1, 1);
			queue.Enqueue(2, 2);
			queue.Enqueue(3, 4);
			queue.Enqueue(999, -1);
			queue.Enqueue(82, 4);
		}

		[Test()]
		public void IsBelongTest()
		{
			Assert.IsTrue(queue.IsBelong(999, -1));
			Assert.IsFalse(queue.IsBelong(232, 232));
		}

		[Test()]
		public void EnqueueTest()
		{
			queue.Enqueue(-100, 100);
			Assert.IsTrue(queue.IsBelong(-100, 100));
		}

		[Test()]
		public void DequeueTest()
		{
			Assert.AreEqual(82, queue.Dequeue());
			Assert.AreEqual(3, queue.Dequeue());
			Assert.AreEqual(2, queue.Dequeue());
			Assert.AreEqual(1, queue.Dequeue());
		}
	}
}


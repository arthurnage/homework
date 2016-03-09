using NUnit.Framework;
using System;

namespace MyWorks
{
	[TestFixture()]
	public class HashFunction2Test
	{
		private HashFunction2 hashFunction;

		[SetUp]
		public void Initialise()
		{
			hashFunction = new HashFunction2();
		}

		[Test()]
		public void GetHashTest()
		{
			string line = "test";
			int number = 't';
			int hashDigit = 10;
			number %= 10;
			Assert.AreEqual(number, hashFunction.GetHash(line, hashDigit));
		}
	}
}
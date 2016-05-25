using NUnit.Framework;
using System;

namespace MyWorks
{
	[TestFixture()]
	public class HashFunction1Test
	{
		private HashFunction1 hashFunction;
		[SetUp]
		public void Initialise()
		{
			hashFunction = new HashFunction1();
		}

		[Test()]
		public void GetHashTest()
		{
			string line = "test";
			int number = 't' + 'e' + 's' + 't';
			int hashDigit = 10;
			number %= 10;
			Assert.AreEqual(number, hashFunction.GetHash(line, hashDigit));
		}
	}
}


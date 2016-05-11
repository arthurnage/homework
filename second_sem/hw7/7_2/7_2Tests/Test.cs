using NUnit.Framework;
using System;

namespace MyWorks
{
	[TestFixture()]
	public class Test
	{
		private Set<int> set;

		[SetUp()]
		public void Initialise()
		{
			set = new Set<int>();
		}

		[Test()]
		public void RemoveTest()
		{
			set.Add(3);
			set.Add(5);
			set.Remove(3);
			Assert.IsFalse(set.IsBelong(3));
			set.Remove(5);
			Assert.IsFalse(set.IsBelong(5));
		}

		[Test()]
		public void UnionTest()
		{
			set.Add(1);
			set.Add(2);
			set.Add(3);
			var newSet = new Set<int>();
			newSet.Add(3);
			newSet.Add(4);
			newSet.Add(5);
			newSet = set.Union(newSet);
			Assert.IsTrue(newSet.IsBelong(1));
			Assert.IsTrue(newSet.IsBelong(2));
			Assert.IsTrue(newSet.IsBelong(3));
			Assert.IsTrue(newSet.IsBelong(4));
			Assert.IsTrue(newSet.IsBelong(5));
		}

		[Test()]
		public void IntersectionTest()
		{
			set.Add(1);
			set.Add(2);
			set.Add(3);
			var newSet = new Set<int>();
			newSet.Add(3);
			newSet.Add(4);
			newSet.Add(5);
			newSet = set.Intersection(newSet);
			Assert.IsTrue(newSet.IsBelong(3));
			Assert.IsFalse(newSet.IsBelong(4));
		}
	}
}


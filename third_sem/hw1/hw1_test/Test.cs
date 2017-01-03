using NUnit.Framework;
using System;

namespace MyWorks
{
    [TestFixture()]
    public class Test
    {
        private Tree<int> tree;
        [SetUp()]
        public void Initialise()
        {
            tree = new Tree<int>();
        }

        [Test()]
        public void AddTest()
        {
            tree.Add(10);
            tree.Add(4);
            tree.Add(5);
            tree.Add(11);
            Assert.IsTrue(tree.IsBelong(10));
            Assert.IsTrue(tree.IsBelong(11));
            Assert.IsTrue(tree.IsBelong(4));
            Assert.IsTrue(tree.IsBelong(5));
            Assert.IsFalse(tree.IsBelong(2));
        }

        [Test()]
        public void RemoveTest()
        {
            tree.Add(10);
            tree.Add(16);
            tree.Add(20);
            tree.Add(13);
            tree.Add(12);
            tree.Remove(13);
            tree.Remove(10);
            tree.Remove(16);
            Assert.IsFalse(tree.IsBelong(13));
            Assert.IsFalse(tree.IsBelong(10));
            Assert.IsFalse(tree.IsBelong(16));
        }

        [Test()]
        public void EnumTest()
        {
            tree.Add(10);
            tree.Add(4);
            tree.Add(5);
            tree.Add(11);
            int sum = 0;
            foreach (int value in tree)
            {
                sum += value;
            }
            Assert.AreEqual(30, sum);
        }
    }
}


using NUnit.Framework;

namespace MyWorks
{
    [TestFixture()]
    public class Test
    {
        private RobotMaker robots;

        [Test()]
        public void Test1()
        {
            robots = new RobotMaker("/Users/arthur/Projects/c#/hw3/hw3Test/testMatrix1.txt");
            robots.CheckMatrix();
            Assert.IsTrue(robots.SequenceExists);
        }

        [Test()]
        public void Test2()
        {
            robots = new RobotMaker("/Users/arthur/Projects/c#/hw3/hw3Test/testMatrix2.txt");
            robots.CheckMatrix();
            Assert.IsTrue(robots.SequenceExists);
        }

        [Test()]
        public void Test3()
        {
            robots = new RobotMaker("/Users/arthur/Projects/c#/hw3/hw3Test/testMatrix3.txt");
            robots.CheckMatrix();
            Assert.IsFalse(robots.SequenceExists);
        }

        [Test()]
        public void Test4()
        {
            robots = new RobotMaker("/Users/arthur/Projects/c#/hw3/hw3Test/testMatrix4.txt");
            robots.CheckMatrix();
            Assert.IsFalse(robots.SequenceExists);
        }

        [Test()]
        public void Test5()
        {
            robots = new RobotMaker("/Users/arthur/Projects/c#/hw3/hw3Test/testMatrix5.txt");
            robots.CheckMatrix();
            Assert.IsTrue(robots.SequenceExists);
        }
    }
}
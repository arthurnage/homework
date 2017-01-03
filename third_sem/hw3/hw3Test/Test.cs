using NUnit.Framework;

namespace MyWorks
{
    [TestFixture()]
    public class Test
    {
        private RobotMaker robots;

        [Test()]
        public void ThreeNodeGraphTest()
        {
            robots = new RobotMaker("/Users/arthur/Projects/c#/hw3/hw3Test/testMatrix1.txt");
            robots.CheckMatrix();
            Assert.IsTrue(robots.SequenceExists);
        }

        [Test()]
        public void FourNodeGraphTest()
        {
            robots = new RobotMaker("/Users/arthur/Projects/c#/hw3/hw3Test/testMatrix2.txt");
            robots.CheckMatrix();
            Assert.IsTrue(robots.SequenceExists);
        }

        [Test()]
        public void FourNodeGraphTestWithTreeRobots()
        {
            robots = new RobotMaker("/Users/arthur/Projects/c#/hw3/hw3Test/testMatrix3.txt");
            robots.CheckMatrix();
            Assert.IsFalse(robots.SequenceExists);
        }

        [Test()]
        public void FourNodeGraphTestWithOneRobot()
        {
            robots = new RobotMaker("/Users/arthur/Projects/c#/hw3/hw3Test/testMatrix4.txt");
            robots.CheckMatrix();
            Assert.IsFalse(robots.SequenceExists);
        }

        [Test()]
        public void ThreeNodeCycleGraphTest()
        {
            robots = new RobotMaker("/Users/arthur/Projects/c#/hw3/hw3Test/testMatrix5.txt");
            robots.CheckMatrix();
            Assert.IsTrue(robots.SequenceExists);
        }
    }
}
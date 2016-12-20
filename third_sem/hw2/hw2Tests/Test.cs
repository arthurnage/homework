using NUnit.Framework;
using System;

namespace MyWorks
{
    [TestFixture()]
    public class Test
    {
        private Network netWork;

        [Test()]
        public void ComponentTest1()
        {
            netWork = new Network("/Users/arthur/Projects/c#/hw2/hw2Tests/testNetWork1.txt");
            netWork.AddVirus(0);
            Assert.IsTrue(netWork.Computers[0].Infected);
            netWork.NextMove();
            Assert.IsTrue(netWork.Computers[1].Infected);
            netWork.NextMove();
            Assert.IsTrue(netWork.Computers[2].Infected);
        }

        [Test()]
        public void ComponentTest2()
        {
            netWork = new Network("/Users/arthur/Projects/c#/hw2/hw2Tests/testNetWork1.txt");
            netWork.AddVirus(1);
            Assert.IsTrue(netWork.Computers[1].Infected);
            netWork.NextMove();
            Assert.IsTrue(netWork.Computers[0].Infected);
            Assert.IsTrue(netWork.Computers[2].Infected);
        }

        [Test()]
        public void ComponentTest3()
        {
            netWork = new Network("/Users/arthur/Projects/c#/hw2/hw2Tests/testNetWork1.txt");
            netWork.AddVirus(2);
            Assert.IsTrue(netWork.Computers[2].Infected);
            netWork.NextMove();
            Assert.IsTrue(netWork.Computers[1].Infected);
            netWork.NextMove();
            Assert.IsTrue(netWork.Computers[0].Infected);
        }

        [Test()]
        public void LowProbobilityTest()
        {
            netWork = new Network("/Users/arthur/Projects/c#/hw2/hw2Tests/testNetWork2.txt");
            netWork.AddVirus(0);
            while (netWork.IsStabilized() == false)
            {
                netWork.NextMove();      
            }
            Assert.IsTrue(netWork.IsStabilized());
        }
    }
}

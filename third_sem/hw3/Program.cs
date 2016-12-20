using System;

namespace MyWorks
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var robotMaker = new RobotMaker("testMatrix1.txt");
            robotMaker.CheckMatrix();
            if (robotMaker.SequenceExists)
            {
                Console.WriteLine("Sequence exists");
            }
            else
            {
                Console.WriteLine("Sequence doesen't exist");
            }
        }
    }
}

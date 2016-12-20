using System;

namespace MyWorks
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var netWork = new Network("network.txt");
            netWork.AddVirus(0); // add virus to the network
            int index = 0;
            netWork.PrintInfo();
            while (netWork.IsStabilized() == false)
            {
                Console.WriteLine("Step {0}:", ++index);
                netWork.NextMove();
                netWork.PrintInfo();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections;

namespace MyWorks
{
    public class Virus
    {
        private Computer[] computers;
        private int[,] net;

        /// <summary>
        /// Initializes a new instance of the virus class
        /// </summary>
        /// <param name="infected">Infected.</param>
        /// <param name="newNet">New net.</param>
        /// <param name="newComputers">New computers.</param>
        public Virus(Computer infected, int[,] newNet, Computer[] newComputers)
        {
            infected.Infected = true;
            computers = newComputers;
            net = newNet;
        }

        /// <summary>
        /// A virus tries to infect one of other computers connected with infected computers in net
        /// </summary>
        public void MakeMove()
        {
            var viruses = new List<int>();
            for (int i = 0; i < net.GetLength(0); ++i)
            {
                if (computers[i].Infected)
                {
                    viruses.Add(i);
                }
            }
            foreach (int i in viruses)
            {
                for (int j = 0; j < net.GetLength(0); ++j)
                {
                    if (net[i, j] == 1)
                    {
                        TryToInfect(computers[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Function for infection try
        /// </summary>
        /// <param name="computer">Computer.</param>
        private void TryToInfect(Computer computer)
        {
            Random rnd = new Random();
            if (rnd.Next(0, 100) <= computer.Probability)
            {
                computer.Infected = true;
            }
        }
    }
}


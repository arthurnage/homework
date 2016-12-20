using System;
using System.Collections;
using System.IO;

namespace MyWorks
{
    public class Network
    {
        private int[,] net;
        private ArrayList viruses;

        public Computer[] Computers { get; set; }

        /// <summary>
        /// Initializes a new instance of network.
        /// </summary>
        /// <param name="newComputers">New computers.</param>
        /// <param name="newNet">New net.</param>
        public Network(string fileName)
        {
            try
            {
                using (StreamReader file = new StreamReader(fileName))
                {
                    String line = file.ReadToEnd();
                    String[] substrings = line.Split(' ', '\n');
                    int stringIndex = 0;
                    int computerNumber = int.Parse(substrings[stringIndex++]);
                    Computers = new Computer[computerNumber];
                    net = new int[computerNumber, computerNumber];
                    for (int i = 0; i < computerNumber; ++i)
                    {
                        Computers[i] = new Computer(int.Parse(substrings[stringIndex++]));
                    }
                    for (int i = 0; i < computerNumber; ++i)
                    {
                        for (int j = 0; j < computerNumber; ++j)
                        {
                            net[i, j] = int.Parse(substrings[stringIndex++]);
                        }
                    }
                    viruses = new ArrayList();
                    file.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Adds the virus to the network.
        /// </summary>
        /// <param name="indexOfPC">Index of pc.</param>
        public void AddVirus(int indexOfPC)
        {
            viruses.Add(new Virus(Computers[indexOfPC], net, Computers));
        }

        /// <summary>
        /// Next move of all the viruses
        /// </summary>
        public void NextMove()
        {
            foreach (Virus virus in viruses)
            {
                virus.MakeMove();
            }
        }

        /// <summary>
        /// Checks wheather a condition of network is stabilized.
        /// </summary>
        /// <returns><c>true</c>, if stabilized was ised, <c>false</c> otherwise.</returns>
        public bool IsStabilized()
        {
            if (viruses.Count != 0)
            {
                foreach (Computer pc in Computers)
                {
                    if (!pc.Infected)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Prints the information about comdition of network.
        /// </summary>
        public void PrintInfo()
        {
            for (int i = 0; i < Computers.GetLength(0); ++i)
            {
                var request = Computers[i].Infected == true ? "infected" : "clear";
                Console.WriteLine("Computer {0}: {1}", i, request);
            }
        }
    }
}
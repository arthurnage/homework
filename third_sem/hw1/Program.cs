using System;
using System.Collections.Generic;
using System.Collections;

namespace MyWorks
{
    /// <summary>
    /// Main class
    /// </summary>
    class MainClass
    {
        /// <summary>
        /// The entry point of the program that uses tree for keeping data, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            var tree = new Tree<int>();
            tree.Add(10);
            tree.Add(4);
            tree.Add(5);
            tree.Add(11);
            int sum = 0;
            foreach (int value in tree)
            {
                sum += value;
            }
            Console.WriteLine(sum);
        }
    }
}

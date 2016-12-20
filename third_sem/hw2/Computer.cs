using System;

namespace MyWorks
{
    /// <summary>
    /// A computer class.
    /// </summary>
    public class Computer
    {
        /// <summary>
        /// Shows is computer infected.
        /// </summary>
        /// <value><c>true</c> if infected; otherwise, <c>false</c>.</value>
        public bool Infected { get; set; }

        /// <summary>
        /// The probability (in %) of computer being infected by a virus.
        /// </summary>
        public int Probability { get; }

        /// <summary>
        /// Initializes a new instance of the computer class.
        /// </summary>
        /// <param name="system">System.</param>
        /// <param name="prob">Prob.</param>
        public Computer(int prob)
        {
            Infected = false;
            Probability = prob;
        }
    }
}
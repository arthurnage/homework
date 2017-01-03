using System;

namespace MyWorks
{
    /// <summary>
    /// A computer class.
    /// </summary>
    public class Computer
    {
        /// <summary>
        /// Gets the os.
        /// </summary>
        /// <value>The os.</value>
        public OperationSystem OS { get; }

        /// <summary>
        /// Shows is computer infected.
        /// </summary>
        /// <value><c>true</c> if infected; otherwise, <c>false</c>.</value>
        public bool Infected { get; set; }

        /// <summary>
        /// Initializes a new instance of the computer class.
        /// </summary>
        /// <param name="system">System.</param>
        /// <param name="prob">Prob.</param>
        public Computer(int i)
        {
            switch (i)
            {
                case 0:
                    {
                        OS = new OperationSystem(30);
                        //linux
                        return;
                    }
                case 1:
                    {
                        OS = new OperationSystem(60);
                        //mac
                        return;
                    }
                case 2:
                    {
                        OS = new OperationSystem(100);
                        //windows
                        return;
                    }
                case 3:
                    {
                        OS = new OperationSystem(1);
                        //superOS
                        return;
                    }
            }
            Infected = false;
        }
    }
}
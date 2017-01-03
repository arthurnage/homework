using System.Collections;
using System.Collections.Generic;

namespace MyWorks
{
    /// <summary>
    /// Class for Robot who can move on graph
    /// </summary>
    public class Robot
    {
        public int Node { get; set; }
        public List<int> graph { get; }
        private List<int> visited;
        private int[,] matrix;

        /// <summary>
        /// Initializes a new instance of robot class.
        /// </summary>
        /// <param name="newNode">New node.</param>
        /// <param name="newMatrix">New matrix.</param>
        public Robot(int newNode, int[,] newMatrix)
        {
            Node = newNode;
            graph = new List<int>();
            matrix = newMatrix;
            visited = new List<int>();
        }

        /// <summary>
        /// Creates a subgraph by using private funciton
        /// </summary>
        public void setGraph()
        {
            setGraph(Node);
        }

        /// <summary>
        /// Creates a subgraph
        /// </summary>
        /// <param name="startNode">Start node.</param>
        private void setGraph(int startNode)
        {
            visited.Add(startNode);
            int numberOfAddedElements = 0;
            var temp = new ArrayList();
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                if (matrix[startNode, i] == 1)
                {
                    temp.Add(i);
                }
            }
            foreach (int i in temp)
            {
                for (int j = 0; j < matrix.GetLength(0); ++j)
                {
                    if (matrix[i, j] == 1)
                    {
                        if (!graph.Contains(j))
                        {
                            graph.Add(j);
                            numberOfAddedElements++;
                        }
                    }
                }
            }
            if (numberOfAddedElements == 0)
            {
                return;
            }
            else
            {
                for (int i = 0; i < graph.Count; ++i)
                {
                    if (!visited.Contains(graph[i]))
                    {
                        setGraph(graph[i]);
                    }
                }
            }
        }
    }
}

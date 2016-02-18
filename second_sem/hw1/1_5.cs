using System;

namespace _5
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			const int matrixSize = 5;
			int[,] matrix = new int[matrixSize, matrixSize]   
			   {{1, 21, 9, 10, 11}, 
				{6, 5, 6, 7, 2},
				{5, 4, 1, 8, 3}, 
				{4, 3, 2, 9, 4}, 
				{3, 2, 1, 0, 5}};
			for (int i = 0; i < matrixSize; ++i)
			{
				for (int j = 0; j < matrixSize - i - 1; ++j)
				{
					if (matrix[0, j] > matrix[0, j + 1])
					{
						for (int k = 0; k < matrixSize; ++k)
						{
							int num = matrix [k, j];
							matrix [k, j] = matrix [k, j + 1];
							matrix [k, j + 1] = num;
						}
					}
				}
			}
			for (int i = 0; i < matrixSize; ++i)
			{
				for (int j = 0; j < matrixSize; ++j)
				{
					Console.Write(matrix[i, j]);
					Console.Write (" ");
					if (j == 4)
					{
						Console.WriteLine ();
					}
				}
			}
		}
	}
}

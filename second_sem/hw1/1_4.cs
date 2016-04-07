using System;

namespace MyWorks
{
	// class for matrix output in spiral form
	class MainClass
	{
		public static void Main (string[] args)
		{
			const int matrixSize = 5;
			int[,] matrix = new int[matrixSize, matrixSize]   
				{{17, 18, 19, 20, 21}, 
				{16, 5, 6, 7, 22},
				{15, 4, 1, 8, 23}, 
				{14, 3, 2, 9, 24}, 
				{13, 12, 11, 10, 25}};
			SpiralPrint(matrix, matrixSize);
		}

		// prints the matrix in a spiral form
		public static void SpiralPrint(int[,] matrix, int matrixSize)
		{
			int x = matrixSize / 2;//middle x
			int y = matrixSize / 2;//middle y
			int centerX = matrixSize / 2;
			int centerY = matrixSize / 2;
			int orientationFlag = 1;
			int number = 0;
			while (orientationFlag <= matrixSize / 2)
			{
				for (int i = 0; ((Math.Abs(centerX - x) <= orientationFlag) && (Math.Abs(centerY - y) <= orientationFlag) &&
					(x < matrixSize) && (y < matrixSize) && (x >= 0) && (y >= 0)); ++i)
				{

					if (Math.Abs(centerX - x) < orientationFlag)
					{
						Console.Write(matrix[x, y]);
						Console.Write(" ");
						number++;
					}
					x++;
				}
				x--;
				for (int i = 0; ((Math.Abs(centerX - x) <= orientationFlag) && (Math.Abs(centerY - y) <= orientationFlag) &&
					(x < matrixSize) && (y < matrixSize) && (x >= 0) && (y >= 0)); ++i)
				{
					if (Math.Abs(centerY - y) < orientationFlag)
					{
						Console.Write(matrix[x, y]);
						Console.Write(" ");
						number++;
					}
					y--;
				}
				y++;
				for (int i = 0; ((Math.Abs(centerX - x) <= orientationFlag) && (Math.Abs(centerY - y) <= orientationFlag) &&
					(x < matrixSize) && (y < matrixSize) && (x >= 0) && (y >= 0)); ++i)
				{
					if (centerX - x < orientationFlag)
					{
						Console.Write(matrix[x, y]);
						Console.Write(" ");
						number++;
					}
					x--;
				}
				x++;
				for (int i = 0; ((Math.Abs(centerX - x) <= orientationFlag) && (Math.Abs(centerY - y) <= orientationFlag) &&
					(x < matrixSize) && (y < matrixSize) && (x >= 0) && (y >= 0)); ++i)
				{
					if (y - centerY < orientationFlag)
					{
						Console.Write(matrix[x, y]);
						Console.Write(" ");
						number++;
					}
					y++;
				}
				y--; 
				orientationFlag++;
			}
			for (int i = 0; ((Math.Abs(centerX - x) <= orientationFlag) && (Math.Abs(centerY - y) <= orientationFlag) &&
				(x < matrixSize) && (y < matrixSize) && (x >= 0) && (y >= 0)); ++i)
			{
				if (Math.Abs(centerX - x) < orientationFlag)
				{
					Console.Write(matrix[x, y]);
					Console.Write(" ");
					number++;
				}
				x++;
			}
		}
	}
}

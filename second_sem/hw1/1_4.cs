using System;

namespace _4
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			const int matrixSize = 5;
			const int centerX = 2;
			const int centerY = 2;

			int[,] matrix = new int[matrixSize, matrixSize]   
											{{17, 18, 19, 20, 21}, 
											{16, 5, 6, 7, 22},
											{15, 4, 1, 8, 23}, 
											{14, 3, 2, 9, 24}, 
											{13, 12, 11, 10, 25}};
			int x = centerX;
			int y = centerY;
			int flag = 1;
			while (flag < matrixSize)
			{
				for (int i = 0; ((Math.Abs (centerX - x) <= flag) && (Math.Abs (centerY - y) <= flag)); ++i)
				{

					if (Math.Abs (centerX - x) < flag) 
					{
						Console.Write (matrix [x, y]);
						Console.Write (" ");
					}
					x++;
				}
				x--;
				for (int i = 0; ((Math.Abs (centerX - x) <= flag) && (Math.Abs (centerY - y) <= flag)); ++i)
				{
					if (Math.Abs (centerY - y) < flag)
					{
						Console.Write (matrix [x, y]);
						Console.Write (" ");
					}
					y--;
				}
				y++;
				for (int i = 0; ((Math.Abs (centerX - x) <= flag) && (Math.Abs (centerY - y) <= flag)); ++i)
				{
					if (centerX - x < flag)
					{
						Console.Write (matrix [x, y]);
						Console.Write (" ");
					}
					x--;
				}
				x++;
				for (int i = 0; ((Math.Abs (centerX - x) <= flag) && (Math.Abs (centerY - y) <= flag)); ++i)
				{
					if (y - centerY < flag)
					{
						Console.Write (matrix [x, y]);
						Console.Write (" ");
					}
					y++;
				}
				y--;
				flag++;
			}

		}
	}
}

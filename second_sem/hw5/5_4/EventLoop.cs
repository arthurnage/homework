using System;

namespace MyWorks
{
	public class EventLoop
	{
		private int positionY = Console.CursorLeft; // vertical cursor position
		private int positionX = Console.CursorTop; // horisontal cursor position

		// eventLoop body
		public void Run()
		{
			while (true)
			{
				var key = Console.ReadKey();
				switch (key.Key)
				{
				case ConsoleKey.LeftArrow:
					{
						if (positionX > 0)
						{
							positionX -= 1;
							Console.SetCursorPosition(positionX, positionY);
						}
					}
					break;
				case ConsoleKey.RightArrow:
					{
						if (positionX < Console.LargestWindowWidth - 1)
						{
							positionX += 1;
							Console.SetCursorPosition(positionX, positionY);
						}
					}
					break;
				case ConsoleKey.DownArrow:
					{
						if (positionY < Console.LargestWindowHeight - 1)
						{
							positionY += 1;
							Console.SetCursorPosition(positionX, positionY);
						}
					}
					break;
				case ConsoleKey.UpArrow:
					{
						if (positionY > 0)
						{
							positionY -= 1;
							Console.SetCursorPosition(positionX, positionY);
						}
					}
					break;
				}
			}
		}
	}
}


using System;

namespace MyWorks
{
	public class CursorMover
	{
		private int positionY; // vertical cursor position
		private int positionX; // horisontal cursor position

		public CursorMover(int cursorLeft, int cursorTop)
		{
			positionY = cursorLeft; // vertical cursor position
			positionX = cursorTop; // horisontal cursor position
		}

		public void LeftArrowPressed(object sender, EventArgs args)
		{
			if (positionX > 0)
			{
				positionX -= 1;
				Console.SetCursorPosition(positionX, positionY);
			}
		}

		public void RightArrowPressed(object sender, EventArgs args)
		{
			if (positionX < Console.LargestWindowWidth - 1)
			{
				positionX += 1;
				Console.SetCursorPosition(positionX, positionY);
			}
		}

		public void DownArrowPressed(object sender, EventArgs args)
		{
			if (positionY < Console.LargestWindowHeight - 1)
			{
				positionY += 1;
				Console.SetCursorPosition(positionX, positionY);
			}
		}

		public void UpArrowPressed(object sender, EventArgs args)
		{
			if (positionY > 0)
			{
				positionY -= 1;
				Console.SetCursorPosition(positionX, positionY);
			}
		}
	}
}


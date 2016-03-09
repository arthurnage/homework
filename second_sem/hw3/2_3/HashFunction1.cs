using System;

namespace MyWorks
{
	public class HashFunction1 : IHashFunction
	{
		// hash function
		public int GetHash(string line, int hashDigit)
		{
			int hashNumber = 0;
			for (int i = 0; i < line.Length; ++i)
			{
				hashNumber += line[i];
			}
			return hashNumber % hashDigit;
		}
	}
}


using System;

namespace MyWorks
{
	public class HashFunction2 : IHashFunction
	{
		// hash function
		public int GetHash(string line, int hashDigit)
		{
			return line[0] % hashDigit;
		}
	}
}


using System;

namespace MyWorks
{
	// interface for hash function
	public interface IHashFunction
	{
		int GetHash(string line, int hashDigit);
	}
}


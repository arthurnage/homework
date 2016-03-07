using System;

namespace MyWorks
{
	// class for using a hash table
	public class HashTable
	{
		private const int hashDigit = 10;
		private StringList[] array;
		private IHashFunction hashFunction;

		// constructor
		public HashTable(IHashFunction newHash)
		{
			hashFunction = newHash;
			array = new StringList[hashDigit];
			for (int i = 0; i < hashDigit; ++i)
			{
				array[i] = new StringList();
			}
		}

		// sending the line to the hash table
		public void Hashing(string line)
		{
			array[hashFunction.GetHash(line, hashDigit)].Push(line);
		}

		// print a hash table
		public void Print()
		{
			for (int i = 0; i < hashDigit; ++i)
			{
				Console.Write("{0}: ", i);
				array[i].Print();
				Console.WriteLine();
			}
		}

		// checks does a string belong to a hash table
		public bool IsBelong(string line)
		{
			return (array[hashFunction.GetHash(line, hashDigit)].CheckForBelong(line));
		}

		// removes a string from the hash table
		public void Remove(string line)
		{
			array[hashFunction.GetHash(line, hashDigit)].Remove(line);
		}
	}
}


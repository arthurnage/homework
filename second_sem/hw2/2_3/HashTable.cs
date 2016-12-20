using System;

namespace MyWorks
{
	// class for using a hash table
	public class HashTable
	{
		private const int hashDigit = 10;
		private StringList[] array;

		// constructor
		public HashTable()
		{
			array = new StringList[hashDigit];
			for (int i = 0; i < hashDigit; ++i)
			{
				array[i] = new StringList();
			}
		}

		// sending the line to the hash table
		public void Hashing(string line)
		{
			array[GetHash(line)].Push(line);
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
			return (array[GetHash(line)].CheckForBelong(line));
		}

		// removes a string from the hash table
		public void Remove(string line)
		{
			array[GetHash(line)].Remove(line);
		}

		// hashes the string
		private int GetHash(string line)
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


using System;
using ListNamespace;

namespace HashFunction
{
	// class for hashing a string
	public class HashFunc
	{
		private const int hashDigit = 10;
		private List[] array;

		// constructor
		public HashFunc()
		{

			array = new List[hashDigit];
			for (int i = 0; i < hashDigit; ++i)
			{
				array[i] = new List();
			}
		}

		// sending the line to the hash table
		public void Hashing(string line)
		{
			int hashNumber = 0;
			for (int i = 0; i < line.Length; ++i)
			{
				hashNumber += line [i];
			}
			array[hashNumber % hashDigit].Push(line);
		}

		// print a hash table
		public void Print()
		{
			for (int i = 0; i < hashDigit; ++i)
			{
				Console.Write ("{0}: ", i);
				array [i].Print ();
				Console.WriteLine ();
			}
		}

		// checks does a string belong to a hash table
		public bool IsBelong(string line)
		{
			int index = 0;
			for (int i = 0; i < line.Length; ++i)
			{
				index += line [i];
			}
			index %= hashDigit;
			if (array[index].CheckForBelong(line))
				return true;
			else 
				return false;
		}

		// removes a string from the hash table
		public void Remove(string line)
		{
			int hashNumber = 0;
			for (int i = 0; i < line.Length; ++i)
			{
				hashNumber += line [i];
			}
			array[hashNumber % hashDigit].Remove(line);
		}
	}
}


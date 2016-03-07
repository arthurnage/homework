using System;

namespace MyWorks
{
	// main class for using a hash table
	class MainClass
	{
		// main method
		public static void Main(string[] args)
		{
			Console.WriteLine("enter 0 if you want to use hashing a string by the first letter");
			Console.WriteLine("enter 1 for hashing by all the letters");
			bool hashChoise = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
			HashTable hashTable;
			if (hashChoise)
			{
				hashTable = new HashTable(new HashFunction1());
			}
			else
			{
				hashTable = new HashTable(new HashFunction2());
			}
			Console.WriteLine("enter a number of strings you want to hash");
			int n = Convert.ToInt32(Console.ReadLine());
			for (int i = 0; i < n; ++i)
			{
				string line = Console.ReadLine();
				hashTable.Hashing(line);
			}
			hashTable.Print();
		}
	}
}

using System;
using MyWorks;

namespace _3
{
	// main class for using a hash function
	class MainClass
	{
		// main method
		public static void Main(string[] args)
		{
			HashTable hashTable = new HashTable();
			Console.WriteLine("enter a number of strings you want to hash");
			// add 'arthur' string
			int n = Convert.ToInt32(Console.ReadLine());
			for (int i = 0; i < n; ++i)
			{
				string line = Console.ReadLine();
				hashTable.Hashing(line);
			}
			hashTable.Print();
			if (hashTable.IsBelong("arthur"))
			{
				Console.WriteLine("yes, 'arthur' string belongs to a hash table");
			}
			else
			{	
				Console.WriteLine("no, 'arthur' doesent belong to a hash table");
			}
			hashTable.Remove("arthur");
			hashTable.Print();
			if (hashTable.IsBelong("arthur"))
			{
				Console.WriteLine("yes, 'arthur' string belongs to a hash table");
			}
			else
			{	
				Console.WriteLine("no, 'arthur' doesent belong to a hash table");
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MyWorks
{
	class MainClass
	{
	    private const string connectionString = "mongodb://localhost:27017";
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main(string[] args)
		{
			var client = new MongoClient(connectionString);
			var database = client.GetDatabase("dictionary");
			var collection = database.GetCollection<Contact>("contacts");
			while (true)
			{
				Console.WriteLine("0 - exit");
				Console.WriteLine("1 - add contact");
				Console.WriteLine("2 - find phone number by name ");
				Console.WriteLine("3 - find name by phone number ");
				Console.Write("enter: ");
				int key = Convert.ToInt32(Console.ReadLine());
				switch (key)
				{
				case 0:
					{
						return;
					}
				case 1:
					{
						Console.Write("enter a name: ");
						string name = Console.ReadLine();
						Console.Write("enter phone number: ");
						string phoneNumber = Console.ReadLine();
						AddContact(collection, name, phoneNumber);
						break;
					}
				case 2:
					{
						Console.Write("enter a name: ");
						string name = Console.ReadLine();
						string phoneNumber = FindPhoneByName(collection, name);
						if (phoneNumber == null)
						{
							Console.WriteLine("--- not found");
						}
						else
						{
							Console.WriteLine("--- phone number: {0}", phoneNumber);
						}
						break;
					}
				case 3:
					{
						Console.Write("enter a phone number: ");
						string phoneNumber = Console.ReadLine();
						string name = FindNameByPhone(collection, phoneNumber);
						if (name == null)
						{
							Console.WriteLine("--- not found");
						}
						else
						{
							Console.WriteLine("--- name: {0}", name);
						}
						break;
					}
				default:
					{
						Console.WriteLine("--- wrong format");
						break;
					}
				}
			}
		}

		/// <summary>
		/// Print the specified collection.
		/// </summary>
		/// <param name="collection">Collection.</param>
		private static void Print(IMongoCollection<Contact> collection)
		{
			foreach (var contact in collection.Find(new BsonDocument()).ToList())
			{
				Console.WriteLine("name: " + contact.Name);
				Console.WriteLine("phone: " + contact.Phone);
				Console.WriteLine();
			}
		}

		/// <summary>
		/// Adds the contact.
		/// </summary>
		/// <param name="collection">Collection.</param>
		/// <param name="name">Name.</param>
		/// <param name="phoneNumber">Phone number.</param>
		private static void AddContact(IMongoCollection<Contact> collection, string name, string phoneNumber)
		{
			if (FindPhoneByName(collection, name) == null && FindNameByPhone(collection, phoneNumber) == null)
			{
				collection.InsertOne(new Contact() { Name = name, Phone = phoneNumber });
			}
			else
			{
				string contact = (FindPhoneByName(collection, name) == null) ? phoneNumber : name;
				Console.WriteLine("--- there is already a contact data in the dictionary: {0}", contact);
			}
		}

		/// <summary>
		/// Finds name by phone number.
		/// </summary>
		/// <param name="collection">Collection.</param>
		/// <param name="phoneNumber">Phone number.</param>
		private static string FindNameByPhone(IMongoCollection<Contact> collection, string phoneNumber)
		{
			foreach (var contact in collection.Find(new BsonDocument()).ToList())
			{
				if (contact.Phone == phoneNumber)
				{
					return contact.Name;
				}
			}
			return null;
		}

		/// <summary>
		/// Finds phone number by name.
		/// </summary>
		/// <returns>The phone by name.</returns>
		/// <param name="collection">Collection.</param>
		/// <param name="name">Name.</param>
		private static string FindPhoneByName(IMongoCollection<Contact> collection, string name)
		{
			foreach (var contact in collection.Find(new BsonDocument()).ToList())
			{
				if (contact.Name == name)
				{
					return contact.Phone;
				}
			}
			return null;
		}
	}
}

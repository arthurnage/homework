using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MyWorks
{
	/// <summary>
	/// class appearing as a contact of human being with name and phone number
	/// </summary>
	[BsonIgnoreExtraElements]
	public class Contact
	{
		public string Name { get; set; }
		public string Phone { get; set; }
	}
}


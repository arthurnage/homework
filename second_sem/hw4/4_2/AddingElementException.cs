using System;

namespace MyWorks
{
	// exception for adding an element that already exist in the list
	[Serializable]
	public class AddingElementException : ApplicationException
	{
		public AddingElementException() { }
		public AddingElementException(string message) : base(message) { }
		public AddingElementException(string message, Exception inner) 
			: base(message, inner) { }
		protected AddingElementException(
			System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context)
				: base(info, context) { }
	}
}


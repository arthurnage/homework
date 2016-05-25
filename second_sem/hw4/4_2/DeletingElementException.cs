using System;

namespace MyWorks
{
	// exception for adding an element that already exist in the list
	[Serializable]
	public class DeletingElementException : ApplicationException
	{
		public DeletingElementException() { }
		public DeletingElementException(string message) : base(message) { }
		public DeletingElementException(string message, Exception inner) 
			: base(message, inner) { }
		protected DeletingElementException(
			System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}
}
using System;

namespace MyWorks
{
	// exception for adding an element that already exist in the queue
	[Serializable]
	public class DeletingFromTheEmptyQueueException : ApplicationException
	{
		public DeletingFromTheEmptyQueueException() { }
		public DeletingFromTheEmptyQueueException(string message) : base(message) { }
		public DeletingFromTheEmptyQueueException(string message, Exception inner) 
			: base(message, inner) { }
		protected DeletingFromTheEmptyQueueException(
			System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}
}

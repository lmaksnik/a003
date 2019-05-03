using System.Runtime.Serialization;

namespace Storage.Exceptions {
	public class StorageException : System.Exception {
		public StorageException() { }

		protected StorageException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		public StorageException(string message) : base(message) { }

		public StorageException(string message, System.Exception innerException) : base(message, innerException) { }
	}
}

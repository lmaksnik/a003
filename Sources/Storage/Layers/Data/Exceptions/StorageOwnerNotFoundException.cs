using System;
using Storage.Exceptions;

namespace Storage.Layers.Data.Exceptions {
	public class StorageOwnerNotFoundException : StorageException {
		public StorageOwnerNotFoundException(Guid ownerId) : base($"Owner с идентификатором \"{ownerId}\" не найден. Owner по умолчанию отсутствует!") { }
	}
}

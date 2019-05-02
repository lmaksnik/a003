using System;

namespace Storage.Model {
	public class StorageOwner {

		public StorageOwner(Guid id, string name) {
			Id = id;
			Name = name;
		}

		public readonly Guid Id;

		public readonly string Name;

	}
}

using System;

namespace Storage.Layers.Data.Model {
	public class StorageMetaOwner : StorageMetaObject {

		internal StorageMetaOwner(Guid id, string name) : base(id) {
			Name = name;
		}

		public string Name { get; private set; }

	}
}

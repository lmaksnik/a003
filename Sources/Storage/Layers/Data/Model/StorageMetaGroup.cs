using System;

namespace Storage.Layers.Data.Model {
	public class StorageMetaGroup : StorageMetaObject {

		internal StorageMetaGroup(Guid id, string key) : base(id) {
			Key = key;
		}

		public string Key { get; set; }
	}
}

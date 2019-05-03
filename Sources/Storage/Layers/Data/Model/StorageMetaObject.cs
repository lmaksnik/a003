using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Layers.Data.Model {
	public abstract class StorageMetaObject {
		protected StorageMetaObject(Guid id) {
			Id = id;
		}

		public Guid Id { get; }

	}
}

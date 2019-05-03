using System;
using System.Collections.Generic;
using System.Text;
using Storage.Layers.MetaData.Model;

namespace Storage.Layers.Data.Model {
	public class StorageMetaItem : StorageMetaObject {

		internal StorageMetaItem(Guid id, StorageMetaOwner owner, StorageMetaStreamInfo streamInfo) : base(id) {
			Owner = owner;
			StreamInfo = streamInfo;
		}

		public StorageMetaOwner Owner { get; set; }

		public StorageMetaStreamInfo StreamInfo { get; set; }

	}
}

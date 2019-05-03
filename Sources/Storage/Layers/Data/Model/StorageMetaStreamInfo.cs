using System;

namespace Storage.Layers.Data.Model {
	public class StorageMetaStreamInfo : StorageMetaObject {

		internal StorageMetaStreamInfo(Guid id, string @group, string name, string contentType, bool isApproved) : base(id) {
			Group = @group;
			Name = name;
			ContentType = contentType;
			IsApproved = isApproved;
		}

		public string Group { get; private set; }

		public string Name { get; private set; }

		public string ContentType { get; private set; }

		public bool IsApproved { get; private set; }

	}
}

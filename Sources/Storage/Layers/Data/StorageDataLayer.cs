using System;
using System.IO;
using Storage.Layers.Data.Exceptions;
using Storage.Layers.Data.Model;
using Storage.Layers.Data.Providers;

namespace Storage.Layers.Data {
	public class StorageDataLayer : IDisposable {

		protected IStorageMetaProvider MetaProvider => StorageGlobal.Providers.Get<IStorageMetaProvider>();

		public StorageMetaStreamInfo Upload(Stream stream, StorageMetaOwner owner, string name, string groupKey = null, string contentType = null, bool approved = false) {
			if (stream == null || stream == Stream.Null) throw new ArgumentNullException(nameof(stream));
			if (owner == null) throw new ArgumentNullException(nameof(owner));
			if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

			var group = MetaProvider.GetGroup(groupKey);
			if (group == null)
				group = MetaProvider.CreateGroup(groupKey);
		}

		public virtual Stream Get(Guid id, Guid ownerId) {
			
		}

		public virtual void Remove(Guid id, Guid ownerId) {
			
		}

		public void Dispose() {
			
		}
	}

}

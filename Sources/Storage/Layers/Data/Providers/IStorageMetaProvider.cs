using System;
using Storage.Layers.Data.Model;

namespace Storage.Layers.Data.Providers {
	public interface IStorageMetaProvider : IStorageProvider {

		StorageMetaOwner GetOwner(Guid ownerId);

		StorageMetaGroup GetGroup(string groupKey);

		StorageMetaGroup CreateGroup(string groupKey);

		StorageMetaItem GetItem(Guid itemId);

		StorageMetaStreamInfo CreateStreamInfo(string group, string name, string contentType, bool isApproved);

		void Approve(StorageMetaStreamInfo streamInfo);

		void Delete(StorageMetaStreamInfo streamInfo);

	}
}

using System;
using Storage.Filters.Model;

namespace Storage.Filters {
	public interface IStorageActionFilter : IStorageFilter {

		void Executing(StorageContext context);

		void Executed(StorageContext context);

	}
}

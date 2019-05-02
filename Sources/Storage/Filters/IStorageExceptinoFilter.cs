using System;
using System.Collections.Generic;
using System.Text;
using Storage.Filters.Model;

namespace Storage.Filters {
	public interface IStorageExceptinoFilter : IStorageFilter {

		void OnException(StorageContext context);

	}
}

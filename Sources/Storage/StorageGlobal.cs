using System;
using System.Collections.Generic;
using System.Text;
using Storage.Filters.Model;
using Storage.Global;
using Storage.Layers.Data.Model;

namespace Storage {
	public class StorageGlobal {

		public static readonly ICollection<IStorageFilter> Filters = new List<IStorageFilter>();

		/// <summary>
		/// Коллекция провайдеров
		/// </summary>
		public static readonly StorageProviderCollection Providers = new StorageProviderCollection();

		/// <summary>
		/// Владелец по умолчанию для загружаемых фалов с не указанным владельцем
		/// </summary>
		public static StorageMetaOwner DefaultOwner { get; set; }


	}
}

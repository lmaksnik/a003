using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Storage.Layers.Data.Providers;

namespace Storage.Global {
	public class StorageProviderCollection : ICollection {
		protected List<IStorageProvider> Inner = new List<IStorageProvider>();

		public TProvider Get<TProvider>(bool throwIfNotFound = true) {
			var provider = Find<TProvider>().LastOrDefault();
			if (provider == null && throwIfNotFound) throw BuildProviderNotFoundException(typeof(TProvider));
			return provider;
		}

		public TProvider[] Find<TProvider>() where TProvider : IStorageProvider {
			return Inner.OfType<TProvider>().ToArray();
		}

		private Exception BuildProviderNotFoundException(Type providerType) {
			var msg = $"Провайдер \"{providerType.FullName}\" не найден среди зарегистрированных.\n";
			var help = $"{nameof(StorageGlobal)}.{nameof(StorageGlobal.Providers)}.{nameof(StorageGlobal.Providers.Add)}(new MyProvider());";
			return new Exception($"{msg}\nПровайдер дожавляется следующим образом:\n{help}");
		}

		#region Implemented

		public IEnumerator GetEnumerator() {
			return Inner.GetEnumerator();
		}

		public void CopyTo(Array array, int index) {
			Inner.ToArray().CopyTo(array, index);
		}

		public int Count => Inner.Count;

		public bool IsSynchronized => Inner.ToArray().IsSynchronized;

		public object SyncRoot => Inner.ToArray().SyncRoot;

		#endregion
	}
}

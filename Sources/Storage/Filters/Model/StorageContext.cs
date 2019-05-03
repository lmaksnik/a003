using System;
using Storage.Model;

namespace Storage.Filters.Model {
	public class StorageContext {

		internal StorageContext(StreamInfo info, StorageOwner storageOwner, StorageFilterAction action) {
			Info = info;
			StorageOwner = storageOwner;
			Action = action;
		}

		public readonly StreamInfo Info;

		public readonly StorageOwner StorageOwner;

		public readonly StorageFilterAction Action;

		public bool Handled { get; set; }

		public object Result { get; set; }

		public Exception Exception { get; set; }
	}

	public class StorageContext<TResult> : StorageContext {

		internal StorageContext(StreamInfo info, StorageOwner storageOwner, StorageFilterAction action) : base(info, storageOwner, action) {}

		public new TResult Result {
			get => (TResult)base.Result;
			set => base.Result = value;
		}
	}

	public enum StorageFilterAction {
		None,
		Upload,
		Get,
		Remove
	}
}

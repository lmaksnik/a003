using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Storage.Filters;
using Storage.Filters.Model;
using Storage.Model;

namespace Storage {
	public abstract class StorageBase : IDisposable {

		public virtual Guid Upload(Stream stream, Guid ownerId, string name, string group = null, string contentType = null, bool approved = false) {
			var streamInfo = new StreamInfo(Stream.Null, "my.file", "file-file", "Custom", true);
			var owner = new StorageOwner(ownerId, "MLP");
			var context = new StorageContext<StreamInfo>(streamInfo, owner, StorageFilterAction.Upload);
			
			CallAction(context, () => {
				//call data layer
			});

			return context.Result.Id;
		}

		public virtual Stream Get(Guid id, Guid ownerId) {
			var streamInfo = new StreamInfo(Stream.Null, "my.file", "file-file", "Custom", true);
			var owner = new StorageOwner(ownerId, "MLP");
			var context = new StorageContext<Stream>(streamInfo, owner, StorageFilterAction.Get);

			CallAction(context, () => {
				//call data layer
			});

			return context.Result;
		}

		public virtual void Remove(Guid id, Guid ownerId) {
			var streamInfo = new StreamInfo(Stream.Null, "my.file", "file-file", "Custom", true);
			var owner = new StorageOwner(ownerId, "MLP");
			var context = new StorageContext<Stream>(streamInfo, owner, StorageFilterAction.Remove);

			CallAction(context, () => {
				//call data layer
			});
		}

		public virtual void Dispose() {
			
		}

		#region Helpers

		protected void CallAction(StorageContext context, Action action) {
			try {
				CallFilters<IStorageActionFilter>(context, (filter) => { filter.Executing(context); }, true);

				if (context.Handled) return;

				action();

				CallFilters<IStorageActionFilter>(context, (filter) => { filter.Executed(context); }, true);
			}
			catch (Exception ex) {
				context.Exception = ex;
			}
			finally {
				if (context.Exception != null) {
					if (!context.Handled)
						CallFilters<IStorageExceptinoFilter>(context, filter => { filter.OnException(context); });

					throw context.Exception;
				}
			}
		}

		protected void CallFilters<TFilterType>(StorageContext context, Action<TFilterType> executeAction, bool throwIfException = false) where TFilterType : IStorageFilter {
			if (!context.Handled) {
				try {
					foreach (TFilterType filter in StorageGlobal.Filters.OfType<TFilterType>()) {
						executeAction(filter);

						if (context.Handled)
							break;
					}
				} catch (Exception ex) {
					context.Exception = ex;
					if (throwIfException)
						throw ex;
				}
			}
		}

		#endregion
	}
}

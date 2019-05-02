using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Storage.Filters;
using Storage.Filters.Model;
using Storage.Model;

namespace Storage {
	public abstract class StorageBase : IDisposable {

		public readonly ICollection<IStorageFilter> Filters = new List<IStorageFilter>();

		public Guid Upload(Stream stream, Guid ownerId, string name, string group = null, string contentType = null, bool approved = false) {
			var streamInfo = new StreamInfo(Stream.Null, "my.file", "file-file", "Custom", true);
			var owner = new StorageOwner(ownerId, "MLP");
			var context = new StorageContext(streamInfo, owner, StorageFilterAction.Upload);
			
			Execute(context, () => {
				//call data layer
			});

			return context.Result.Id;
		}

		public Stream Get(Guid id, Guid ownerId) {
			return Stream.Null;
		}

		public void Remove(Guid id, Guid ownerId) {

		}

		public void Dispose() {
			
		}

		#region Helpers

		protected void Execute(StorageContext context, Action action) {
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
			try {
				foreach (TFilterType filter in Filters.OfType<TFilterType>()) {
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

		#endregion
	}
}

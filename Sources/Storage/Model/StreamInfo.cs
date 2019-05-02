using System;
using System.IO;

namespace Storage.Model {
	public class StreamInfo {

		internal StreamInfo(Stream stream, string name, string contextType, string @group, bool isApproved) {
			Id = Guid.NewGuid();
			Stream = stream;
			Name = name;
			ContextType = contextType;
			Group = @group;
			IsApproved = isApproved;
		}

		public readonly Guid Id;

		public readonly Stream Stream;

		public readonly string Name;

		public readonly string ContextType;

		public readonly string Group;

		public readonly bool IsApproved;
	}
}

using System;

namespace MockAllTheThings.Core
{
	public static class Create
	{
		private static IMockProvider _instance;
		private static readonly object _lock = new object();

		internal static IMockProvider Instance {
			get {
				lock (_lock) {
					return _instance;
				}
			}
		}

		public static void UsingProvider(IMockProvider mockProvider) {
			lock (_lock) {
				_instance = mockProvider;
			}
		}

		public static CreateBuilderInitial<T> MeA<T>() {
			if (Instance.IsNull()) {
				throw new InvalidOperationException("Create must first be configured with a Mock Provider.");
			}

			return new CreateBuilderInitial<T>();
		}
	}
}


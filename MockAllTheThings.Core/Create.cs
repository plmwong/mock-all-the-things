using System;

namespace MockAllTheThings.Core
{
	public static class Create
	{
		internal static IMockProvider MockProvider;

		public static void UsingProvider(IMockProvider mockProvider) {
			MockProvider = mockProvider;
		}

		public static CreateBuilderInitial<T> MeA<T>() {
			if (MockProvider.IsNull()) {
				throw new InvalidOperationException("Create must first be configured with a Mock Provider.");
			}

			return new CreateBuilderInitial<T>();
		}
	}
}


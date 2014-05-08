using System;

namespace MockAllTheThings.Core
{
	public static class Create
	{
		private static IMockProvider _instance;
		private static readonly object Lock = new object();

		internal static IMockProvider Instance {
			get {
				lock (Lock) {
					return _instance;
				}
			}
		}

		public static void UsingProvider(IMockProvider mockProvider) {
			lock (Lock) {
				_instance = mockProvider;
			}
		}

		public static void UsingProvider(Func<Type, object> factoryMethod) {
			lock (Lock) {
				_instance = new FactoryMethodMockProvider(factoryMethod);
			}
		}

		public static CreateBuilderInitial<T> A<T>() {
			if (Instance.IsNull()) {
				throw new InvalidOperationException("Create must first be configured with a Mock Provider.");
			}

			return new CreateBuilderInitial<T>();
		}
	}
}


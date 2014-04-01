using System;

namespace MockAllTheThings.Core
{
	public class FactoryMethodMockProvider : IMockProvider
	{
		readonly Func<Type, object> _factoryMethod;

		public FactoryMethodMockProvider(Func<Type, object> factoryMethod) {
			Must.NotBeNull(() => factoryMethod);

			_factoryMethod = factoryMethod;
		}

		#region IMockProvider implementation

		public object CreateMock(Type type)
		{
			return _factoryMethod(type);
		}

		#endregion
	}
}


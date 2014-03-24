using System;

namespace MockAllTheThings
{
	public class PlzMock<T>
	{
		IMockProvider _mockProvider;

		public PlzMock() {
			_mockProvider = new MoqMockProvider();
		}

		public T AllTheThings() {
			var typeToMock = typeof(T);

			var constructorInfo = typeToMock.GetConstructors()[0];

			var parametersToMock = constructorInfo.GetParameters();
			var mockedParameters = new object[parametersToMock.Length];

			for (int i = 0; i < parametersToMock.Length; i++) {
				var parameterType = parametersToMock[i].ParameterType;

				var mockedObject = _mockProvider.CreateMock(parameterType);

				mockedParameters[i] = mockedObject;
			}

			var mockedType = constructorInfo.Invoke(mockedParameters);

			return (T)mockedType;
		}
	}
}


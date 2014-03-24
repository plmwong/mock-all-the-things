using System;
using System.Collections.Generic;

namespace MockAllTheThings
{
	public class Create<T>
	{
		IMockProvider _mockProvider;
		readonly IDictionary<Type, object> _configuredMocks;

		public Create() {
			_mockProvider = new MoqMockProvider();
			_configuredMocks = new Dictionary<Type, object>();
		}

		public Create<T> UsingProvider(IMockProvider mockProvider) {
			_mockProvider = mockProvider;
			return this;
		}

		public Create<T> UsingThisMockFor<TMock>(TMock mockedObject) {
			_configuredMocks.Add(typeof(TMock), mockedObject);
			return this;
		}

		public T MockingAllTheThings() {
			var typeToMock = typeof(T);

			var constructorInfo = typeToMock.GetConstructors()[0];

			var parametersToMock = constructorInfo.GetParameters();
			var mockedParameters = new object[parametersToMock.Length];

			for (int i = 0; i < parametersToMock.Length; i++) {
				var parameterType = parametersToMock[i].ParameterType;

				object mockedObject;

				if (_configuredMocks.ContainsKey(parameterType)) {
					mockedObject = _configuredMocks[parameterType];
				} else {
					mockedObject = _mockProvider.CreateMock(parameterType);
				}

				mockedParameters[i] = mockedObject;
			}

			var mockedType = constructorInfo.Invoke(mockedParameters);

			return (T)mockedType;
		}
	}
}


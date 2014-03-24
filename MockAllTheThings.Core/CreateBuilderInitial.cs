using System;
using System.Collections.Generic;

namespace MockAllTheThings.Core
{
	public class CreateBuilderInitial<T>
	{
		readonly IDictionary<Type, object> _configuredMocks;

		public CreateBuilderInitial()
		{
			_configuredMocks = new Dictionary<Type, object>();
		}

		public CreateBuilderConfigured<T> UsingThisInstanceToMock<TMock>(TMock mockedObject) {
			_configuredMocks.Add(typeof(TMock), mockedObject);
			return new CreateBuilderConfigured<T>(this);
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
					mockedObject = Create.MockProvider.CreateMock(parameterType);
				}

				mockedParameters[i] = mockedObject;
			}

			var mockedType = constructorInfo.Invoke(mockedParameters);

			return (T)mockedType;
		}
	}
}


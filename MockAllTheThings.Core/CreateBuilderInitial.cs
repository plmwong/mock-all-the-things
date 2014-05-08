using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace MockAllTheThings.Core
{
	public class CreateBuilderInitial<T>
	{
		readonly IDictionary<Type, object> _configuredMocks;
		readonly IDictionary<int, object> _configuredIndexMocks;

		public CreateBuilderInitial() {
			_configuredMocks = new Dictionary<Type, object>();
			_configuredIndexMocks = new Dictionary<int, object>();
		}

		public CreateBuilderConfiguredTypeMock<T> UsingInstanceFor<TMock>(TMock mockedObject) {
            Must.NotBeNull(() => mockedObject);

			_configuredMocks.Add(typeof(TMock), mockedObject);
			return new CreateBuilderConfiguredTypeMock<T>(this, typeof(TMock));
		}

		public T MockingAllTheThings() {
			var typeToMock = typeof(T);

			var constructorInfo = typeToMock
										.GetConstructors()
										.OrderBy(c => c.GetParameters().Length)
										.First();

			var parametersToMock = constructorInfo.GetParameters();
			var mockedParameters = new object[parametersToMock.Length];

			for (int i = 0; i < parametersToMock.Length; i++) {
				var parameterToMockType = parametersToMock[i].ParameterType;

				object mockedObject;

				if (_configuredIndexMocks.ContainsKey(i)) {
					mockedObject = _configuredIndexMocks[i];
				} else if (_configuredMocks.ContainsKey(parameterToMockType)) {
					mockedObject = _configuredMocks[parameterToMockType];
				} else {
					mockedObject = Create.Instance.CreateMock(parameterToMockType);
				}

				mockedParameters[i] = mockedObject;
			}

			Debug.Assert(mockedParameters.All(m => m.IsNotNull()));

			var mockedType = constructorInfo.Invoke(mockedParameters);

			return (T)mockedType;
		}

		internal void TransferTypeMockToIndexedMock(Type mockType, int index) {
			var mockedObject = _configuredMocks[mockType];
			_configuredIndexMocks.Add(index, mockedObject);
			_configuredMocks.Remove(mockType);
		}
	}
}


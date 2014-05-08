using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace MockAllTheThings.Core
{
    public class CreateBuilderInitial<T>
    {
		internal readonly IDictionary<Type, object> ConfiguredMocks;
		internal readonly IDictionary<int, object> ConfiguredIndexMocks;

		public CreateBuilderInitial() {
			ConfiguredMocks = new Dictionary<Type, object>();
			ConfiguredIndexMocks = new Dictionary<int, object>();
		}

        public ForBuilderInitial<T, TMock> For<TMock>()
	    {
            return new ForBuilderInitial<T, TMock>(this);
	    }

		public T MockAllTheThings() {
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

				if (ConfiguredIndexMocks.ContainsKey(i)) {
					mockedObject = ConfiguredIndexMocks[i];
				} else if (ConfiguredMocks.ContainsKey(parameterToMockType)) {
					mockedObject = ConfiguredMocks[parameterToMockType];
				} else {
					mockedObject = Create.Instance.CreateMock(parameterToMockType);
				}

				mockedParameters[i] = mockedObject;
			}

			Debug.Assert(mockedParameters.All(m => m.IsNotNull()));

			var mockedType = constructorInfo.Invoke(mockedParameters);

			return (T)mockedType;
		}
	}
}


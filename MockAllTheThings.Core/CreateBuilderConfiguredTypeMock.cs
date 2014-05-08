using System;

namespace MockAllTheThings.Core
{
	public class CreateBuilderConfiguredTypeMock<T>
	{
		private readonly CreateBuilderInitial<T> _initialBuilder;
		private Type _lastMockedObjectType;

		public CreateBuilderConfiguredTypeMock(CreateBuilderInitial<T> initialBuilder, Type lastMockedObjectType) {
			_initialBuilder = initialBuilder;
			_lastMockedObjectType = lastMockedObjectType;
		}

        public CreateBuilderConfiguredIndexedMock<T> At(int parameterIndex) {
			_initialBuilder.TransferTypeMockToIndexedMock(_lastMockedObjectType, parameterIndex);
			return new CreateBuilderConfiguredIndexedMock<T>(this);
		}

		public CreateBuilderConfiguredTypeMock<T> UsingInstanceFor<TMock>(TMock mockedObject) {
			_initialBuilder.UsingInstanceFor(mockedObject);
			_lastMockedObjectType = typeof(TMock);
			return this;
		}

		public T MockingAllTheOtherThings() {
			return _initialBuilder.MockingAllTheThings();
		}
	}
}


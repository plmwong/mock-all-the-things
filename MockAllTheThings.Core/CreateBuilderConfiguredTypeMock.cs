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

		public CreateBuilderConfiguredIndexedMock<T> SpecificallyForTheArgumentAt(int parameterIndex) {
			_initialBuilder.TransferTypeMockToIndexedMock(_lastMockedObjectType, parameterIndex);
			return new CreateBuilderConfiguredIndexedMock<T>(this);
		}

		public CreateBuilderConfiguredTypeMock<T> AndUsingThisInstanceToMock<TMock>(TMock mockedObject) {
			_initialBuilder.UsingThisInstanceToMock<TMock>(mockedObject);
			_lastMockedObjectType = typeof(TMock);
			return this;
		}

		public T AndMockingAllTheOtherThings() {
			return _initialBuilder.MockingAllTheThings();
		}
	}
}


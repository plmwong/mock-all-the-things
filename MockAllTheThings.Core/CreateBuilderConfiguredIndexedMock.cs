
namespace MockAllTheThings.Core
{
	public class CreateBuilderConfiguredIndexedMock<T>
	{
		private readonly CreateBuilderConfiguredTypeMock<T> _configuredMockBuilder;

		public CreateBuilderConfiguredIndexedMock(CreateBuilderConfiguredTypeMock<T> configuredMockBuilder) {
			_configuredMockBuilder = configuredMockBuilder;
		}

		public CreateBuilderConfiguredTypeMock<T> AndUsingThisInstanceToMock<TMock>(TMock mockedObject) {
			_configuredMockBuilder.AndUsingThisInstanceToMock<TMock>(mockedObject);
			return _configuredMockBuilder;
		}

		public T AndMockingAllTheOtherThings() {
			return _configuredMockBuilder.AndMockingAllTheOtherThings();
		}
	}
}


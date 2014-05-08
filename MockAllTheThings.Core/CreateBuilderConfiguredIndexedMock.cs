
namespace MockAllTheThings.Core
{
	public class CreateBuilderConfiguredIndexedMock<T>
	{
		private readonly CreateBuilderConfiguredTypeMock<T> _configuredMockBuilder;

		public CreateBuilderConfiguredIndexedMock(CreateBuilderConfiguredTypeMock<T> configuredMockBuilder) {
			_configuredMockBuilder = configuredMockBuilder;
		}

        public CreateBuilderConfiguredTypeMock<T> UsingInstanceFor<TMock>(TMock mockedObject) {
            _configuredMockBuilder.UsingInstanceFor(mockedObject);
			return _configuredMockBuilder;
		}

		public T MockingAllTheOtherThings() {
			return _configuredMockBuilder.MockingAllTheOtherThings();
		}
	}
}


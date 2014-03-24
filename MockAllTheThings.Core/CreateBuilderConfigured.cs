
namespace MockAllTheThings.Core
{
	public class CreateBuilderConfigured<T>
	{
		private readonly CreateBuilderInitial<T> _initialBuilder;

		public CreateBuilderConfigured(CreateBuilderInitial<T> initialBuilder)
		{
			_initialBuilder = initialBuilder;
		}

		public CreateBuilderConfigured<T> AndUsingThisInstanceToMock<TMock>(TMock mockedObject) {
			_initialBuilder.UsingThisInstanceToMock<TMock>(mockedObject);
			return this;
		}

		public T AndMockingAllTheOtherThings() {
			return _initialBuilder.MockingAllTheThings();
		}
	}
}


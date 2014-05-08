namespace MockAllTheThings.Core
{
    public class CreateBuilderConfigured<T>
	{
        private readonly CreateBuilderInitial<T> _initialBuilder;

        public CreateBuilderConfigured(CreateBuilderInitial<T> initialBuilder) {
            _initialBuilder = initialBuilder;
		}

        public ForBuilderInitial<T, TMock> For<TMock>()
	    {
            return new ForBuilderInitial<T, TMock>(_initialBuilder);
	    }

		public T MockAllTheOtherThings()
		{
		    return _initialBuilder.MockAllTheThings();
		}
	}
}


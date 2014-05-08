namespace MockAllTheThings.Core
{
    public class ForBuilderInitial<T, TMock>
    {
        private readonly CreateBuilderInitial<T> _createBuilder;

        public ForBuilderInitial(CreateBuilderInitial<T> createBuilder) {
            _createBuilder = createBuilder;
        }

        public ForBuilderIndexedMock<T, TMock> At(int index) {
            return new ForBuilderIndexedMock<T, TMock>(index, _createBuilder);
        }

        public CreateBuilderConfigured<T> Use(TMock mockedObject) {
            _createBuilder.ConfiguredMocks.Add(typeof(TMock), mockedObject);
            return new CreateBuilderConfigured<T>(_createBuilder);
        }
    }
}
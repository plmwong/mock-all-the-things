namespace MockAllTheThings.Core
{
    public class ForBuilderIndexedMock<T, TMock>
    {
        private readonly int _index;
        private readonly CreateBuilderInitial<T> _createBuilder;

        public ForBuilderIndexedMock(int index, CreateBuilderInitial<T> createBuilder) {
            _index = index;
            _createBuilder = createBuilder;
        }

        public CreateBuilderInitial<T> Use(TMock mockedObject) {
            _createBuilder.ConfiguredIndexMocks.Add(_index, mockedObject);
            return _createBuilder;
        }
    }
}
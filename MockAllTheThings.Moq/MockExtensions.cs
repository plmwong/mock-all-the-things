using Moq;

namespace MockAllTheThings.Moq
{
    public static class MockExtensions
    {
        public static Mock<T> GetMock<T>(this T mockedObject) where T : class
        {
            return Mock.Get(mockedObject);
        }
    }
}
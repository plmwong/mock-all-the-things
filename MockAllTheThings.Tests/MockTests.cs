using NUnit.Framework;

namespace MockAllTheThings.Tests
{
	[TestFixture]
	public class MockTests
	{
		[Test]
		public void CanMockTestServiceWithMixedDependencies()
		{
			var mockedTestService = new PlzMock<TestServiceWithMixedDependencies>().AllTheThings();

			Assert.IsNotNull(mockedTestService);
			Assert.IsInstanceOf<TestServiceWithMixedDependencies>(mockedTestService);
		}
	}
}


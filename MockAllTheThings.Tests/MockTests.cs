using NUnit.Framework;
using Moq;

namespace MockAllTheThings.Tests
{
	[TestFixture]
	public class MockTests
	{
		[Test]
		public void CanMockTestServiceWithMixedDependencies()
		{
			var mockedTestService = new Create<TestServiceWithMixedDependencies>()
											.MockingAllTheThings();

			Assert.IsNotNull(mockedTestService);
			Assert.IsInstanceOf<TestServiceWithMixedDependencies>(mockedTestService);
		}

		[Test]
		public void CanMockTestServiceWithPresuppliedMock()
		{
			var mockTestInterface = new Mock<ITestInterface>();
			var mockTestInterfaceObject = mockTestInterface.Object;

			var mockedTestService = 
				new Create<TestServiceWithMixedDependencies>()
					.UsingThisMockFor<ITestInterface>(mockTestInterfaceObject)
					.MockingAllTheThings();

			Assert.IsNotNull(mockedTestService);
			Assert.IsInstanceOf<TestServiceWithMixedDependencies>(mockedTestService);

			Assert.AreSame(mockedTestService.TestInterface, mockTestInterfaceObject);
		}
	}
}


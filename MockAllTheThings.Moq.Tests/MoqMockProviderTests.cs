using NUnit.Framework;
using Moq;
using MockAllTheThings.Core;

namespace MockAllTheThings.Moq.Tests
{
	[TestFixture]
	public class MoqMockProviderTests
	{
		[TestFixtureSetUp]
		public void SetUp() {
			Create.UsingProvider(new MoqMockProvider());
		}

		[Test]
		public void CanMockTestServiceWithMixedDependencies()
		{
			var mockedTestService = 
				Create
					.MeA<TestServiceWithMixedDependencies>()
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
				Create
					.MeA<TestServiceWithMixedDependencies>()
					.UsingThisInstanceToMock<ITestInterface>(mockTestInterfaceObject)
					.AndMockingAllTheOtherThings();

			Assert.IsNotNull(mockedTestService);
			Assert.IsInstanceOf<TestServiceWithMixedDependencies>(mockedTestService);

			Assert.AreSame(mockedTestService.TestInterface, mockTestInterfaceObject);
		}

		[Test]
		public void CanMockTestServiceWithMultiplePresuppliedMocks()
		{
			var mockTestInterface = new Mock<ITestInterface>();
			var mockTestInterfaceObject = mockTestInterface.Object;

			var mockedTestService = 
				Create
					.MeA<TestServiceWithMixedDependencies>()
					.UsingThisInstanceToMock<ITestInterface>(mockTestInterfaceObject)
					.AndUsingThisInstanceToMock<TestAbstractClass>(new Mock<TestAbstractClass>().Object)
					.AndMockingAllTheOtherThings();

			Assert.IsNotNull(mockedTestService);
			Assert.IsInstanceOf<TestServiceWithMixedDependencies>(mockedTestService);

			Assert.AreSame(mockedTestService.TestInterface, mockTestInterfaceObject);
		}
	}
}


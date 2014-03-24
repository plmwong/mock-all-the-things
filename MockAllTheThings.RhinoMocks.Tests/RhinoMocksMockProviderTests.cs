using NUnit.Framework;
using MockAllTheThings.Core;
using MockAllTheThings.RhinoMocks;
using Rhino.Mocks;

namespace MockAllTheThings.RhinoMocks.Tests
{
	[TestFixture]
	public class RhinoMocksMockProviderTests
	{
		[TestFixtureSetUp]
		public void SetUp() {
			Create.UsingProvider(new RhinoMocksMockProvider());
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
			var mockTestInterface = MockRepository.GenerateMock<ITestInterface>();

			var mockedTestService = 
				Create
					.MeA<TestServiceWithMixedDependencies>()
					.UsingThisInstanceToMock<ITestInterface>(mockTestInterface)
					.AndMockingAllTheOtherThings();

			Assert.IsNotNull(mockedTestService);
			Assert.IsInstanceOf<TestServiceWithMixedDependencies>(mockedTestService);

			Assert.AreSame(mockedTestService.TestInterface, mockTestInterface);
		}

		[Test]
		public void CanMockTestServiceWithMultiplePresuppliedMocks()
		{
			var mockTestInterface = MockRepository.GenerateMock<ITestInterface>();

			var mockedTestService = 
				Create
					.MeA<TestServiceWithMixedDependencies>()
					.UsingThisInstanceToMock<ITestInterface>(mockTestInterface)
					.AndUsingThisInstanceToMock<TestAbstractClass>(MockRepository.GenerateMock<TestAbstractClass>())
					.AndMockingAllTheOtherThings();

			Assert.IsNotNull(mockedTestService);
			Assert.IsInstanceOf<TestServiceWithMixedDependencies>(mockedTestService);

			Assert.AreSame(mockedTestService.TestInterface, mockTestInterface);
		}
	}
}


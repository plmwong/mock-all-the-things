using NUnit.Framework;
using Moq;
using MockAllTheThings.Core;
using MockAllTheThings.Testing;

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
		public void CanCreateAMockOfAServiceWithMixedConstructorDependencyTypes()
		{
			var mockedTestService = 
				Create
					.MeA<TestServiceWithMixedDependencies>()
					.MockingAllTheThings();

			Assert.IsNotNull(mockedTestService);
			Assert.IsInstanceOf<TestServiceWithMixedDependencies>(mockedTestService);
		}

		[Test]
		public void CanCreateAMockTestServiceUsingAPresuppliedMock()
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
		public void CanCreateAMockTestServiceUsingMultiplePresuppliedMocks()
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

		[Test]
		public void CanCreateAMockTestServiceUsingAnIndexedMock()
		{
			var mockTestInterface = new Mock<ITestInterface>();
			var mockTestInterfaceObject = mockTestInterface.Object;

			var mockedTestService = 
				Create
					.MeA<TestServiceWithMixedDependencies>()
					.UsingThisInstanceToMock<ITestInterface>(mockTestInterfaceObject)
					.SpecificallyForTheArgumentAt(0)
					.AndUsingThisInstanceToMock<TestAbstractClass>(new Mock<TestAbstractClass>().Object)
					.AndMockingAllTheOtherThings();

			Assert.IsNotNull(mockedTestService);
			Assert.IsInstanceOf<TestServiceWithMixedDependencies>(mockedTestService);

			Assert.AreSame(mockedTestService.TestInterface, mockTestInterfaceObject);
		}

		[Test]
		public void CanCreateAMockTestServiceWithIndexedMockWhenThereAreMultipleDependenciesOfSameInterface_FirstPosition()
		{
			var mockTestInterface = new Mock<ITestInterface>();
			var mockTestInterfaceObject = mockTestInterface.Object;

			var mockedTestService = 
				Create
					.MeA<TestServiceWithMultipleIdenticalDependencies>()
					.UsingThisInstanceToMock<ITestInterface>(mockTestInterfaceObject)
					.SpecificallyForTheArgumentAt(0)
					.AndMockingAllTheOtherThings();

			Assert.IsNotNull(mockedTestService);
			Assert.IsInstanceOf<TestServiceWithMultipleIdenticalDependencies>(mockedTestService);

			Assert.AreSame(mockedTestService.TestInterface1, mockTestInterfaceObject);
			Assert.AreNotSame(mockedTestService.TestInterface2, mockTestInterfaceObject);
			Assert.AreNotSame(mockedTestService.TestInterface3, mockTestInterfaceObject);
			Assert.AreNotSame(mockedTestService.TestInterface2, mockedTestService.TestInterface3);
		}

		[Test]
		public void CanMockTestServiceWithIndexedMockWhenThereAreMultipleDependenciesOfSameInterface_LastPosition()
		{
			var mockTestInterface = new Mock<ITestInterface>();
			var mockTestInterfaceObject = mockTestInterface.Object;

			var mockedTestService = 
				Create
					.MeA<TestServiceWithMultipleIdenticalDependencies>()
					.UsingThisInstanceToMock<ITestInterface>(mockTestInterfaceObject)
					.SpecificallyForTheArgumentAt(2)
					.AndMockingAllTheOtherThings();

			Assert.IsNotNull(mockedTestService);
			Assert.IsInstanceOf<TestServiceWithMultipleIdenticalDependencies>(mockedTestService);

			Assert.AreSame(mockedTestService.TestInterface3, mockTestInterfaceObject);
			Assert.AreNotSame(mockedTestService.TestInterface1, mockTestInterfaceObject);
			Assert.AreNotSame(mockedTestService.TestInterface2, mockTestInterfaceObject);
			Assert.AreNotSame(mockedTestService.TestInterface1, mockedTestService.TestInterface2);
		}

		[Test]
		public void CanMockTestServiceWithTypeMocksWhenThereAreMultipleDependenciesOfSameInterface()
		{
			var mockTestInterface = new Mock<ITestInterface>();
			var mockTestInterfaceObject = mockTestInterface.Object;

			var mockedTestService = 
				Create
					.MeA<TestServiceWithMultipleIdenticalDependencies>()
					.UsingThisInstanceToMock<ITestInterface>(mockTestInterfaceObject)
					.AndMockingAllTheOtherThings();

			Assert.IsNotNull(mockedTestService);
			Assert.IsInstanceOf<TestServiceWithMultipleIdenticalDependencies>(mockedTestService);

			Assert.AreSame(mockedTestService.TestInterface1, mockTestInterfaceObject);
			Assert.AreSame(mockedTestService.TestInterface2, mockTestInterfaceObject);
			Assert.AreSame(mockedTestService.TestInterface3, mockTestInterfaceObject);
			Assert.AreSame(mockedTestService.TestInterface2, mockedTestService.TestInterface3);
		}
	}
}


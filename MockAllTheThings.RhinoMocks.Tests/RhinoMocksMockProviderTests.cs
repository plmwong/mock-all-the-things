using NUnit.Framework;
using MockAllTheThings.Core;
using MockAllTheThings.RhinoMocks;
using MockAllTheThings.Testing;
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
		public void CanCreateAMockTestServiceUsingMultiplePresuppliedMocks()
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

		[Test]
		public void CanCreateAMockTestServiceUsingAnIndexedMock()
		{
			var mockTestInterfaceObject = MockRepository.GenerateMock<ITestInterface>();

			var mockedTestService = 
				Create
					.MeA<TestServiceWithMixedDependencies>()
					.UsingThisInstanceToMock<ITestInterface>(mockTestInterfaceObject)
					.SpecificallyForTheArgumentAt(0)
					.AndUsingThisInstanceToMock<TestAbstractClass>(MockRepository.GenerateMock<TestAbstractClass>())
					.AndMockingAllTheOtherThings();

			Assert.IsNotNull(mockedTestService);
			Assert.IsInstanceOf<TestServiceWithMixedDependencies>(mockedTestService);

			Assert.AreSame(mockedTestService.TestInterface, mockTestInterfaceObject);
		}

		[Test]
		public void CanCreateAMockTestServiceWithIndexedMockWhenThereAreMultipleDependenciesOfSameInterface_FirstPosition()
		{
			var mockTestInterfaceObject = MockRepository.GenerateMock<ITestInterface>();

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
			var mockTestInterfaceObject = MockRepository.GenerateMock<ITestInterface>();

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
			var mockTestInterfaceObject = MockRepository.GenerateMock<ITestInterface>();

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


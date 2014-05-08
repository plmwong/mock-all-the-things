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
				Create.A<TestServiceWithMixedDependencies>()
					.MockAllTheThings();

			Assert.IsNotNull(mockedTestService);
			Assert.IsInstanceOf<TestServiceWithMixedDependencies>(mockedTestService);
		}

		[Test]
		public void CanCreateAMockTestServiceUsingAPresuppliedMock()
		{
			var mockTestInterface = new Mock<ITestInterface>();
			var mockTestInterfaceObject = mockTestInterface.Object;

            var mockedTestService =
                Create.A<TestServiceWithMixedDependencies>()
                    .For<ITestInterface>().Use(mockTestInterfaceObject)
                    .MockAllTheOtherThings();

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
                Create.A<TestServiceWithMixedDependencies>()
                    .For<ITestInterface>().Use(mockTestInterfaceObject)
                    .For<TestAbstractClass>().Use(new Mock<TestAbstractClass>().Object)
                    .MockAllTheOtherThings();

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
				Create.A<TestServiceWithMixedDependencies>()
                    .For<ITestInterface>().At(0).Use(mockTestInterfaceObject)
					.For<TestAbstractClass>().Use(new Mock<TestAbstractClass>().Object)
                    .MockAllTheOtherThings();

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
				Create.A<TestServiceWithMultipleIdenticalDependencies>()
                    .For<ITestInterface>().At(0).Use(mockTestInterfaceObject)
					.MockAllTheThings();

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
				Create.A<TestServiceWithMultipleIdenticalDependencies>()
                    .For<ITestInterface>().At(2).Use(mockTestInterfaceObject)
					.MockAllTheThings();

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
				Create.A<TestServiceWithMultipleIdenticalDependencies>()
					.For<ITestInterface>().Use(mockTestInterfaceObject)
                    .MockAllTheOtherThings();

			Assert.IsNotNull(mockedTestService);
			Assert.IsInstanceOf<TestServiceWithMultipleIdenticalDependencies>(mockedTestService);

			Assert.AreSame(mockedTestService.TestInterface1, mockTestInterfaceObject);
			Assert.AreSame(mockedTestService.TestInterface2, mockTestInterfaceObject);
			Assert.AreSame(mockedTestService.TestInterface3, mockTestInterfaceObject);
			Assert.AreSame(mockedTestService.TestInterface2, mockedTestService.TestInterface3);
		}
	}
}


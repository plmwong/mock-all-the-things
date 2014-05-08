using NUnit.Framework;
using MockAllTheThings.Core;
using MockAllTheThings.Testing;
using FakeItEasy;

namespace MockAllTheThings.FakeItEasy.Tests
{
	[TestFixture]
	public class FakeItEasyMockProviderTests
	{
		[TestFixtureSetUp]
		public void SetUp() {
			Create.UsingProvider(new FakeItEasyMockProvider());
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
            var mockTestInterface = A.Fake<ITestInterface>();

            var mockedTestService =
                Create.A<TestServiceWithMixedDependencies>()
                    .For<ITestInterface>().Use(mockTestInterface)
                    .MockAllTheOtherThings();

            Assert.IsNotNull(mockedTestService);
            Assert.IsInstanceOf<TestServiceWithMixedDependencies>(mockedTestService);

            Assert.AreSame(mockedTestService.TestInterface, mockTestInterface);
        }

        [Test]
        public void CanCreateAMockTestServiceUsingMultiplePresuppliedMocks()
        {
            var mockTestInterface = A.Fake<ITestInterface>();

            var mockedTestService =
                Create.A<TestServiceWithMixedDependencies>()
                    .For<ITestInterface>().Use(mockTestInterface)
                    .For<TestAbstractClass>().Use(A.Fake<TestAbstractClass>())
                    .MockAllTheOtherThings();

            Assert.IsNotNull(mockedTestService);
            Assert.IsInstanceOf<TestServiceWithMixedDependencies>(mockedTestService);

            Assert.AreSame(mockedTestService.TestInterface, mockTestInterface);
        }

        [Test]
        public void CanCreateAMockTestServiceUsingAnIndexedMock()
        {
            var mockTestInterface = A.Fake<ITestInterface>();

            var mockedTestService =
                Create
                    .A<TestServiceWithMixedDependencies>()
                    .For<ITestInterface>().At(0).Use(mockTestInterface)
                    .For<TestAbstractClass>().Use(A.Fake<TestAbstractClass>())
                    .MockAllTheOtherThings();

            Assert.IsNotNull(mockedTestService);
            Assert.IsInstanceOf<TestServiceWithMixedDependencies>(mockedTestService);

            Assert.AreSame(mockedTestService.TestInterface, mockTestInterface);
        }

        [Test]
        public void CanCreateAMockTestServiceWithIndexedMockWhenThereAreMultipleDependenciesOfSameInterface_FirstPosition()
        {
            var mockTestInterface = A.Fake<ITestInterface>();

            var mockedTestService =
                Create.A<TestServiceWithMultipleIdenticalDependencies>()
                    .For<ITestInterface>().At(0).Use(mockTestInterface)
                    .MockAllTheThings();

            Assert.IsNotNull(mockedTestService);
            Assert.IsInstanceOf<TestServiceWithMultipleIdenticalDependencies>(mockedTestService);

            Assert.AreSame(mockedTestService.TestInterface1, mockTestInterface);
            Assert.AreNotSame(mockedTestService.TestInterface2, mockTestInterface);
            Assert.AreNotSame(mockedTestService.TestInterface3, mockTestInterface);
            Assert.AreNotSame(mockedTestService.TestInterface2, mockedTestService.TestInterface3);
        }

        [Test]
        public void CanMockTestServiceWithIndexedMockWhenThereAreMultipleDependenciesOfSameInterface_LastPosition()
        {
            var mockTestInterface = A.Fake<ITestInterface>();

            var mockedTestService =
                Create.A<TestServiceWithMultipleIdenticalDependencies>()
                    .For<ITestInterface>().At(2).Use(mockTestInterface)
                    .MockAllTheThings();

            Assert.IsNotNull(mockedTestService);
            Assert.IsInstanceOf<TestServiceWithMultipleIdenticalDependencies>(mockedTestService);

            Assert.AreSame(mockedTestService.TestInterface3, mockTestInterface);
            Assert.AreNotSame(mockedTestService.TestInterface1, mockTestInterface);
            Assert.AreNotSame(mockedTestService.TestInterface2, mockTestInterface);
            Assert.AreNotSame(mockedTestService.TestInterface1, mockedTestService.TestInterface2);
        }

        [Test]
        public void CanMockTestServiceWithTypeMocksWhenThereAreMultipleDependenciesOfSameInterface()
        {
            var mockTestInterface = A.Fake<ITestInterface>();

            var mockedTestService =
                Create
                    .A<TestServiceWithMultipleIdenticalDependencies>()
                    .For<ITestInterface>().Use(mockTestInterface)
                    .MockAllTheOtherThings();

            Assert.IsNotNull(mockedTestService);
            Assert.IsInstanceOf<TestServiceWithMultipleIdenticalDependencies>(mockedTestService);

            Assert.AreSame(mockedTestService.TestInterface1, mockTestInterface);
            Assert.AreSame(mockedTestService.TestInterface2, mockTestInterface);
            Assert.AreSame(mockedTestService.TestInterface3, mockTestInterface);
            Assert.AreSame(mockedTestService.TestInterface2, mockedTestService.TestInterface3);
        }
	}
}


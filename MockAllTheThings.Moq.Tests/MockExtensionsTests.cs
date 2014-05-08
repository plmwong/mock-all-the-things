﻿using MockAllTheThings.Core;
using MockAllTheThings.Testing;
using Moq;
using NUnit.Framework;

namespace MockAllTheThings.Moq.Tests
{
    [TestFixture]
    public class MockExtensionsTests
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            Create.UsingProvider(new MoqMockProvider());
        }

        [Test]
        public void WhenGettingMockFromPresuppliedMockObjectItReturnsTheSuppliedMock()
        {
            var mockTestInterface = new Mock<ITestInterface>();
            var mockTestInterfaceObject = mockTestInterface.Object;

            var mockedTestService =
                Create.A<TestServiceWithMixedDependencies>()
                    .For<ITestInterface>().Use(mockTestInterfaceObject)
                    .MockAllTheOtherThings();

            Assert.AreSame(mockedTestService.TestInterface.GetMock(), mockTestInterface);
        }

        [Test]
        public void CanVerifyExpectationsOnAutoCreatedMocks()
        {
            var mockedTestService =
                Create.A<TestServiceWithMixedDependencies>()
                    .MockAllTheThings();

            mockedTestService.TestInterface.Test();
            mockedTestService.TestInterface.GetMock().Verify(m => m.Test(), Times.Once);
        }
    }
}
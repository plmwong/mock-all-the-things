
namespace MockAllTheThings.Moq.Tests
{
	public class TestServiceWithMixedDependencies
	{
		public ITestInterface TestInterface { get; private set; }
		public TestAbstractClass TestAbstractClass { get; private set; }
		public TestConcreteClass TestConcreteClass { get; private set; }

		public TestServiceWithMixedDependencies(ITestInterface testInterface, TestAbstractClass testAbstractClass, TestConcreteClass testConcreteClass)
		{
			TestInterface = testInterface;
			TestAbstractClass = testAbstractClass;
			TestConcreteClass = testConcreteClass;
		}
	}
}


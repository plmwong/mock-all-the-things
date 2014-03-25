
namespace MockAllTheThings.RhinoMocks.Tests
{
	public class TestServiceWithMultipleIdenticalDependencies
	{
		public ITestInterface TestInterface1 { get; private set; }
		public ITestInterface TestInterface2 { get; private set; }
		public ITestInterface TestInterface3 { get; private set; }

		public TestServiceWithMultipleIdenticalDependencies(ITestInterface testInterface1, ITestInterface testInterface2, ITestInterface testInterface3) {
			TestInterface1 = testInterface1;
			TestInterface2 = testInterface2;
			TestInterface3 = testInterface3;
		}
	}
}


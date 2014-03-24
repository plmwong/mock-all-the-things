using System;

namespace MockAllTheThings.Tests
{
	public class TestServiceWithMixedDependencies
	{
		public TestServiceWithMixedDependencies(ITestInterface testInterface, TestAbstractClass testAbstractClass, TestConcreteClass testConcreteClass)
		{
		}
	}
}


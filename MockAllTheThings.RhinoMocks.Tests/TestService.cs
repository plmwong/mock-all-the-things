﻿
namespace MockAllTheThings.RhinoMocks.Tests
{
	public class TestService
	{
		public ITestInterface TestInterface { get; private set; }

		public TestService(ITestInterface testInterface)
		{
			TestInterface = testInterface;
		}
	}
}


﻿
namespace MockAllTheThings.Testing
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


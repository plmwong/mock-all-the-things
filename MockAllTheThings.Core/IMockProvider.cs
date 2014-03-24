using System;

namespace MockAllTheThings.Core
{
	public interface IMockProvider
	{
		object CreateMock(Type type);
	}
}


using System;

namespace MockAllTheThings
{
	public interface IMockProvider
	{
		object CreateMock(Type type);
	}
}


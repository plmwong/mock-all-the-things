using System;
using MockAllTheThings.Core;

namespace MockAllTheThings.RhinoMocks
{
	public class RhinoMocksMockProvider : IMockProvider
	{
		#region IMockProvider implementation

		public object CreateMock(Type type)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}


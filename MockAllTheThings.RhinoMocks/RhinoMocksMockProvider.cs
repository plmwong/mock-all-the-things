using System;
using MockAllTheThings.Core;
using Rhino.Mocks;
using System.Reflection;
using System.Linq;

namespace MockAllTheThings.RhinoMocks
{
	public class RhinoMocksMockProvider : IMockProvider
	{
		#region IMockProvider implementation

		public object CreateMock(Type type)
		{
			var mockerType = typeof(MockRepository);
			var mockMethods = mockerType.GetMethods();
			var mockMethod = mockMethods.First(m => m.Name == "GenerateMock" && m.GetParameters().Length == 1);
			var mockGenericMethod = mockMethod.MakeGenericMethod(type);

			var mockedObject = mockGenericMethod.Invoke(null, new [] { new object[0] });

			return mockedObject;
		}

		#endregion
	}
}


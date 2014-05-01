using System;
using MockAllTheThings.Core;
using FakeItEasy;
using System.Linq;

namespace MockAllTheThings.FakeItEasy
{
	public class FakeItEasyMockProvider : IMockProvider
	{
		#region IMockProvider implementation

		public object CreateMock(Type type)
		{
			var mockerType = typeof(A);
			var mockMethods = mockerType.GetMethods();
			var mockMethod = mockMethods.First(m => m.Name == "Fake" && m.GetParameters().Length == 0);
			var mockGenericMethod = mockMethod.MakeGenericMethod(type);

			var mockedObject = mockGenericMethod.Invoke(null, new object[0]);

			return mockedObject;
		}

		#endregion
	}
}


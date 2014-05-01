using System;
using Moq;
using MockAllTheThings.Core;

namespace MockAllTheThings.Moq
{
	public class MoqMockProvider : IMockProvider
	{
		#region IMockProvider implementation	

		public object CreateMock(Type type)
		{
			var mockerType = typeof(Mock<>);
			var mockerGenericType = mockerType.MakeGenericType(type);
			var mocker = Activator.CreateInstance(mockerGenericType);

			var objectPropertyInfo = mockerGenericType.GetProperty("Object");
			var mockedObject = objectPropertyInfo.GetValue(mocker, null);

			return mockedObject;
		}

		#endregion
	}
}


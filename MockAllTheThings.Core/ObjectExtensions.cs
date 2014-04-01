using System.Linq.Expressions;
using System;


namespace MockAllTheThings.Core
{
	public static class ObjectExtensions
	{
		public static bool IsNull(this object obj) {
			return obj == null;
		}

		public static bool IsNotNull(this object obj) {
			return obj != null;
		}
	}

	public static class Must
	{
		public static void NotBeNull(Expression<Func<object>> objectExpression)
		{
			var objectValue = objectExpression.Compile().Invoke();

			if (objectValue.IsNull()) {
				var memberExpression = objectExpression.Body as MemberExpression;
				var objectName = memberExpression.Member.Name;

				throw new ArgumentNullException(objectName);
			}
		}
	}
}


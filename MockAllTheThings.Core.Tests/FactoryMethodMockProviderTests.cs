using NUnit.Framework;
using System;

namespace MockAllTheThings.Core.Tests
{
	[TestFixture]
	public class FactoryMethodMockProviderTests
	{
		[Test]
		public void CannotBeConstructedWithANullFactoryMethod() {
			Assert.Throws<ArgumentNullException>(() => new FactoryMethodMockProvider(null));
		}
	}
}


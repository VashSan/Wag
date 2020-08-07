using Moq;
using NUnit.Framework;
using Wag.Domain.Action;
using Wag.Domain.Search;
using Wag.Interface.Action;

namespace Wag.Test.Domain.Search
{
	public class StartActionSourceTest
	{
		[Test]
		public void GetIndexableItems_WithoutProviders_ReturnsEmpty()
		{
			// Arrange
			var source = new StartActionSource();

			// Act
			var result = source.GetIndexableItems();

			// Assert
			Assert.That( result, Is.Empty );
		}

		[Test]
		public void GetIndexableItems_WithProvider_ReturnsResults()
		{
			// Arrange
			var source = new StartActionSource();

			var action = Mock.Of<IStartMenuAction>();

			var actionProvider = new Mock<IStartActionProvider>();
			actionProvider.Setup( p => p.GetActions() ).Returns( new[] { action } );

			source.Add( actionProvider.Object );

			// Act
			var result = source.GetIndexableItems();

			// Assert
			Assert.That( result, Is.Not.Empty );
		}
	}
}

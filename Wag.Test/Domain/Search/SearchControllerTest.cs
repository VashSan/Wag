using System.Collections.ObjectModel;
using System.ComponentModel;
using Moq;
using NUnit.Framework;
using Wag.Domain.Search;
using Wag.Interface;

namespace Wag.Test.Domain.Search
{
	class SearchControllerTest
	{
		[Test]
		public void Query_Change_UpdatesResults()
		{
			// Arrange
			var startMenuMock = new Mock<IStartMenuViewModel>();

			var actionList = new ObservableCollection<IStartMenuAction>();
			startMenuMock.Setup( m => m.Actions ).Returns( actionList );

			var searchController = new SearchController();
			searchController.Register( startMenuMock.Object, nameof( startMenuMock.Object.Query ) );

			// Act
			startMenuMock.Raise( m => m.PropertyChanged += null, new PropertyChangedEventArgs( "Query" ) );

			// Assert
			Assert.That( actionList.Count, Is.GreaterThan( 0 ) );
		}
	}
}

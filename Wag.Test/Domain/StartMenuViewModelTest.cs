using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using Wag.Domain;
using Wag.Interface;
using Wag.Interface.Search;

namespace Wag.Test.Domain
{
	public class StartMenuViewModelTest
	{
		[Test]
		public void Initialization_Registers_WithSearchController()
		{
			// Arrange
			var searchController = new Mock<ISearchController>();

			// Act
			var vm = new StartMenuViewModel( searchController.Object );

			// Assert
			searchController.Verify( m => m.Register( vm, "Query" ), Times.Once, "The start menu view model must register with the search." );
		}

	}
}

using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using Wag.Domain;

namespace Wag.Test.Domain
{
	public class StartMenuViewModelTest
	{
		[Test]
		public void Query_BeingEntered_TriggersSearch()
		{
			// Arrange
			var vm = new StartMenuViewModel();

			// Act
			vm.Query = "Test";

			// Assert
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Wag.Domain;

namespace Wag.Interface
{
	public interface ISearchController
	{
		void Register( IStartMenuViewModel sourceObject, string propertyName );
	}
}

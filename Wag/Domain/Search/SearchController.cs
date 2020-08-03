using Wag.Interface;
using Wag.Interface.Search;

namespace Wag.Domain.Search
{
	public class SearchController : ISearchController
	{
		private IStartMenuViewModel SourceViewModel { get; set; }

		public void Register( IStartMenuViewModel source, string propertyName )
		{
			SourceViewModel = source;
			source.PropertyChanged += (s, e) =>
			{
				if ( e.PropertyName == propertyName )
				{
					QueryIndex();
					UpdateInquirer();
				}
			};
		}

		private void QueryIndex()
		{
			// TODO perform a search and update a result list
		}


		private void UpdateInquirer()
		{
			// TODO perform a search and update more efficient (without complete clear?)
			SourceViewModel.Actions.Clear();
			SourceViewModel.Actions.Add( null );
		}
	}
}

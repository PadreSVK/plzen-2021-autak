using System.Collections.Generic;

namespace Autak.API.FakeDB.Filters
{
	public class CarAdministratorFilter
	{
		public int Page { get; set; }
		public int ItemsPerPage { get; set; }
		public IEnumerable<SortFilter> SortFilters { get; set; }
	}
}
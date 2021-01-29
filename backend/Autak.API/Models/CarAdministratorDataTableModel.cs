using System.Collections.Generic;

namespace Autak.API.Models
{
	public class CarAdministratorDataTableModel
	{
		public IEnumerable<CarAdministrator> Items { get; set; }
		public int TotalItems { get; set; }
	}
}
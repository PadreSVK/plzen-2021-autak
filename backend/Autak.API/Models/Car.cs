using System;

namespace Autak.API.Models
{
	public class Car
	{
		public string Name { get; set; }
		public string Spz { get; set; }
		public string Type { get; set; }
		public DateTime DateTime { get; set; }
		public CarAdministrator Administrator { get; set; }
	}
}
using System.Collections;
using System.Collections.Generic;

namespace Autak.API.Models
{
	public class CarDataTableModel
	{
		public IEnumerable<Car> Items { get; set; }
		public int TotalItems { get; set; }
		public IEnumerable<CarDataTableHeader> Headers { get; set; }
		public IEnumerable<FormElementMetadata> ElementsMetadata { get; set; }
	}

	public class FormElementMetadata
	{
		public string Key { get; set; } 
		public string Type { get; set; } // "text", "number", "date"
		public string ValidationRules { get; set; }
		public string Label { get; set; }
	}
}
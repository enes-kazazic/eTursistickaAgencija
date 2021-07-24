using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TuristickaAgencija.ViewModels.Destinacija
{
	public class DestinacijaNgVM
	{
		public int id { get; set; }
		public string grad { get; set; }
		public string drzava { get; set; }
		public int? smjestajID { get; set; }
		public List<SelectListItem> SmjestajStavke { get; set; }
	}
}

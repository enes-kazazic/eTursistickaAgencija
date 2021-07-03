using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TuristickaAgencija.ViewModels.Destinacija
{
	public class DestinacijaVM
	{
		public int Id { get; set; }
		public string Grad { get; set; }
		public string Drzava { get; set; }
		public int? SmjestajID { get; set; }
		public List<SelectListItem> SmjestajStavke { get; set; }
	}
}

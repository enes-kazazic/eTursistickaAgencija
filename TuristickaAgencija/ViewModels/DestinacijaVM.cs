using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TuristickaAgencija.ViewModels
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

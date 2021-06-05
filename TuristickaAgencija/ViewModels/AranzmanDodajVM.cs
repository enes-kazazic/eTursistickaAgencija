using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TuristickaAgencija.ViewModels
{
	public class AranzmanDodajVM
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
		public DateTime DatumPocetka { get; set; }
		public DateTime DatumZavrsetka { get; set; }
		public int? VodicId { get; set; }
		public List<SelectListItem> Vodici { get; set; }
	}
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TuristickaAgencija.ViewModels.Aranzman
{
	public class AranzmanDodajVM
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
		public DateTime DatumPocetka { get; set; }
		public DateTime DatumZavrsetka { get; set; }
		public int? VodicId { get; set; }
		public List<SelectListItem> Vodici { get; set; }
		public int? VozacId { get; set; }
		public List<SelectListItem> Vozaci { get; set; }
	}
}

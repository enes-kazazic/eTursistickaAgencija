using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TuristickaAgencija.ViewModels
{
	public class DestinacijaAranzmanDodajVM
	{
		public int DestinacijaAranzmanId { get; set; }
		public int AranzmanId { get; set; }
		public string Aranzman { get; set; }
		public int DestinacijaId { get; set; }
		public List<SelectListItem> Destinacije { get; set; }
		public DateTime DatumPocetka { get; set; }
		public DateTime DatumKraja{ get; set; }
	}
}

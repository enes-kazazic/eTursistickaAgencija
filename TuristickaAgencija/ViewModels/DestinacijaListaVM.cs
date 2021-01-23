using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuristickaAgencija.ViewModels
{
	public class DestinacijaListaVM
	{
		public int Id { get; set; }
		public string Grad { get; set; }
		public string Drzava { get; set; }
		public int? SmjestajId { get; set; }
		public string Smjestaj { get; set; }
	}
}

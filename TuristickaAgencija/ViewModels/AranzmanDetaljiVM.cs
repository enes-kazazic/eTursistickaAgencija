using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuristickaAgencija.ViewModels
{
	public class AranzmanDetaljiVM
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
		public string DatumPocetka { get; set; }
		public string DatumZavrsetka { get; set; }
		public int? VodicId { get; set; }
		public string Vodic { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuristickaAgencija.ViewModels
{
	public class AranzmanListaVm
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
		public string DatumPocetka { get; set; }
		public string DatumKraja { get; set; }
	}
}

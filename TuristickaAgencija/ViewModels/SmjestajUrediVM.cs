using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuristickaAgencija.ViewModels
{
	public class SmjestajUrediVM
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
		public string BrojUgovora { get; set; }
		public int ProvizijaPoOsobi { get; set; }
	}
}

using System.Collections.Generic;

namespace TuristickaAgencija.ViewModels.Destinacija
{
	public class DestinacijaNgListaVM
	{
		public class Row
		{
			public int Id { get; set; }
			public string Grad { get; set; }
			public string Drzava { get; set; }
			public int? SmjestajId { get; set; }
			public string Smjestaj { get; set; }
		}

		public List<Row> DestinacijaLista { get; set; }


	}
}

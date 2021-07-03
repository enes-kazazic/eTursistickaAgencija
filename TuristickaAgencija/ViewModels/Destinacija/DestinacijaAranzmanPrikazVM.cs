using System.Collections.Generic;

namespace TuristickaAgencija.ViewModels.Destinacija
{
	public class DestinacijaAranzmanPrikazVM
	{
		public List<Row> Rows { get; set; }
		public int Id { get; set; }
		public class Row
		{
			public int Id { get; set; }
			public string Naziv { get; set; }
			public string Smjestaj { get; set; }
			public string DatumPocetka { get; set; }
			public string DatumKraja { get; set; }
		}
	}
}

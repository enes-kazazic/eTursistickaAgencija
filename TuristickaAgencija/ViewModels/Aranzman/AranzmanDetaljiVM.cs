namespace TuristickaAgencija.ViewModels.Aranzman
{
	public class AranzmanDetaljiVM
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
		public string DatumPocetka { get; set; }
		public string DatumZavrsetka { get; set; }
		public int? VodicId { get; set; }
		public string Vodic { get; set; }
		public int? VozacId{ get; set; }
		public string Vozac { get; set; }
	}
}

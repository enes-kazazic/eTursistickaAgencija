namespace TuristickaAgencija.ViewModels.Destinacija
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

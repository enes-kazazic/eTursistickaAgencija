using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Data.Models
{
	public class Aranzman 
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
		public DateTime DatumPocetka { get; set; }
		public DateTime DatumKraja { get; set; }
		public int? VodicId { get; set; }
		public Vodic Vodic { get; set; }
		public int? VozacId { get; set; }
		public Vozac Vozac { get; set; }
	}
}

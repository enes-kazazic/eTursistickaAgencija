using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Data.Models
{
	public class DestinacijaAranzman
	{
		public int Id { get; set; }
		public int AranzmanId { get; set; }
		public Aranzman Aranzman{ get; set; }
		public int DestinacijaId { get; set; }
		public Destinacija Destinacija { get; set; }
		public DateTime DatumPocetka { get; set; }
		public DateTime DatumKraja { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Data.Models
{
	public class Destinacija
	{
		public int Id { get; set; }
		public string Grad { get; set; }
		public string Drzava { get; set; }
		public int? SmjestajId { get; set; }
		public virtual Smjestaj Smjestaj { get; set; }
	}
}

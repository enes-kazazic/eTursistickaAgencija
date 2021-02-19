using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Data.Models
{
    public class Placanje
    {
        public int Id { get; set; }
        public double Iznos { get; set; }
        public DateTime Datum { get; set; }
        public string NacinPlacanja { get; set; }
        public int? RezervacijaId { get; set; }
        public virtual Rezervacija Rezervacija { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Data.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public double Cijena { get; set; }
        public string BrojRacuna { get; set; }
    }
}

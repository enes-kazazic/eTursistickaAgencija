using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuristickaAgencija.ViewModels
{
    public class RezervacijaListaVM
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public double Cijena { get; set; }
        public string BrojRacuna { get; set; }
    }
}

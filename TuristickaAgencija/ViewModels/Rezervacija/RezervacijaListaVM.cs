using System;

namespace TuristickaAgencija.ViewModels.Rezervacija
{
    public class RezervacijaListaVM
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public double Cijena { get; set; }
        public string BrojRacuna { get; set; }
    }
}

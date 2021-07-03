using System;

namespace TuristickaAgencija.ViewModels.Rezervacija
{
    public class RezervacijaVM
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public double Cijena { get; set; }
        public string BrojRacuna { get; set; }
    }
}

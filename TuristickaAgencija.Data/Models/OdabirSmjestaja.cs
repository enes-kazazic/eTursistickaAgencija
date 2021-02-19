using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Data.Models
{
    public class OdabirSmjestaja
    {
        public int Id { get; set; }
        public string VrstaSobe { get; set; }
        public int BrojSobe { get; set; }
        public int? SmjestajId { get; set; }
        public virtual Smjestaj Smjestaj { get; set; }
        public int? RezervacijaId { get; set; }
        public virtual Rezervacija Rezervacija { get; set; }
        
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Data.Models;
using TuristickaAgencija.ViewModels;

namespace TuristickaAgencija
{
	public class Context:DbContext
	{
		public DbSet<Smjestaj> Smjestaji { get; set; }
		public DbSet<Destinacija> Destinacije { get; set; }
        public DbSet<Placanje> Placanje { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<OdabirSmjestaja> OdabirSmjestaja { get; set; }
        public DbSet<Aranzman> Aranzman { get; set; }
        public DbSet<DestinacijaAranzman> DestinacijaAranzman { get; set; }
        public DbSet<Vodic> Vodic{ get; set; }
        public DbSet<Vozac> Vozac{ get; set; }


        public Context(DbContextOptions<Context> options) : base(options)
		{
		}
	}
}

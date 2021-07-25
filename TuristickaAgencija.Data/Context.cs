using Microsoft.EntityFrameworkCore;
using TuristickaAgencija.Data.Models;

namespace TuristickaAgencija.Data
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
        public DbSet<ExceptionLogger> ExceptionLogger { get; set; }


        public Context(DbContextOptions<Context> options) : base(options)
		{
		}
	}
}

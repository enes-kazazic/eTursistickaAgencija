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

		public Context(DbContextOptions<Context> options) : base(options)
		{
		}
	}
}

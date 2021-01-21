using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.EntityModels;

namespace TuristickaAgencija
{
	public class Context:DbContext
	{
		public DbSet<Smjestaj> Smjestaji { get; set; }

		public Context(DbContextOptions<Context> options) : base(options)
		{
		}
	}
}

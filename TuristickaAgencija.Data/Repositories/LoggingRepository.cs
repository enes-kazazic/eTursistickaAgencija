using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencija.Data.Models;

namespace TuristickaAgencija.Data.Repositories
{
	public class LoggingRepository:ILoggingRepository
	{
		private readonly Context db;

		public LoggingRepository(Context db)
		{
			this.db = db;
		}
		
		public void Add(ExceptionLogger log)
		{
			db.ExceptionLogger.Add(log);
			Save();
		}

		public void Save()
		{
			db.SaveChanges();
		}
	}
}

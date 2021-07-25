using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencija.Data.Models;

namespace TuristickaAgencija.Data.Repositories
{
	public interface ILoggingRepository
	{
		void Add(ExceptionLogger log);
		void Save();
	}
}

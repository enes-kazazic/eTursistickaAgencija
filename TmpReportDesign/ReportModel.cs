using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TmpReportDesign
{
	public class ReportModel
	{
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Adresa { get; set; }

		public static List<ReportModel> Get()
		{
			return new List<ReportModel> { };
		}
	}
}
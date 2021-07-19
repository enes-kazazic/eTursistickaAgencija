using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TmpReportDesign
{
	public class AranzmanReportModel
	{
		public string NazivDestinacije { get; set; }
		public string NazivSmjestaja { get; set; }
		public string DatumPocetka { get; set; }
		public string DatumZavrsetka { get; set; }
		
		public static List<AranzmanReportModel> Get()
		{
			return new List<AranzmanReportModel> { };
		}
	}
}
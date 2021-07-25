using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Reporting;
using Microsoft.EntityFrameworkCore;
using TmpReportDesign;
using TuristickaAgencija.Data;

namespace TuristickaAgencija.Controllers
{
	public class ReportController : Controller
	{
		private Context db;

		public ReportController(Context db)
		{
			this.db = db;
		}

		public static List<AranzmanReportModel> getDestinacije(Context db, int aranzmanId)
		{
			List<AranzmanReportModel> podaci = db.DestinacijaAranzman
				.Include(i=>i.Destinacija)
				.Include(i=>i.Destinacija.Smjestaj)
				.Where(x => x.AranzmanId == aranzmanId)
				.Select(s => new AranzmanReportModel
				{
					NazivDestinacije = s.Destinacija.Grad,
					NazivSmjestaja = s.Destinacija.Smjestaj.Naziv,
					DatumPocetka = s.DatumPocetka.ToString("dd.MM.yyyy"),
					DatumZavrsetka = s.DatumKraja.ToString("dd.MM.yyyy")
				}).ToList();
		

			return podaci;
		}

		public IActionResult Index(int aranzmanId)
		{
			LocalReport _localReport = new LocalReport("Reports/AranzmanReport.rdlc");
			List<AranzmanReportModel> podaci = getDestinacije(db,aranzmanId);
			_localReport.AddDataSource("DataSet1", podaci);

			var aranzman = db.Aranzman.Find(aranzmanId);
			var vodic = db.Vodic.FirstOrDefault(x => x.Id == aranzman.VodicId);
			var vozac = db.Vozac.FirstOrDefault(x => x.Id == aranzman.VozacId);
			string VozacImePrezime = vozac?.Ime + " " + vozac?.Prezime;
			var VodicImePrezime = vodic?.Ime + " " + vodic?.Prezime;


			Dictionary<string, string> parameters = new Dictionary<string, string>();
			parameters.Add("DatumPocetka", aranzman.DatumPocetka.ToString("dd.MM.yyyy"));
			parameters.Add("DatumKraja", aranzman.DatumKraja.ToString("dd.MM.yyyy"));
			parameters.Add("NazivAranzmana", aranzman.Naziv);
			parameters.Add("VozacImePrezime", VozacImePrezime);
			parameters.Add("VozacAdresa", vozac?.Adresa);
			parameters.Add("VozacBrTelefona", vozac?.BrojTelefona);
			parameters.Add("VodicImePrezime", VodicImePrezime);
			parameters.Add("VodicAdresa", vodic?.Adresa);
			parameters.Add("VodicBrTelefona", vodic?.BrojTelefona);

			//ReportResult result = _localReport.Execute(RenderType.ExcelOpenXml, parameters: parameters);
			//return File(result.MainStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

			ReportResult result = _localReport.Execute(RenderType.Pdf, parameters: parameters);
			return File(result.MainStream, "application/pdf");

		}
	}
}

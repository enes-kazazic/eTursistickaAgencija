using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.ViewModels.Uposlenik;

namespace TuristickaAgencija.Controllers
{
	public class UposlenikController : Controller
	{
		private Context db;
		//private Uposlenik uposlenik;

		public UposlenikController(Context db /*, Uposlenik uposlenik*/)
		{
			this.db = db;
			//this.uposlenik = uposlenik;
		}
		public IActionResult ListaPrethodnih()
		{
			var model = db.Aranzman
				//.Where(x=>x.VozacId == uposlenik.id || x=>x.VodicId == uposlenik.Id)
				.Where(x => x.DatumKraja < DateTime.Now)
				.Select(i => new UposlenikAranzmanListaVM()
				{
					Naziv = i.Naziv,
					DatumPocetka = i.DatumPocetka.ToString("dd.MM.yyyy"),
					DatumKraja = i.DatumKraja.ToString("dd.MM.yyyy")
				}).ToList();

			return View(model);
		}
		public IActionResult ListaNadolazecih()
		{
			var model = db.Aranzman
				//.Where(x=>x.VozacId == uposlenik.id || x=>x.VodicId == uposlenik.Id)
				.Where(x => x.DatumKraja > DateTime.Now)
				.Select(i => new UposlenikAranzmanListaVM()
				{
					Naziv = i.Naziv,
					DatumPocetka = i.DatumPocetka.ToString("dd.MM.yyyy"),
					DatumKraja = i.DatumKraja.ToString("dd.MM.yyyy")
				}).ToList();

			return View(model);
		}
	}
}

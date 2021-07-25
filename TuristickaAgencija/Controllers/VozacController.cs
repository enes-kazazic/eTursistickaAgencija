using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using TuristickaAgencija.Data;
using TuristickaAgencija.Data.Models;
using TuristickaAgencija.ViewModels;
using TuristickaAgencija.ViewModels.Vozac;

namespace TuristickaAgencija.Controllers
{
	public class VozacController : Controller
	{
		private Context db;

		public VozacController(Context db)
		{
			this.db = db;
		}
		public IActionResult Lista()
		{
			var model = db.Vozac.Select(x => new VozacListaVm()
			{
				Id = x.Id,
				Adresa = x.Adresa,
				BrojTelefona = x.BrojTelefona,
				ImePrezime = x.Ime + " " + x.Prezime,
			}).ToList();

			return View(model);
		}

		[ActionName("dodaj")]
		public IActionResult Dodaj()
		{

			return View();
		}

		[HttpPost]
		[ActionName("dodaj")]
		public IActionResult Dodaj(VozacDodajUrediVM x)
		{
			Vozac noviVozac = new Vozac()
			{
				Ime = x.Ime,
				Prezime = x.Prezime,
				Adresa = x.Adresa,
				BrojTelefona = x.BrojTelefona
			};
			db.Vozac.Add(noviVozac);
			db.SaveChanges();

			TempData["successMessage"] = "Vozač dodan.";

			return RedirectToAction("Lista");
		}

		public IActionResult Obrisi(int vozacId)
		{
			Vozac vozac= db.Vozac.Find(vozacId);

			db.Vozac.Remove(vozac);
			db.SaveChanges();

			TempData["successDelete"] = "Uspjesno obrisano.";

			return RedirectToAction("Lista");
		}

		public IActionResult Uredi(int vozacId)
		{
			Vozac vozac = db.Vozac.Find(vozacId);

			VozacDodajUrediVM m = new VozacDodajUrediVM()
			{
				Id = vozacId,
				Adresa = vozac.Adresa,
				BrojTelefona = vozac.BrojTelefona,
				Ime = vozac.Ime,
				Prezime = vozac.Prezime
			};

			return View(m);
		}

		[HttpPost]
		public IActionResult Uredi(VozacDodajUrediVM m)
		{
			Vozac vozac = db.Vozac.Find(m.Id);
			vozac.Adresa = m.Adresa;
			vozac.BrojTelefona = m.BrojTelefona;
			vozac.Ime = m.Ime;
			vozac.Prezime = m.Prezime;

			db.SaveChanges();

			TempData["successEdit"] = "Promjene sačuvane.";

			return RedirectToAction("Lista");
		}

	}
}

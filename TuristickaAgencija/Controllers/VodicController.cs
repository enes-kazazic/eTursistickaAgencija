using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Data;
using TuristickaAgencija.Data.Models;
using TuristickaAgencija.ViewModels;
using TuristickaAgencija.ViewModels.Vozac;

namespace TuristickaAgencija.Controllers
{
	public class VodicController : Controller
	{
		private Context db;

		public VodicController(Context db)
		{
			this.db = db;
		}
		public IActionResult Lista()
		{
			var model = db.Vodic.Select(x => new VozacListaVm()
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
			Vodic noviVodic = new Vodic()
			{
				Ime = x.Ime,
				Prezime = x.Prezime,
				Adresa = x.Adresa,
				BrojTelefona = x.BrojTelefona
			};
			db.Vodic.Add(noviVodic);
			db.SaveChanges();

			TempData["successMessage"] = "Vodič dodan.";

			return RedirectToAction("Lista");
		}

		public IActionResult Obrisi(int vodicId)
		{
			Vodic vodic = db.Vodic.Find(vodicId);

			db.Vodic.Remove(vodic);
			db.SaveChanges();

			TempData["successDelete"] = "Uspjesno obrisano.";

			return RedirectToAction("Lista");
		}

		public IActionResult Uredi(int vodicId)
		{
			Vodic vodic = db.Vodic.Find(vodicId);

			VozacDodajUrediVM m = new VozacDodajUrediVM()
			{
				Id = vodicId,
				Adresa = vodic.Adresa,
				BrojTelefona = vodic.BrojTelefona,
				Ime = vodic.Ime ,
				Prezime = vodic.Prezime
			};

			return View(m);
		}

		[HttpPost]
		public IActionResult Uredi(VozacDodajUrediVM m)
		{
			Vodic vodic= db.Vodic.Find(m.Id);
			vodic.Adresa = m.Adresa;
			vodic.BrojTelefona = m.BrojTelefona;
			vodic.Ime = m.Ime;
			vodic.Prezime = m.Prezime;

			db.SaveChanges();

			TempData["successEdit"] = "Promjene sačuvane.";

			return RedirectToAction("Lista");
		}
	}
}

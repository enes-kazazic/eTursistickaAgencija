using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using TuristickaAgencija.Data;
using TuristickaAgencija.Data.Models;
using TuristickaAgencija.ViewModels;
using TuristickaAgencija.ViewModels.Destinacija;

namespace TuristickaAgencija.Controllers
{
	public class DestinacijaController : Controller
	{
		private Context db;

		public DestinacijaController(Context context)
		{
			db = context;
		}


		public IActionResult Lista()
		{
			var model = db.Destinacije.Select(x => new DestinacijaListaVM
			{
				Id = x.Id,
				Drzava = x.Drzava,
				Grad = x.Grad,
				SmjestajId = x.SmjestajId,
				Smjestaj = x.Smjestaj.Naziv
			}).ToList();

			return View(model);
		}

		[ActionName("dodaj")]
		public IActionResult Dodaj()
		{
			List<SelectListItem> smjestaj = db.Smjestaji.
				Select(i => new SelectListItem
			{
				Text = i.Naziv,
				Value = i.Id.ToString()
			}).ToList();

			DestinacijaVM m = new DestinacijaVM();
			m.SmjestajStavke = smjestaj;

			return View(m);
		}

		[HttpPost]
		[ActionName("dodaj")]
		public IActionResult Dodaj(DestinacijaVM x)
		{
			Destinacija destinacija = new Destinacija
			{
				Drzava = x.Drzava,
				Grad = x.Grad,
				SmjestajId = x.SmjestajID
			};
			db.Destinacije.Add(destinacija);
			db.SaveChanges();

			TempData["successMessage"] = "Destinacija dodana.";

			return RedirectToAction("Lista");
		}

		public IActionResult Obrisi(int destinacijaID)
		{
			Destinacija destinacija= db.Destinacije.Find(destinacijaID);

			db.Destinacije.Remove(destinacija);
			db.SaveChanges();

			TempData["successDelete"] = "Uspjesno obrisano.";

			return RedirectToAction("Lista");
		}

		public IActionResult Uredi(int destinacijaID)
		{
			Destinacija destinacija = db.Destinacije.Find(destinacijaID);

			DestinacijaVM m = new DestinacijaVM()
			{
				Id = destinacija.Id,
				Grad = destinacija.Grad,
				Drzava = destinacija.Drzava,
				SmjestajID = destinacija.SmjestajId
			};

			m.SmjestajStavke = db.Smjestaji.Select(x => new SelectListItem
			{
				Text = x.Naziv,
				Value = x.Id.ToString()
			}).ToList();
			
			return View(m);
		}

		[HttpPost]
		public IActionResult Uredi(DestinacijaVM m)
		{
			Destinacija d = db.Destinacije.Find(m.Id);
			d.Drzava = m.Drzava;
			d.Grad = m.Grad;
			d.SmjestajId = m.SmjestajID;

			db.SaveChanges();

			TempData["successEdit"] = "Promjene sačuvane.";

			return RedirectToAction("Lista");
		}
	}
}

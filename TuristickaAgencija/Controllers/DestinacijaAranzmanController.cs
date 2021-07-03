using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuristickaAgencija.Data.Models;
using TuristickaAgencija.ViewModels;
using TuristickaAgencija.ViewModels.Destinacija;

namespace TuristickaAgencija.Controllers
{
	public class DestinacijaAranzmanController : Controller
	{
		private Context db;

		public DestinacijaAranzmanController(Context db)
		{
			this.db = db;
		}
		
		public IActionResult Prikaz(int id)
		{
			var model = new DestinacijaAranzmanPrikazVM()
			{
				Id = id,
				Rows = db.DestinacijaAranzman
					.Where(i=>i.AranzmanId == id)
					.OrderBy(i => i.DatumPocetka)
					.Select(i=>new DestinacijaAranzmanPrikazVM.Row()
					{
						Id = i.Id,
						Naziv = i.Destinacija.Grad,
						Smjestaj = i.Destinacija.Smjestaj.Naziv,
						DatumPocetka = i.DatumPocetka.ToString("dd.MM.yyyy"),
						DatumKraja = i.DatumKraja.ToString("dd.MM.yyyy")
					}).ToList()
			};
			return PartialView(model);
		}

		public IActionResult Dodaj(int aranzmanId)
		{
			var aramzman = db.Aranzman.Find(aranzmanId);

			var destAranzman = db.DestinacijaAranzman
				.OrderBy(i=>i.DatumKraja)
				.LastOrDefault(i => i.AranzmanId == aranzmanId);

			var model = new DestinacijaAranzmanDodajVM()
			{
				Aranzman = aramzman.Naziv,
				AranzmanId = aramzman.Id,
				DatumPocetka = destAranzman?.DatumKraja ?? DateTime.Now,
				DatumKraja = destAranzman?.DatumKraja ?? DateTime.Now,
				Destinacije = db.Destinacije
				//	.Where(i => i.Id != destAranzman.DestinacijaId)
					.Select(i => new SelectListItem()
				{
					Value = i.Id.ToString(),
					Text = i.Grad.ToString() + " - " +i.Smjestaj.Naziv.ToString()
				}).ToList()
			};

			return View(model);
		}

		[HttpPost]
		public IActionResult Dodaj(DestinacijaAranzmanDodajVM model)
		{

			var destinacijaAranzman = new DestinacijaAranzman()
			{
				DatumPocetka = model.DatumPocetka,
				DatumKraja = model.DatumKraja,
				AranzmanId = model.AranzmanId,
				DestinacijaId = model.DestinacijaId
			};

			db.DestinacijaAranzman.Add(destinacijaAranzman);
			db.SaveChanges();

			TempData["successMessage"] = "Destinacija dodata.";

			return Redirect("/Aranzman/Detalji?id=" + model.AranzmanId);
		}

		public IActionResult Obrisi(int id)
		{
			var destAranzman = db.DestinacijaAranzman.Find(id);

			db.Remove(destAranzman);
			db.SaveChanges();

			TempData["successDelete"] = "Uspjesno obrisano.";

			return Redirect("/Aranzman/Detalji?id=" + destAranzman.AranzmanId);
		}

		public IActionResult Uredi(int destinacijaAranzmanId)
		{
			var destAranzman = db.DestinacijaAranzman
				.Include(i => i.Destinacija)
				.Include(i => i.Aranzman)
				.SingleOrDefault(i => i.Id == destinacijaAranzmanId);

			var model = new DestinacijaAranzmanDodajVM()
			{
				DestinacijaAranzmanId = destinacijaAranzmanId,
				DatumPocetka = destAranzman.DatumPocetka,
				DatumKraja = destAranzman.DatumKraja,
				Aranzman = destAranzman.Aranzman.Naziv,
				AranzmanId = destAranzman.AranzmanId,
				DestinacijaId = destAranzman.DestinacijaId,
				Destinacije = db.Destinacije
					.Select(i => new SelectListItem()
					{
						Value = i.Id.ToString(),
						Text = i.Grad.ToString() + " - " + i.Smjestaj.Naziv.ToString()
					}).ToList()
			};

			return View(model);
		}

		[HttpPost]
		public IActionResult Uredi(DestinacijaAranzmanDodajVM model)
		{
			var destAranzman = db.DestinacijaAranzman.Find(model.DestinacijaAranzmanId);

			destAranzman.DestinacijaId = model.DestinacijaId;
			destAranzman.DatumPocetka = model.DatumPocetka;
			destAranzman.DatumKraja = model.DatumKraja;

			db.SaveChanges();

			TempData["successEdit"] = "Promjene sačuvane.";

			return Redirect("/Aranzman/Detalji?id=" + destAranzman.AranzmanId);
		}	
	}
}

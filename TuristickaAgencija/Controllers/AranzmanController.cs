using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TuristickaAgencija.Data.Models;
using TuristickaAgencija.ViewModels;
using TuristickaAgencija.ViewModels.Aranzman;

namespace TuristickaAgencija.Controllers
{
	public class AranzmanController : Controller
	{
		private Context db;

		public AranzmanController(Context db)
		{
			this.db = db;
		}

		public IActionResult Lista()
		{
			var model = db.Aranzman.Select(i => new AranzmanListaVm()
			{
				Id = i.Id,
				Naziv = i.Naziv,
				DatumPocetka = i.DatumPocetka.ToString("dd.MM.yyyy"),
				DatumKraja = i.DatumKraja.ToString("dd.MM.yyyy"),
			}).ToList();

			return View(model);
		}


		public IActionResult Dodaj()
		{
			var model = new AranzmanDodajVM()
			{
				Vodici = db.Vodic.Select(i=>new SelectListItem(){
					Text = i.Ime + " " + i.Prezime,
					Value = i.Id.ToString()
				}).ToList(),
				DatumPocetka = DateTime.Now,
				DatumZavrsetka = DateTime.Now
			};
				
			return View(model);
		}

		[HttpPost]
		public IActionResult Dodaj(AranzmanDodajVM x)
		{
			Aranzman novi = new Aranzman()
			{
				DatumPocetka = x.DatumPocetka,
				DatumKraja = x.DatumZavrsetka,
				Naziv = x.Naziv
			};

			if (x.VodicId != 0)
			{
				novi.VodicId = x.VodicId;
			}

			db.Aranzman.Add(novi);
			db.SaveChanges();

			TempData["successMessage"] = "Aranzman Dodan.";

			return RedirectToAction("Lista");
		}

		public IActionResult Obrisi(int aranzmanId)
		{
			Aranzman aranzman = db.Aranzman.Find(aranzmanId);

			db.Aranzman.Remove(aranzman);
			db.SaveChanges();

			TempData["successDelete"] = "Uspjesno obrisano.";

			return RedirectToAction("Lista");
		}

		public IActionResult Uredi(int aranzmanId)
		{
			Aranzman aranzman = db.Aranzman
				.Include(i => i.Vodic)
				.FirstOrDefault(i => i.Id == aranzmanId);

			AranzmanDodajVM model = new AranzmanDodajVM()
			{
				Id = aranzmanId,
				DatumPocetka = aranzman.DatumPocetka,
				DatumZavrsetka = aranzman.DatumKraja,
				Naziv = aranzman.Naziv,
				VodicId = aranzman.VodicId,
				Vodici = db.Vodic.Select(i => new SelectListItem()
				{
					Value = i.Id.ToString(),
					Text = i.Ime + ' ' + i.Prezime
				}).ToList()
			};

			return View(model);
		}

		[HttpPost]
		public IActionResult Uredi (AranzmanDodajVM x)
		{
			Aranzman aranzman = db.Aranzman.Find(x.Id);
			aranzman.DatumPocetka = x.DatumPocetka;
			aranzman.DatumKraja = x.DatumZavrsetka;
			aranzman.VodicId = x.VodicId;
			aranzman.Naziv = x.Naziv;

			db.SaveChanges();

			TempData["successEdit"] = "Promjene sačuvane.";

			return RedirectToAction("Lista");
		}

		public IActionResult Detalji(int Id)
		{
			var aranzman = db.Aranzman
				.Include(i => i.Vodic)
				.FirstOrDefault(i => i.Id == Id);

			var model = new AranzmanDetaljiVM()
			{
				Id = aranzman.Id,
				DatumPocetka = aranzman.DatumPocetka.ToString("dd.MM.yyyy"),
				DatumZavrsetka = aranzman.DatumKraja.ToString("dd.MM.yyyy"),
				Naziv = aranzman.Naziv
			};

			if (aranzman.VozacId!= null)
			{
				var vozac = db.Vozac.Find(aranzman.VozacId);
				model.VozacId= aranzman.VozacId;
				model.Vozac = vozac.Ime + " " + vozac.Prezime;
			}

			if (aranzman.VodicId != null)
			{
				var vodic = db.Vodic.Find(aranzman.VodicId);
				model.VodicId = aranzman.VodicId;
				model.Vodic = vodic.Ime + " " + vodic.Prezime;
			}

			return View(model);
		}

		public IActionResult DodijeliVodica(int id)
		{
			var model = new AranzmanDodajVM()
			{
				Id = id,
				Naziv = db.Aranzman.Find(id).Naziv,
				Vodici = db.Vodic.Select(i => new SelectListItem()
				{
					Text = i.Ime + " " + i.Prezime,
					Value = i.Id.ToString()
				}).ToList(),
			};

			return View(model);
		}

		[HttpPost]
		public IActionResult DodijeliVodica(AranzmanDodajVM model)
		{
			var aranzman = db.Aranzman.Find(model.Id);

			aranzman.VodicId = model.VodicId;
			db.SaveChanges();

			TempData["successAssign"] = "Vodič dodjeljen.";

			return Redirect("/Aranzman/Detalji?id=" + aranzman.Id);
		}

		public IActionResult DodijeliVozaca(int id)
		{
			var model = new AranzmanDodajVM()
			{
				Id = id,
				Naziv = db.Aranzman.Find(id).Naziv,
				Vozaci = db.Vozac.Select(i => new SelectListItem()
				{
					Text = i.Ime + " " + i.Prezime,
					Value = i.Id.ToString()
				}).ToList(),
			};

			return View(model);
		}

		[HttpPost]
		public IActionResult DodijeliVozaca(AranzmanDodajVM model)
		{
			var aranzman = db.Aranzman.Find(model.Id);

			aranzman.VozacId = model.VozacId;
			db.SaveChanges();

			TempData["successAssign"] = "Vozač dodjeljen.";

			return Redirect("/Aranzman/Detalji?id=" + aranzman.Id);
		}
	}
}

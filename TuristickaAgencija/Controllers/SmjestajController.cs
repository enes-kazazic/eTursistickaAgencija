﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.EntityModels;
using TuristickaAgencija.ViewModels;

namespace TuristickaAgencija.Controllers
{
	public class SmjestajController : Controller
	{
		Context db;
		public SmjestajController(Context context)
		{
			db = context;
		}
		public IActionResult Index()
		{
			return View();
		}

		[ActionName("dodaj")]
		public IActionResult Dodaj()
		{

			return View();
		}

		[HttpPost]
		[ActionName("dodaj")]
		public IActionResult Dodaj(SmjestajVM x)
		{
			Smjestaj smjestaj = new Smjestaj
			{
				Naziv = x.Naziv,
				BrojUgovora = x.BrojUgovora,
				ProvizijaPoOsobi = x.ProvizijaPoOsobi
			};
			db.Smjestaji.Add(smjestaj);
			db.SaveChanges();
			return RedirectToAction("Lista");
		}

		public IActionResult Lista()
		{
			var model = db.Smjestaji.Select(x => new SmjestajVM
			{
				Id = x.Id,
				Naziv = x.Naziv,
				BrojUgovora = x.BrojUgovora,
				ProvizijaPoOsobi = x.ProvizijaPoOsobi
			}).ToList();
			return View("Lista",model);
		}

		public IActionResult Obrisi(int smjestajID)
		{
			Smjestaj smjestaj = db.Smjestaji.Find(smjestajID);

			db.Smjestaji.Remove(smjestaj);
			db.SaveChanges();

			return RedirectToAction("Lista");
		}

		public IActionResult Uredi(int smjestajID)
		{
			Smjestaj smjestaj = db.Smjestaji.Find(smjestajID);

			SmjestajUrediVM m = new SmjestajUrediVM()
			{
				Id = smjestaj.Id,
				ProvizijaPoOsobi = smjestaj.ProvizijaPoOsobi,
				BrojUgovora = smjestaj.BrojUgovora,
				Naziv = smjestaj.Naziv
			};

			return View(m);
		}

		[HttpPost]
		public IActionResult Uredi(SmjestajUrediVM m)
		{
			Smjestaj s = db.Smjestaji.Find(m.Id);
			s.BrojUgovora = m.BrojUgovora;
			s.Naziv = m.Naziv;
			s.ProvizijaPoOsobi = m.ProvizijaPoOsobi;

			db.SaveChanges();

			return Redirect("/Smjestaj/Uredi?smjestajID=" + m.Id);
		}

	}
}

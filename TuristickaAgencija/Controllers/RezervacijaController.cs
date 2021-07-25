using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Data;
using TuristickaAgencija.Data.Models;
using TuristickaAgencija.ViewModels;
using TuristickaAgencija.ViewModels.Rezervacija;

namespace TuristickaAgencija.Controllers
{
    public class RezervacijaController : Controller
    {
		private Context db;

		public RezervacijaController(Context context)
		{
			db = context;
		}


		public IActionResult Lista()
		{
			var model = db.Rezervacija.Select(x => new RezervacijaListaVM
			{
				Id = x.Id,
				BrojRacuna = x.BrojRacuna,
				Cijena = x.Cijena,
				Datum = x.Datum
			}).ToList();

			return View(model);
		}

        [ActionName("Dodaj")]
        public IActionResult Dodaj()
        {
            RezervacijaListaVM m = new RezervacijaListaVM();
            return View(m);
        }

        [HttpPost]
        [ActionName("Dodaj")]
        public IActionResult Dodaj(RezervacijaListaVM x)
        {
            Rezervacija rezervacija = new Rezervacija
            {
                Id = x.Id,
                BrojRacuna = x.BrojRacuna,
                Cijena = x.Cijena,
                Datum = x.Datum
            };
            db.Rezervacija.Add(rezervacija);
            db.SaveChanges();

            return RedirectToAction("Lista");
        }


        public IActionResult Uredi(int rezervacijaID)
        {
            Rezervacija rezervacija = db.Rezervacija.Find(rezervacijaID);

            RezervacijaListaVM m = new RezervacijaListaVM()
            {
                Id = rezervacija.Id,
                BrojRacuna = rezervacija.BrojRacuna,
                Cijena = rezervacija.Cijena,
                Datum = rezervacija.Datum
            };
            return View(m);
        }

        [HttpPost]
        public IActionResult Uredi(RezervacijaListaVM m)
        {
            Rezervacija r = db.Rezervacija.Find(m.Id);
            r.BrojRacuna = m.BrojRacuna;
            r.Cijena = m.Cijena;
            r.Datum= m.Datum;

            db.SaveChanges();

            return RedirectToAction("Lista");
        }
        public IActionResult Obrisi(int rezervacijaID)
		{
			Rezervacija rezervacija = db.Rezervacija.Find(rezervacijaID);

			db.Rezervacija.Remove(rezervacija);
			db.SaveChanges();

			return RedirectToAction("Lista");
		}
	}
}

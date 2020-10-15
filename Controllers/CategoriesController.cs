using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corso.Models;
using Microsoft.AspNetCore.Mvc;

namespace Corso.Controllers
{
    public class CategoriesController : Controller
    {
        public CorsoContext baza;

        public CategoriesController()
        {

            baza = new CorsoContext();
        }
        public IEnumerable<Kategorije> All()
        {
            List<Kategorije> lista = new List<Kategorije>();
            foreach (Kategorije c in baza.Kategorije)
            {
                lista.Add(c);
            }

            return lista;
        }

        public IActionResult Index()
        {
            return View(All());
        }
        public IActionResult AllProductsDetails(int id)
        {
            List<Detalji> lista = new List<Detalji>();
            var rez = baza.Detalji.Where(s => s.Idkategorije == id).ToList();

            foreach (var s in rez)
            {
                lista.Add(s);
            }

            return View(lista);
        }

        public IEnumerable<Kuvari> Pocetnaa()
        {
            List<Kuvari> lista = new List<Kuvari>();
            foreach (Kuvari c in baza.Kuvari)
            {
                lista.Add(c);
            }

            return lista;
        }
        public IActionResult Pocetna()
        {
            return View(Pocetnaa());
        }

        public IActionResult ProductDetails(int id)
        {
            List<Detalji> lista = new List<Detalji>();
            var rez = baza.Detalji.Where(s => s.Iddetalja == id).ToList();

            foreach (var s in rez)
            {
                lista.Add(s);
            }

            return View(lista);
        }

        public IActionResult Popularno()
        {
            List<Detalji> lista = new List<Detalji>();
            var rez = baza.Detalji.Where(s => s.Popularno == true).ToList();

            foreach (var s in rez)
            {
                lista.Add(s);
            }

            return View(lista);
        }

    }
}

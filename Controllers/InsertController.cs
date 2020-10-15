using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Corso.Data;
using Corso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Corso.Controllers
{
    public class InsertController : Controller
    {

        public CorsoContext baza;

        private readonly IHostingEnvironment _iwebhost;

        [Authorize]
        public IActionResult InsertCategories()
        {

            return View("InsertCategories");
        }
        public InsertController(IHostingEnvironment iwebhost)
        {

            baza = new CorsoContext();
            _iwebhost = iwebhost;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> InsertCategories(Kategorije kategorija)
        {


                if (ModelState.IsValid)
                {
                    Kategorije novi = new Kategorije()
                    {

                        Naziv = kategorija.Naziv
                    };

                    if (baza.Kategorije.Any(l => l.Naziv.Equals(kategorija.Naziv)))
                    {
                        return View("PostojeciNaziv");
                    }
                    else
                    {

                        baza.Kategorije.Add(novi);
                        baza.SaveChanges();
                        return View("UploadSuccesfull");
                    }
                }
                else
                {
                    return View("InsertCategories", kategorija);
                }
            }
        
        public IActionResult UploadSuccesfull()
        {

            return View();
        }

        public IActionResult InsertDetails()
        {

            return View("InsertDetails");
        }

        [HttpPost]
        public async Task<ActionResult> InsertDetails(Detalji detalji, IFormFile ifile)
        {


            string imgtext = Path.GetExtension(ifile.FileName);
            if (imgtext == ".jpg" || imgtext == ".png" || imgtext == ".gif")
            {

                var saveimage = Path.Combine(_iwebhost.WebRootPath, "img\\menu", ifile.FileName);
                var pathsave = "img/menu/" + ifile.FileName;
                var stream = new FileStream(saveimage, FileMode.Create);
                await ifile.CopyToAsync(stream);
                stream.Close();
                detalji.Putanja = pathsave;

                if (ModelState.IsValid)
                {
                    Detalji novi = new Detalji()
                    {
                        Naziv = detalji.Naziv,
                        Putanja = detalji.Putanja,
                        Cena = detalji.Cena,
                        Popularno = detalji.Popularno,
                        Sastojci = detalji.Sastojci,
                        Opis = detalji.Opis,
                        Idkategorije = Convert.ToInt32(detalji.Idkategorije)
                    };

                    if (baza.Detalji.Any(l => l.Naziv.Equals(detalji.Naziv)))
                    {
                        return View("PostojeciNaziv1");
                    }
                    else
                    {

                        baza.Detalji.Add(novi);
                        baza.SaveChanges();
                        return View("UploadSuccesfull1");
                    }
                }
                else
                {
                    return View("InsertDetails", detalji);
                }
            }
            else
            {
                return View("InsertDetails");
            }
        }
        public IActionResult PostojeciNaziv()
        {

            return View();
        }
        public IActionResult PostojeciNaziv1()
        {

            return View();
        }
        public IActionResult UploadSuccesfull1()
        {

            return View();
        }
    }
}

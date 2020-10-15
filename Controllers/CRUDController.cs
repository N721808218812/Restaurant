using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Corso.Data;
using Corso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Corso.Controllers
{
    public class CRUDController : Controller
    {
        public CorsoContext baza;
        private readonly IHostingEnvironment _iwebhost;

        public CRUDController(IHostingEnvironment iwebhost)
        {
            baza = new CorsoContext(); _iwebhost = iwebhost;
        }


        public IActionResult Kategorije()
        {
            var displaydata = baza.Kategorije.ToList();
            return View(displaydata);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Kategorije");
            }
            var getcategorydetails = await baza.Kategorije.FindAsync(id);
            return View(getcategorydetails);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Kategorije kategorije, IFormFile ifile)
        {
            string pathsave = "";
            if (ifile != null)
            {
                string imgtext = Path.GetExtension(ifile.FileName);
                if (imgtext == ".jpg" || imgtext == ".png" || imgtext == ".gif")
                {

                    var saveimage = Path.Combine(_iwebhost.WebRootPath, "img\\categories", ifile.FileName);
                    pathsave = "img/categories/" + ifile.FileName;
                    var stream = new FileStream(saveimage, FileMode.Create);
                    await ifile.CopyToAsync(stream);

                    kategorije.Putanja = pathsave;
                }
            }

            if (ModelState.IsValid)
            {
                baza.Update(kategorije);
                await baza.SaveChangesAsync();
                return RedirectToAction("Kategorije");
            }


            else
            {
                return View("Kategorije");
            }
        }
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Kategorije");
            }
            var getcategorydetails = await baza.Kategorije.FindAsync(id);
            return View(getcategorydetails);
        }

        [HttpPost]

        public async Task<ActionResult> Delete(int id)
        {
            var Detalj = baza.Detalji.Where(x => x.Idkategorije == id);
            var getcategorydetails = await baza.Kategorije.FindAsync(id);
            baza.Detalji.RemoveRange(Detalj);
            baza.Kategorije.Remove(getcategorydetails);
            baza.SaveChanges();
            await baza.SaveChangesAsync();
            return RedirectToAction("Kategorije");
        }

        public IActionResult Detalji()
        {
            var displaydata = baza.Detalji.ToList();
            return View(displaydata);
        }

        public async Task<ActionResult> EditDetalji(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Detalji");
            }
            var getcategorydetails = await baza.Detalji.FindAsync(id);
            return View(getcategorydetails);
        }

        [HttpPost]
        public async Task<ActionResult> EditDetalji(Detalji detalji, IFormFile ifile)
        {
            if (ifile != null)
            {
                string imgtext = Path.GetExtension(ifile.FileName);
                if (imgtext == ".jpg" || imgtext == ".png" || imgtext == ".gif")
                {

                    var saveimage = Path.Combine(_iwebhost.WebRootPath, "img\\menu", ifile.FileName);
                    var pathsave = "img/menu/" + ifile.FileName;
                    var stream = new FileStream(saveimage, FileMode.Create);
                    await ifile.CopyToAsync(stream);

                    detalji.Putanja = pathsave;
                }
            }

            if (ModelState.IsValid)
            {
                baza.Update(detalji);
                await baza.SaveChangesAsync();
                return RedirectToAction("Detalji");
            }
            return View(detalji);
        }

        public async Task<ActionResult> DeleteDetalj(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Detalji");
            }
            var getcategorydetails = await baza.Detalji.FindAsync(id);
            return View(getcategorydetails);
        }

        [HttpPost]

        public async Task<ActionResult> DeleteDetalj(int id)
        {
            var getcategorydetails = await baza.Detalji.FindAsync(id);
            baza.Detalji.Remove(getcategorydetails);
            await baza.SaveChangesAsync();
            var name = getcategorydetails.Putanja.Remove(0, 9);
            var path = Path.Combine(_iwebhost.WebRootPath, "img\\menu", name); 
            FileInfo fi = new FileInfo(path);

            if (fi != null)
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    fi.Delete();
                }
            }
            return RedirectToAction("Detalji");
        }
    }
}

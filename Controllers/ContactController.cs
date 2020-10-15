using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Corso.Models;
using System.Net.Mail;

namespace Corso.Controllers
{
    public class ContactController : Controller
    {
        public CorsoContext baza;

        public ContactController()
        {
            baza = new CorsoContext();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(Pitanja pitanja)
        {
            try
            {
                string to = pitanja.To;
                string username = pitanja.Ime;
                string email = pitanja.Email;
                string body = pitanja.Pitanje;
                string bodyy = "USERNAME:" + username + "\n" + "EMAIL:" + email + "\n PITANJE: " + body;

                MailMessage mm = new MailMessage();
                mm.To.Add(to);
                mm.Subject = "PITANJA";
                mm.Body = bodyy;

                if (ModelState.IsValid)
                {
                    mm.From = new MailAddress(email);
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential("duskomladenovic58@gmail.com", "dulesladja12345");
                    smtp.Send(mm);
                    pitanja.Pitanje = body;
                    pitanja.To = to;
                    pitanja.Ime = username;
                    pitanja.Pitanje = body;
                    baza.Pitanja.Add(pitanja);
                    baza.SaveChanges();
                    ViewBag.message = "Uspesno ste poslali pitanje";
                    return RedirectToAction("Uspesno", "Contact");
                }
                else
                {
                    ViewBag.message = "Morate uneti sva obavezna polja!";
                    return RedirectToAction("Error", "Contact");
                }
            }
            catch(Exception ex)
            {
                ViewBag.message = "Morate uneti sva obavezna polja!";
                return RedirectToAction("InternetError", "Contact");
            }
        }

        public IActionResult Uspesno()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult InternetError()
        {
            return View();
        }

    }
}

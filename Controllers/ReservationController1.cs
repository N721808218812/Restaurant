using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Corso.Models;
using Microsoft.AspNetCore.Mvc;

namespace Corso.Controllers
{
    public class ReservationController1 : Controller
    {
        public CorsoContext baza;
        public ReservationController1()
        {
            baza = new CorsoContext();
        }

        public IActionResult Rezervacija()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Rezervacija(Rezervacija reservation)
        {
            try
            {
                string to = reservation.To;
                string username = reservation.Ime;
                string email = reservation.Email;
                string body = reservation.DetaljiRezervacije;
                string body1 = reservation.Telefon;
                string body2 = reservation.BrojOsoba;
                string bodyy = "USERNAME:" + username + "\n" + "EMAIL:" + email + "\nBROJ OSOBA: " + body2 + "\nVREME REZERVACIJE: " + body + "\n KONTAKT TELEFON: " + body1;

                MailMessage mm = new MailMessage();
                mm.To.Add(to);
                mm.Subject = "REZERVACIJA";
                mm.Body = bodyy;
                if (mm.Subject != null && mm.Body != null && mm.To != null && email != null)
                {
                    mm.From = new MailAddress(email);
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential("duskomladenovic58@gmail.com", "dulesladja12345");
                    smtp.Send(mm);
                    reservation.DetaljiRezervacije = body;
                    reservation.To = to;
                    reservation.Ime = username;
                    reservation.DetaljiRezervacije = body;
                    reservation.Telefon = body1;
                    reservation.BrojOsoba = body2;
                    baza.Rezervacija.Add(reservation);
                    baza.SaveChanges();
                    ViewBag.message = "Uspesno ste izvrsili rezervaciju";
                    return RedirectToAction("Uspesno", "ReservationController1");
                }
                else
                {
                    ViewBag.message = "Morate uneti sva obavezna polja!";
                    return RedirectToAction("Error", "ReservationController1");
                }

            }
            catch(Exception ex)
            {
                ViewBag.message = "Morate uneti sva obavezna polja!";
                return RedirectToAction("InternetError", "ReservationController1");
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

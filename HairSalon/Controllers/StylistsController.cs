using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HairSalon.Models;
namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        private readonly HairSalonContext _db;
        public StylistsController(HairSalonContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Stylist> model = _db.Stylists.ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Stylist stylist )
        {
            _db.Stylists.Add(stylist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Stylist stylist =  _db.Stylists.FirstOrDefault(x => x.StylistId == id);
            List<Client> clients = _db.Clients.Where(x => x.StylistId == id).ToList();
            List<Appointment> appointments = _db.Appointments.Where(x => x.StylistId == id).OrderBy(x => x.AppointmentDate).ToList();
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("stylist", stylist);
            model.Add("client", clients);
            model.Add("appointments", appointments);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            Stylist thisStylist = _db.Stylists.FirstOrDefault(x => x.StylistId == id);
            return View(thisStylist);
        }

        [HttpPost]
        public ActionResult Edit(Stylist stylist)
        {
            _db.Entry(stylist).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Stylist stylist = _db.Stylists.FirstOrDefault(x => x.StylistId == id);
            List<Client> clients = _db.Clients.Where(x => x.StylistId == id).ToList();
            if(clients.Count != 0)
            {
                string model = "Cannot delete a stylist that has clients";
                return View("Error", model);//error msg
            }
            else
            {
                _db.Stylists.Remove(stylist);
                _db.SaveChanges();
                return RedirectToAction("Index"); 
            }
             
        }
        
        public ActionResult Search(string stylistName)
        {
            List<Stylist> stylists = _db.Stylists.Where(x => x.StylistName.Contains(stylistName)).ToList();
            return View("Index", stylists); 
        }


        public ActionResult Error()
        {
            return View();
        }
    }
}
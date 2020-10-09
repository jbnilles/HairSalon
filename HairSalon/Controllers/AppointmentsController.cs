using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HairSalon.Models;
namespace HairSalon.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly HairSalonContext _db;
        public AppointmentsController(HairSalonContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Appointment> model = _db.Appointments.ToList();
            return View(model);
        }
        public ActionResult Create(int id)
        {
            if(_db.Stylists.ToList().Count == 0)
            {
                return View ("Error", "Cannot add appointment until stylist is added");
            }
            ViewBag.Client =  _db.Clients.FirstOrDefault(x => x.ClientId == id);
            return View();
        }
        [HttpPost]
        public ActionResult Create(Appointment appointment )
        {
            if(appointment.IsAbleToSchedule())
            {
                _db.Appointments.Add(appointment);
                _db.SaveChanges();
                return RedirectToAction("Index");   
            }
            return View("Index", "There is a time conflict for this time and stylist");
            
        }
        public ActionResult Details(int id)
        {
            Appointment appointment = _db.Appointments.FirstOrDefault(x => x.AppointmentId == id);        
            return View(appointment);
        }
        public ActionResult Delete(int id)
        {
            Appointment appointment = _db.Appointments.FirstOrDefault(x => x.AppointmentId == id);
            // _db.Clients.Remove(client);
            // _db.SaveChanges();
            return RedirectToAction("Index");  
        }
        public ActionResult Edit(int id)
        {
            var thisClient = _db.Clients.FirstOrDefault(c => c.ClientId == id);
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "StylistName", thisClient.StylistId );
            
            return View(thisClient);
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            _db.Entry(client).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
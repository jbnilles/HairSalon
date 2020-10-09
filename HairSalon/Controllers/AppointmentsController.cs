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
            HashSet<Appointment> appointments =  _db.Appointments.Where(x => x.StylistId == appointment.StylistId).ToHashSet();
            if(appointment.IsAbleToSchedule(appointments))
            {
                _db.Appointments.Add(appointment);
                _db.SaveChanges();
                return RedirectToAction("Index");   
            }
            return View("Error", "There is a time conflict for this time and stylist");
            
        }
        public ActionResult Details(int id)
        {
            Appointment appointment = _db.Appointments.FirstOrDefault(x => x.AppointmentId == id);        
            return View(appointment);
        }
        public ActionResult Delete(int id)
        {
            Appointment appointment = _db.Appointments.FirstOrDefault(x => x.AppointmentId == id);
            _db.Appointments.Remove(appointment);
            _db.SaveChanges();
            return RedirectToAction("Index");  
        }
        public ActionResult Edit(int id)
        {
            Appointment thisAppointment = _db.Appointments.FirstOrDefault(c => c.AppointmentId == id);
            
            
            return View(thisAppointment);
        }

        [HttpPost]
        public ActionResult Edit(Appointment appointment)
        {
            Appointment model = appointment;
            _db.Entry(appointment).State = EntityState.Modified;
            _db.SaveChanges();
           return RedirectToAction("Index");
        }
        public ActionResult Search(string clientName)
        {
            List<Appointment> appointments = _db.Appointments.Where(x => x.Client.ClientName.Contains(clientName)).ToList();
            return View("Index", appointments); 
        }
        public ActionResult OrderByTime()
        {
            List<Appointment> appointments = _db.Appointments.OrderBy(x => x.AppointmentDate).ToList();
            return View("Index", appointments); 
        }
    }
}
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using HairSalon.Models;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace HairSalon.Controllers
{
    
    public class ClientsController : Controller
    {
        private readonly HairSalonContext _db;
        public ClientsController(HairSalonContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Client> model = _db.Clients.ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            if(_db.Stylists.ToList().Count == 0)
            {
                return View ("Error", "Cannot add client until stylist is added");
            }
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "StylistName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Client client )
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Client client =  _db.Clients.FirstOrDefault(x => x.ClientId == id);
            List<Appointment> appointments = _db.Appointments.Where(x => x.ClientId == id).OrderBy(x => x.AppointmentDate).ToList();
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("client", client);
            model.Add("appointments",appointments);
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            Client client = _db.Clients.FirstOrDefault(x => x.ClientId == id);
            _db.Clients.Remove(client);
            _db.SaveChanges();
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
        [HttpPost]
        public ActionResult Search(string clientName)
        {
            List<Client> clients = _db.Clients.Where(x => x.ClientName.Contains(clientName)).ToList();
            return View("Index", clients); 
        }
        public ActionResult Error()
        {
            return View();
        }
        
        
    }
}
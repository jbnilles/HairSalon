using System;
namespace HairSalon.Models
{
    public class Appointment
    {
        public int AppointmentId {get;set;}
        public int ClientId {get;set;}
        public int StylistId {get;set;}
        public string AppointmentDescription {get;set;}
        public DateTime AppointmentDate {get;set;}
        public virtual Client Client {get;set;}
        public virtual Stylist Stylist {get;set;}
    }
}
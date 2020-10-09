using System.Collections.Generic;
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

        public bool IsAbleToSchedule(HashSet<Appointment> appointments)
        {
            Console.WriteLine(Client);

            foreach (Appointment appointment in appointments)
            {
                TimeSpan ts = AppointmentDate.Subtract(appointment.AppointmentDate);
                if(ts.TotalHours < 1 && ts.TotalHours > -1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
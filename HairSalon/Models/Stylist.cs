using System.Collections.Generic;
namespace HairSalon.Models
{
    public class Stylist
    {
        public int StylistId {get;set;}
        public string StylistName {get;set;}
        public virtual ICollection<Client> Clients {get;set;}
        public virtual ICollection<Appointment> Appointments {get;set;}
        
        public Stylist()
        {
            this.Clients = new HashSet<Client>();
            this.Appointments = new HashSet<Appointment>();
        }
        public List<Client> SearchByClientName(string clientName)
        {
            return null;
        }
    }
}
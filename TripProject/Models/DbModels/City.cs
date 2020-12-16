using System;
using System.Collections.Generic;

namespace TripProject.Models.DbModels
{
    public partial class City
    {
        public City()
        {
            Certificate = new HashSet<Certificate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public float? TicketPrice { get; set; }
        public int? TypeId { get; set; }

        public virtual Citytype Type { get; set; }
        public virtual ICollection<Certificate> Certificate { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace TripProject.Models.DbModels
{
    public partial class Citytype
    {
        public Citytype()
        {
            City = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public float? AccommodationPrice { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}

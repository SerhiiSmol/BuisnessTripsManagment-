using System;
using System.Collections.Generic;

namespace TripProject.Models.DbModels
{
    public partial class Worker
    {
        public Worker()
        {
            Certificate = new HashSet<Certificate>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Department { get; set; }

        public virtual ICollection<Certificate> Certificate { get; set; }
    }
}

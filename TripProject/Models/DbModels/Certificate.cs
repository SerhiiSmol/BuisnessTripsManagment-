using System;
using System.Collections.Generic;

namespace TripProject.Models.DbModels
{
    public partial class Certificate
    {
        public int Id { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime Ending { get; set; }
        public int? WorkerId { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual Worker Worker { get; set; }
    }
}

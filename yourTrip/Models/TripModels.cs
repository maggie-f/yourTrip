using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace yourTrip.Models
{
    public class TripModels
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Return { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        [StringLength(128)]
        [ForeignKey("User")]
        public string UserRefId { get; set; }
        public ApplicationUser User { get; set; }
        public IList<DestinationModels> Destinations { get; set; }
    }
}
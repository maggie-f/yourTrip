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
        [StringLength(250)]
        public string Location { get; set; }
        [StringLength(50)]
        public string Latitud { get; set; }
        [StringLength(50)]
        public string Longitud { get; set; }
        [Required]
        public DateTime Departure { get; set; }

        //[StringLength(128)]
        //public string UserId { get; set; }
        //[ForeignKey(name: "AspNetUsersID")]
        //public ApplicationUser ApplicationUser { get; set; }
    }
}
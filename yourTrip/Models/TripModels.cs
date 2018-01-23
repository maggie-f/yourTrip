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
        public string Destination { get; set; }
        [StringLength(50)]
        public string Latitud { get; set; }
        [StringLength(50)]
        public string Longitud { get; set; }
        public int? Zoom { get; set; }
        [Required]
        [StringLength(250)]
        public string PlaceId { get; set; }
        [Required]
        public DateTime Departure { get; set; }
        [Required]
        [StringLength(128)]
        public string UserId { get; set; }
        [ForeignKey(name: "UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}
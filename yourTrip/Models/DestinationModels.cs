using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace yourTrip.Models
{
    public class DestinationModels
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
        public DateTime Arrival { get; set; }
        public DateTime Leave { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        [Required]
        [StringLength(128)]
        public string UserId { get; set; }
        [ForeignKey("Trip")]
        public int TripRefId { get; set; }
        public TripModels Trip { get; set; }
    }
}
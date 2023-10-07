using System;
using System.ComponentModel.DataAnnotations;
namespace LindnerAirlines.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Display(Name = "Flight Number")]
        public string? FlightNumber { get; set; }

        [Display(Name = "Source")]
        public string Source { get; set; }


        [Display(Name = "Destination")]
        public string Destination { get; set; }


        // Navigation property for related entities Reservations
        public ICollection<Booking>? Bookings { get; set; }
    }

}


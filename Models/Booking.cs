using System;
using System.ComponentModel.DataAnnotations;
namespace LindnerAirlines.Models
{
    public class Booking
    {
        private CabinClass cabinClass;

        public enum CabinClass
        {
            Economy,
            PremiumEconomy,
            Business,
            FirstClass
        }

        public int Id { get; set; }

        [Display(Name = "PNR Number")]
        public string PNR { get; private set; }

        [Display(Name = "Passenger Name")]
        public string? PassengerName { get; set; }


        [Display(Name = "From")]
        public string Source { get; set; }


        [Display(Name = "To")]
        public string Destination { get; set; }

        [Display(Name = "Date")]
        public DateTime? BookingDate { get; set; }

        [Display(Name = "Cabin Class")]
        public CabinClass SeatClass { get => cabinClass; set => cabinClass = value; }

        // Navigation property for related entities, e.g., Flight
        public Flight? Flight { get; set; }
        public int? FlightId { get; set; }

        public Booking()
        {
            PNR = GenerateRandomPNR();
        }

        // Helper method to generate a random PNR
        private string GenerateRandomPNR()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

}


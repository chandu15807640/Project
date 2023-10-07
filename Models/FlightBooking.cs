namespace LindnerAirlines.Models
{
    public class FlightBooking
    {
        public int Id { get; set; }
        public Flight? Flight { get; set; }
        public int? FlightId { get; set; }
        public Booking? Booking { get; set; }
        public int? BookingId { get; set; }


    }
}

using System;
namespace LindnerAirlines.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }

        // Property to store the related Booking information
        public Booking RelatedBooking { get; set; }

        public User? User { get; set; }
        public int? UserId { get; set; }

        public Payment()
        {
            TransactionId = GenerateRandomPNR();
        }

        private string GenerateRandomPNR()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 12)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        // Constructor to calculate the payment amount based on the Booking's cabin class
        public Payment(Booking booking)
        {
            RelatedBooking = booking;

            // Calculate the payment amount based on the cabin class
            CalculatePaymentAmount();
        }

        // Method to calculate the payment amount based on the cabin class
        public void CalculatePaymentAmount()
        {
            if (RelatedBooking != null)
            {
                // Assuming you have a method to retrieve the price based on the cabin class
                decimal cabinClassPrice = GetPriceForCabinClass(RelatedBooking.SeatClass);

                // Calculate the payment amount
                Amount = cabinClassPrice; // You can apply any additional logic if needed
            }
            else
            {
                Amount = 0; // Default to 0 if there is no related booking
            }
        }

        private decimal GetPriceForCabinClass(Booking.CabinClass seatClass)
        {
            throw new NotImplementedException();
        }

        // Method to retrieve the price based on the cabin class
        private decimal GetPriceForCabinClass(string cabinClass)
        {
            // Implement logic to fetch the price based on the cabin class
            // You may retrieve this information from a database or a predefined pricing structure
            // For this example, we'll use simple fixed prices for illustration
            switch (cabinClass)
            {
                case "Economy":
                    return 500; // Sample price for Economy class
                case "Business":
                    return 1000; // Sample price for Business class
                case "FirstClass":
                    return 2000; // Sample price for First Class
                default:
                    return 0; // Default to 0 if cabin class is not recognized
            }
        }
    }
}


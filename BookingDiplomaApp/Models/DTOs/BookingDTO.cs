using BookingDomainClassLibrary;

namespace BookingDiplomaApp.Models.DTOs
{
    public class BookingDTO
    {
        public int ApartmentId { get; set; }
        public ApartmentDTO? Apartment { get; set; } 
        public DateTime FromDate { get; set; }
        public DateTime TillDate { get; set; }

        public int GuestCount { get; set; }
    }
}

using BookingDomainClassLibrary;

namespace BookingDiplomaApp.Models.DTOs
{
    public class FacilityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public byte[]? Logo { get; set; } = default!;
        public ICollection<ApartmentDTO>? Apartments { get; set; }
    }
}

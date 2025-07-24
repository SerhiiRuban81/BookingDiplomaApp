using BookingDomainClassLibrary;
using System.ComponentModel.DataAnnotations;

namespace BookingDiplomaApp.Models.DTOs
{
    public class PhotoDTO
    {
        public int Id { get; set; }
        [Display(Name = "Кімната")] 
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; } = default!;
        [Display(Name = "Фото")]
        public byte[] PhotoData { get; set; } = default!;

    }
}

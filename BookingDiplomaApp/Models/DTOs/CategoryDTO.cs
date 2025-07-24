using BookingDomainClassLibrary;
using System.ComponentModel.DataAnnotations;

namespace BookingDiplomaApp.Models.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Display(Name = "Назва")]
        public string Name { get; set; } = default!;
        public ICollection<Apartment>? Apartments { get; set; }
    }
}

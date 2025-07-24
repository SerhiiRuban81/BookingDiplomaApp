using BookingDomainClassLibrary;
using System.ComponentModel.DataAnnotations;

namespace BookingDiplomaApp.Models.DTOs
{
    public class CityDTO
    {
        public int Id { get; set; }
        [Display(Name = "Назва міста")]

        public string Name { get; set; } = default!;
        [Display(Name = "Довгота")]
        public double? Longitude { get; set; }
        [Display(Name = "Широта")]
        public double? Lattitude { get; set; }
        public ICollection<Apartment>? Apartments { get; set; }

    }
}

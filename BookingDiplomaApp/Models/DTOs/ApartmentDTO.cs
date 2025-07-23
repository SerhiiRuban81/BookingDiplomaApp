using BookingDomainClassLibrary;
using System.ComponentModel.DataAnnotations;

namespace BookingDiplomaApp.Models.DTOs
{
    public class ApartmentDTO
    {
        public int Id { get; set; }

        [Display(Name = "Назва")]
        public string Title { get; set; } = default!;
        [Display(Name = "Опис")]
        public string Description { get; set; } = default!;
        [Display(Name = "Вартість за добу")]
        public double Price { get; set; }
        public City? City { get; set; } = default!;
        [Display(Name = "Місто")]
        public int CityId { get; set; }
        public Category? Category { get; set; } = default!;
        [Display(Name = "Категорія")]
        public int CategoryId { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; } = default!;

        [Display(Name = "Кількість місць")]
        public int Places { get; set; }

        [Display(Name = "Площа, м2")]
        public int Square { get; set; }
        [Display(Name = "Кількість кімнат")]
        public int RoomsCount { get; set; }

        [Display(Name = "Відстань від центру")]
        public double DistanceFromCenter { get; set; }
        public ICollection<Facility>? Facilities { get; set; } = default!;
        public ICollection<Photo>? Photos { get; set; } = default!;
    }
}

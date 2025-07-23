using BookingDiplomaApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BookingDiplomaApp.Models.ViewModels
{
    public class CreateApartmentVM
    {
        public ApartmentDTO Apartment { get; set; } = default!;
        [Display(Name = "Місто")]
        public SelectList? Cities { get; set; } = default!;
        [Display(Name = "Категорія")]
        public SelectList? Categories { get; set; } = default!;

    }
}

using BookingDiplomaApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BookingDiplomaApp.Models.ViewModels
{
    public class CreatePhotoVM
    {
        public PhotoDTO Photo { get; set; } = default!;
        [Display(Name = "Кімната")]
        public SelectList? Apartments { get; set; } = default!;

        public IFormFile PhotoFile { get; set; } = default!;
    }
}

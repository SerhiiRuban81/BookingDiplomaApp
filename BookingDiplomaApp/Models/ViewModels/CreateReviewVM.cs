using BookingDiplomaApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BookingDiplomaApp.Models.ViewModels
{
    public class CreateReviewVM
    {
        public ReviewDTO Review { get; set; } = default!;
        [Display(Name = "Користувач магазину")]
        public SelectList? ShopUserId { get; set; } = default!;
    }
}

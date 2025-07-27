using BookingDomainClassLibrary;
using System.ComponentModel.DataAnnotations;

namespace BookingDiplomaApp.Models.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        [Display(Name = "Користувач Id")]
        public int? BookingId { get; set; }
        [Display(Name = "Коментар")]

        public int AppartmentId { get; set; }
        public string Text { get; set; } = default!;
        [Display(Name = "Рейтинг")]
        public int Rating { get; set; }
        [Display(Name = "Дата коментаря")]
        public DateTime Date { get; set; }
        public ShopUser? ShopUser { get; set; } = default!;
        [Display(Name = "Користувач магазину")]
        public string? ShopUserId { get; set; } = default!;

    }
}

using BookingDiplomaApp.Models.DTOs;

namespace BookingDiplomaApp.Models.ViewModels
{
    public class CreateFacitityVM
    {
        public FacilityDTO Facility { get; set; } = default!;

        public IFormFile Logo { get; set; } = default!;
    }
}

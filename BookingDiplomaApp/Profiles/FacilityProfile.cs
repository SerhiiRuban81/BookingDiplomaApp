using AutoMapper;
using BookingDiplomaApp.Models.DTOs;
using BookingDomainClassLibrary;

namespace BookingDiplomaApp.Profiles
{
    public class FacilityProfile : Profile
    {
        public FacilityProfile() {
            CreateMap<FacilityDTO, Facility>()
                .ReverseMap();
        }
    }
}

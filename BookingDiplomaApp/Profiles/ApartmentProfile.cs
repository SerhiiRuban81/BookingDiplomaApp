using AutoMapper;
using BookingDiplomaApp.Models.DTOs;
using BookingDomainClassLibrary;

namespace BookingDiplomaApp.Profiles
{
    public class ApartmentProfile : Profile
    {
        public ApartmentProfile()
        {
            CreateMap<ApartmentDTO, Apartment>()
                .ReverseMap();
        }
    }
}

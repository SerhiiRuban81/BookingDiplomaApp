using AutoMapper;
using BookingDiplomaApp.Models.DTOs;
using BookingDomainClassLibrary;

namespace BookingDiplomaApp.Profiles
{
    public class PhotoProfile : Profile
    {
        public PhotoProfile() {
            CreateMap<PhotoDTO, Photo>()
                .ReverseMap();
        }
    }
}

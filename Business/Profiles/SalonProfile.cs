using AutoMapper;
using Business.DTO.Salon;
using Entities.Concrete;

namespace Business.Profiles
{
    public class SalonProfile : Profile
    {
        public SalonProfile()
        {
            CreateMap<Salon, CreateSalonRequest>().ReverseMap();
            CreateMap<Salon, UpdateSalonRequest>().ReverseMap();
        }
    }
}

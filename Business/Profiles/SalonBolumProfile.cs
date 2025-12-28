using AutoMapper;
using Business.DTO.SalonBolum;
using Entities.Concrete;

namespace Business.Profiles
{
    public class SalonBolumProfile : Profile
    {
        public SalonBolumProfile()
        {
            CreateMap<SalonBolum, CreateSalonBolumRequest>().ReverseMap();
            CreateMap<SalonBolum, UpdateSalonBolumRequest>().ReverseMap();
        }
    }
}

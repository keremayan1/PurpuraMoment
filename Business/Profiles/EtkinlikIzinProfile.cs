using AutoMapper;
using Business.DTO.EtkinlikIzin;
using Entities.Concrete;

namespace Business.Profiles
{
    public class EtkinlikIzinProfile : Profile
    {
        public EtkinlikIzinProfile()
        {
            CreateMap<EtkinlikIzin, CreateEtkinlikIzinRequest>().ReverseMap();
            CreateMap<EtkinlikIzin, UpdateEtkinlikIzinRequest>().ReverseMap();
        }
    }
}

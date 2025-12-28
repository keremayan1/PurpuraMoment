using AutoMapper;
using Business.DTO.Medya;
using Entities.Concrete;

namespace Business.Profiles
{
    public class MedyaProfile : Profile
    {
        public MedyaProfile()
        {
            CreateMap<Medya, CreateMedyaRequest>().ReverseMap();
            CreateMap<Medya, UpdateMedyaRequest>().ReverseMap();
        }
    }
}

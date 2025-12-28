using AutoMapper;
using Business.DTO.SalonPlan;
using Entities.Concrete;

namespace Business.Profiles
{
    public class SalonPlanProfile : Profile
    {
        public SalonPlanProfile()
        {
            CreateMap<SalonPlan, CreateSalonPlanRequest>().ReverseMap();
            CreateMap<SalonPlan, UpdateSalonPlanRequest>().ReverseMap();
        }
    }
}

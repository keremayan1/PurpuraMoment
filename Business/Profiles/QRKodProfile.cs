using AutoMapper;
using Business.DTO.QRKod;
using Entities.Concrete;

namespace Business.Profiles
{
    public class QRKodProfile : Profile
    {
        public QRKodProfile()
        {
            CreateMap<QRKod, CreateQRKodRequest>().ReverseMap();
            CreateMap<QRKod, UpdateQRKodRequest>().ReverseMap();
        }
    }
}

using AutoMapper;
using Business.DTO.Etkinlik;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class EtkinlikProfile:Profile
    {
        public EtkinlikProfile()
        {
            CreateMap<Etkinlik, CreateEtkinlikRequest>().ReverseMap();
            CreateMap<Etkinlik, UpdateEtkinlikRequest>().ReverseMap();
        }
    }
}

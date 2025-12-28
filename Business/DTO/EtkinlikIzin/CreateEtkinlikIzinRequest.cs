using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.EtkinlikIzin
{
    public class CreateEtkinlikIzinRequest
    {
        public int EtkinlikId { get; set; }
        public int KullaniciId { get; set; }
        public bool Goruntuleme { get; set; }
        public bool Indirme { get; set; }
    }
}

using Core.Entities;

namespace Entities.Concrete
{
    public class EtkinlikIzin:Entity
    {
        public int EtkinlikId { get; set; }
        public int KullaniciId { get; set; }
        public bool Goruntuleme { get; set; }
        public bool Indirme { get; set; }
    }

}

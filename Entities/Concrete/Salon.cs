using Core.Entities;

namespace Entities.Concrete
{
    public class Salon : Entity
    {
        public int KullaniciId { get; set; }
        public string SalonAdi { get; set; }
        public string Adres { get; set; }
    }

}

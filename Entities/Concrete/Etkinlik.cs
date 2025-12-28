using Core.Entities;

namespace Entities.Concrete
{
    public class Etkinlik:Entity
    {
        public int SalonId { get; set; }
        public int SalonBolumId { get; set; }
        public string CiftAdi { get; set; }
        public DateTime BaslangicZaman { get; set; }
        public DateTime BitisZaman { get; set; }
        public bool Paylasim { get; set; }

    }
}

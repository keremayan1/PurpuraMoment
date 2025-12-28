using Core.Entities;

namespace Entities.Concrete
{
    public class Medya : Entity
    {
        public int EtkinlikId { get; set; }
        public string DosyaUrl { get; set; }
        public byte DosyaTipi { get; set; }
        public string YukleyenMisafir { get; set; }
    }
 
}

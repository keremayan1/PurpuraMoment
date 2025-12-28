using Core.Entities;

namespace Entities.Concrete
{
    public class Kullanici : Entity
    {
        public string Email { get; set; }
        public string Adi { get; set; }
        public string SifreHash { get; set; }
        public string GoogleId { get; set; }
        public string Rol { get; set; }
    }

}

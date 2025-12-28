using Core.Entities;

namespace Entities.Concrete
{
    public class SalonPlan : Entity
    {
        public int KullaniciId { get; set; }
        public int MaxSalonSayisi { get; set; }
        public int AktifSalonSayisi { get; set; }
        public string PlanAdi { get; set; }
    }

}

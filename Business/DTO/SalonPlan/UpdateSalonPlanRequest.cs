namespace Business.DTO.SalonPlan
{
    public class UpdateSalonPlanRequest
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int MaxSalonSayisi { get; set; }
        public int AktifSalonSayisi { get; set; }
        public string PlanAdi { get; set; }
    }
}

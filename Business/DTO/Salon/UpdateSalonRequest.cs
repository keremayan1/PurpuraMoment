namespace Business.DTO.Salon
{
    public class UpdateSalonRequest
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string SalonAdi { get; set; }
        public string Adres { get; set; }
    }
}

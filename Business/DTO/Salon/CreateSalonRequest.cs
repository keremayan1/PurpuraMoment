namespace Business.DTO.Salon
{
    public class CreateSalonRequest
    {
        public int KullaniciId { get; set; }
        public string SalonAdi { get; set; }
        public string Adres { get; set; }
    }
}

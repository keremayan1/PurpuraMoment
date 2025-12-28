namespace Business.DTO.Etkinlik
{
    public class CreateEtkinlikRequest
    {
        public int SalonId { get; set; }
        public int SalonBolumId { get; set; }
        public string CiftAdi { get; set; }
        public DateTime BaslangicZaman { get; set; }
        public DateTime BitisZaman { get; set; }
        public bool Paylasim { get; set; }
    }
}

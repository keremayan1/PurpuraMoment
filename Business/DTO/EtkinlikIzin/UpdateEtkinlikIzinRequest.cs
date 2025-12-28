namespace Business.DTO.EtkinlikIzin
{
    public class UpdateEtkinlikIzinRequest
    {
        public int Id { get; set; }
        public int EtkinlikId { get; set; }
        public int KullaniciId { get; set; }
        public bool Goruntuleme { get; set; }
        public bool Indirme { get; set; }
    }
}

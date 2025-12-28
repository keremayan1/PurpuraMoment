namespace Business.DTO.Medya
{
    public class UpdateMedyaRequest
    {
        public int Id { get; set; }
        public int EtkinlikId { get; set; }
        public string DosyaUrl { get; set; }
        public byte DosyaTipi { get; set; }
        public string YukleyenMisafir { get; set; }
    }
}

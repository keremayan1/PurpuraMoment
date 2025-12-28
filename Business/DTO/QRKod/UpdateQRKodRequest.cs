namespace Business.DTO.QRKod
{
    public class UpdateQRKodRequest
    {
        public int Id { get; set; }
        public int SalonBolumId { get; set; }
        public string QrData { get; set; }
    }
}

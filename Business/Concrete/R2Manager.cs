using Amazon.S3;
using Amazon.S3.Model;
using Business.Abstract;
using Business.DTO.CloudflareR2;
using Core.Utilities.Results;
using Core.Utilities.Slug;

namespace Business.Concrete
{
    public class R2Manager : IR2Service
    {
        private readonly string _accessKey = "45b0d5b77e55a49318318ecab3ee6ee0";
        private readonly string _secretKey = "ae50bc24ccf47dfe0aca973cecb08ec43d3665b5e5a526d0282262e1d52ac5e8";
        private readonly string _accountId = "dd390bb847b3de75ec0fd6439ffb2609";
        private readonly string _bucketName = "purpura-moment";
        private readonly string _publicBaseUrl = "https://pub-8a774e51f2bb4ae1bcaa72f6ceae5d50.r2.dev"; // Cloudflare R2 Public URL
        private readonly IAmazonS3 _client;
        private readonly IEtkinlikService _etkinlikService;
        public R2Manager(IEtkinlikService etkinlikService)
        {
            var config = new AmazonS3Config
            {
                ServiceURL = $"https://{_accountId}.r2.cloudflarestorage.com",
                ForcePathStyle = true, // R2 için gerekli

            };
            var credentials = new Amazon.Runtime.BasicAWSCredentials(
              _accessKey,
              _secretKey
            );

            _client = new AmazonS3Client(credentials, config);
            _etkinlikService = etkinlikService;
        }

        public async Task<IDataResult<UrlClassResponse>> InitFile(int etkinlikId)
        {
            var  getModel = await _etkinlikService.GetById(etkinlikId);
            if (getModel.Data == null)
                return new ErrorDataResult<UrlClassResponse>("Etkinlik Bilgisi Çekilemedi.");

            var veri = getModel.Data.SalonId + "-" + getModel.Data.SalonBolumId + "-" + getModel.Data.CiftAdi;

            var regex = SlugHelper.ToSlug(veri);

            var fileKey = $"{regex}/{Guid.NewGuid().ToString()}";
            var request = new GetPreSignedUrlRequest
            {
                BucketName = _bucketName,
                Key = fileKey,
                Verb = HttpVerb.PUT,
                Expires = DateTime.UtcNow.AddMinutes(5)
            };

            var uploadUrl = _client.GetPreSignedURL(request);

            var result = new  UrlClassResponse
            {
                UploadURL = uploadUrl,
                FileKey = fileKey,
                CDNUrl = $"{_publicBaseUrl}/{fileKey}"
            };
            return new SuccessDataResult<UrlClassResponse>(result);
        }
    }


}

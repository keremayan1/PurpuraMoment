using Business.DTO.CloudflareR2;
using Core.Utilities.Results;
namespace Business.Abstract
{
    public interface IR2Service
    {
        Task<IDataResult<UrlClassResponse>> InitFile(int etkinlikId);
    }

}

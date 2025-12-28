using Business.DTO.QRKod;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IQRKodService
    {
        Task<IDataResult<List<QRKod>>> GetAll();
        Task<IDataResult<QRKod>> GetById(int id);
        Task<IResult> Add(CreateQRKodRequest qrKod);
        Task<IResult> Update(UpdateQRKodRequest qrKod);
        Task<IResult> Delete(int id);
        Task<bool> Exists(int id);
    }
}

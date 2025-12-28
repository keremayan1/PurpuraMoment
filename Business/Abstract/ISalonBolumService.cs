using Business.DTO.SalonBolum;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISalonBolumService
    {
        Task<IDataResult<List<SalonBolum>>> GetAll();
        Task<IDataResult<SalonBolum>> GetById(int id);
        Task<IResult> Add(CreateSalonBolumRequest salonBolum);
        Task<IResult> Update(UpdateSalonBolumRequest salonBolum);
        Task<IResult> Delete(int id);
        Task<bool> Exists(int id);
    }
}

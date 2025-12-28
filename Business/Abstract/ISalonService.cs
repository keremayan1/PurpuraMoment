using Business.DTO.Salon;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISalonService
    {
        Task<IDataResult<List<Salon>>> GetAll();
        Task<IDataResult<Salon>> GetById(int id);
        Task<IResult> Add(CreateSalonRequest salon);
        Task<IResult> Update(UpdateSalonRequest salon);
        Task<IResult> Delete(int id);
        Task<bool> Exists(int id);
    }
}

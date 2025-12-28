using Business.DTO.Etkinlik;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IEtkinlikService
    {
        Task<IDataResult<List<Etkinlik>>> GetAll();
        Task<IDataResult<Etkinlik>> GetById(int id);
        Task<IResult> Add(CreateEtkinlikRequest etkinlik);
        Task<IResult> Update(UpdateEtkinlikRequest etkinlik);
        Task<IResult> Delete(int id);
        Task<bool> Exists(int id);
    }
}

using Business.DTO.EtkinlikIzin;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IEtkinlikIzinService
    {
        Task<IDataResult<List<EtkinlikIzin>>> GetAll();
        Task<IDataResult<EtkinlikIzin>> GetById(int id);
        Task<IResult> Add(CreateEtkinlikIzinRequest etkinlikIzin);
        Task<IResult> Update(UpdateEtkinlikIzinRequest etkinlikIzin);
        Task<IResult> Delete(int id);
        Task<bool> Exists(int id);
    }
}

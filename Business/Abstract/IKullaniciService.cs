using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IKullaniciService
    {
        Task<IDataResult<List<Kullanici>>> GetAll();
        Task<IDataResult<Kullanici>> GetById(int id);
        Task<IResult> Add(Kullanici kullanici);
        Task<IResult> Update(Kullanici kullanici);
        Task<IResult> Delete(int id);
        Task<bool> Exists(int id);
    }
}

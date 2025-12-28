using Business.DTO.Medya;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMedyaService
    {
        Task<IDataResult<List<Medya>>> GetAll();
        Task<IDataResult<Medya>> GetById(int id);
        Task<IResult> Add(CreateMedyaRequest medya);
        Task<IResult> Update(UpdateMedyaRequest medya);
        Task<IResult> Delete(int id);
        Task<bool> Exists(int id);
    }
}

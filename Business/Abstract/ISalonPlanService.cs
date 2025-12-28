using Business.DTO.SalonPlan;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISalonPlanService
    {
        Task<IDataResult<List<SalonPlan>>> GetAll();
        Task<IDataResult<SalonPlan>> GetById(int id);
        Task<IResult> Add(CreateSalonPlanRequest salonPlan);
        Task<IResult> Update(UpdateSalonPlanRequest salonPlan);
        Task<IResult> Delete(int id);
        Task<bool> Exists(int id);
    }
}

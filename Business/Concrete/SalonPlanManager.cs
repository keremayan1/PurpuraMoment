using AutoMapper;
using Business.Abstract;
using Business.DTO.SalonPlan;
using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class SalonPlanManager : ISalonPlanService
    {
        private readonly IRepository<SalonPlan> _SalonPlanRepository;
        private readonly IMapper _mapper;

        public SalonPlanManager(IRepository<SalonPlan> SalonPlanRepository, IMapper mapper)
        {
            _SalonPlanRepository = SalonPlanRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Add(CreateSalonPlanRequest SalonPlan)
        {
            var model = _mapper.Map<SalonPlan>(SalonPlan);

            await _SalonPlanRepository.AddAsync(model);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(int id)
        {
            var getId = await _SalonPlanRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
            if (getId == null)
                return new ErrorResult("SalonPlan  bulunamadı");

            await _SalonPlanRepository.DeleteAsync(getId);
            return new SuccessResult();
        }

        public async Task<bool> Exists(int id)
        {
            var result = await _SalonPlanRepository.Table.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task<IDataResult<List<SalonPlan>>> GetAll()
        {
            var result = await _SalonPlanRepository.Table.ToListAsync();
            return new SuccessDataResult<List<SalonPlan>>(result);
        }

        public async Task<IDataResult<SalonPlan>> GetById(int id)
        {
            var getId = await _SalonPlanRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
            if (getId == null)
                return new ErrorDataResult<SalonPlan>("SalonPlan bulunamadı");
            return new SuccessDataResult<SalonPlan>(getId);
        }

        public async Task<IResult> Update(UpdateSalonPlanRequest SalonPlan)
        {
            var getId = await _SalonPlanRepository.Table.FirstOrDefaultAsync(x => x.Id == SalonPlan.Id);
            if (getId == null)
                return new ErrorDataResult<SalonPlan>("SalonPlan bulunamadı");

            getId.KullaniciId = SalonPlan.KullaniciId;
            getId.MaxSalonSayisi = SalonPlan.MaxSalonSayisi;
            getId.AktifSalonSayisi = SalonPlan.AktifSalonSayisi;
            getId.PlanAdi = SalonPlan.PlanAdi;
            getId.MDate = DateTime.Now;

            await _SalonPlanRepository.UpdateAsync(getId);
            return new SuccessResult("Kayıt İşlemi başarılı");
        }
    }
}

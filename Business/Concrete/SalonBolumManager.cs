using AutoMapper;
using Business.Abstract;
using Business.DTO.SalonBolum;
using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class SalonBolumManager : ISalonBolumService
    {
        private readonly IRepository<SalonBolum> _SalonBolumRepository;
        private readonly IMapper _mapper;

        public SalonBolumManager(IRepository<SalonBolum> SalonBolumRepository, IMapper mapper)
        {
            _SalonBolumRepository = SalonBolumRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Add(CreateSalonBolumRequest SalonBolum)
        {
            var model = _mapper.Map<SalonBolum>(SalonBolum);

            await _SalonBolumRepository.AddAsync(model);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(int id)
        {
            var getId = await _SalonBolumRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
            if (getId == null)
                return new ErrorResult("SalonBolum  bulunamadı");

            await _SalonBolumRepository.DeleteAsync(getId);
            return new SuccessResult();
        }

        public async Task<bool> Exists(int id)
        {
            var result = await _SalonBolumRepository.Table.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task<IDataResult<List<SalonBolum>>> GetAll()
        {
            var result = await _SalonBolumRepository.Table.ToListAsync();
            return new SuccessDataResult<List<SalonBolum>>(result);
        }

        public async Task<IDataResult<SalonBolum>> GetById(int id)
        {
            var getId = await _SalonBolumRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
            if (getId == null)
                return new ErrorDataResult<SalonBolum>("SalonBolum bulunamadı");
            return new SuccessDataResult<SalonBolum>(getId);
        }

        public async Task<IResult> Update(UpdateSalonBolumRequest SalonBolum)
        {
            var getId = await _SalonBolumRepository.Table.FirstOrDefaultAsync(x => x.Id == SalonBolum.Id);
            if (getId == null)
                return new ErrorDataResult<SalonBolum>("SalonBolum bulunamadı");

            getId.SalonId = SalonBolum.SalonId;
            getId.Adi = SalonBolum.Adi;
            getId.MDate = DateTime.Now;

            await _SalonBolumRepository.UpdateAsync(getId);
            return new SuccessResult("Kayıt İşlemi başarılı");
        }
    }
}

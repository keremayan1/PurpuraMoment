using AutoMapper;
using Business.Abstract;
using Business.DTO.Salon;
using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class SalonManager : ISalonService
    {
        private readonly IRepository<Salon> _SalonRepository;
        private readonly IMapper _mapper;

        public SalonManager(IRepository<Salon> SalonRepository, IMapper mapper)
        {
            _SalonRepository = SalonRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Add(CreateSalonRequest Salon)
        {
            var model = _mapper.Map<Salon>(Salon);

            await _SalonRepository.AddAsync(model);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(int id)
        {
            var getId = await _SalonRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
            if (getId == null)
                return new ErrorResult("Salon  bulunamadı");

            await _SalonRepository.DeleteAsync(getId);
            return new SuccessResult();
        }

        public async Task<bool> Exists(int id)
        {
            var result = await _SalonRepository.Table.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task<IDataResult<List<Salon>>> GetAll()
        {
            var result = await _SalonRepository.Table.ToListAsync();
            return new SuccessDataResult<List<Salon>>(result);
        }

        public async Task<IDataResult<Salon>> GetById(int id)
        {
            var getId = await _SalonRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
            if (getId == null)
                return new ErrorDataResult<Salon>("Salon bulunamadı");
            return new SuccessDataResult<Salon>(getId);
        }

        public async Task<IResult> Update(UpdateSalonRequest Salon)
        {
            var getId = await _SalonRepository.Table.FirstOrDefaultAsync(x => x.Id == Salon.Id);
            if (getId == null)
                return new ErrorDataResult<Salon>("Salon bulunamadı");

            getId.KullaniciId = Salon.KullaniciId;
            getId.SalonAdi = Salon.SalonAdi;
            getId.Adres = Salon.Adres;
            getId.MDate = DateTime.Now;

            await _SalonRepository.UpdateAsync(getId);
            return new SuccessResult("Kayıt İşlemi başarılı");
        }
    }
}

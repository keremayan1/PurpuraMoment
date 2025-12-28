using AutoMapper;
using Business.Abstract;
using Business.DTO.Medya;
using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class MedyaManager : IMedyaService
    {
        private readonly IRepository<Medya> _MedyaRepository;
        private readonly IMapper _mapper;

        public MedyaManager(IRepository<Medya> MedyaRepository, IMapper mapper)
        {
            _MedyaRepository = MedyaRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Add(CreateMedyaRequest Medya)
        {
            var model = _mapper.Map<Medya>(Medya);

            await _MedyaRepository.AddAsync(model);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(int id)
        {
            var getId = await _MedyaRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
            if (getId == null)
                return new ErrorResult("Medya bulunamadı");

            await _MedyaRepository.DeleteAsync(getId);
            return new SuccessResult();
        }

        public async Task<bool> Exists(int id)
        {
            var result = await _MedyaRepository.Table.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task<IDataResult<List<Medya>>> GetAll()
        {
            var result = await _MedyaRepository.Table.ToListAsync();
            return new SuccessDataResult<List<Medya>>(result);
        }

        public async Task<IDataResult<Medya>> GetById(int id)
        {
            var getId = await _MedyaRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
            if (getId == null)
                return new ErrorDataResult<Medya>("Medya bulunamadı");
            return new SuccessDataResult<Medya>(getId);
        }

        public async Task<IResult> Update(UpdateMedyaRequest Medya)
        {
            var getId = await _MedyaRepository.Table.FirstOrDefaultAsync(x => x.Id == Medya.Id);
            if (getId == null)
                return new ErrorDataResult<Medya>("Medya bulunamadı");

            getId.EtkinlikId = Medya.EtkinlikId;
            getId.DosyaUrl = Medya.DosyaUrl;
            getId.DosyaTipi = Medya.DosyaTipi;
            getId.YukleyenMisafir = Medya.YukleyenMisafir;
            getId.MDate = DateTime.Now;

            await _MedyaRepository.UpdateAsync(getId);
            return new SuccessResult("Kayıt İşlemi başarılı");
        }
    }
}

using AutoMapper;
using Business.Abstract;
using Business.DTO.Etkinlik;
using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class EtkinlikManager : IEtkinlikService
    {
        private readonly IRepository<Etkinlik> _etkinlikRepository;
        private readonly IMapper _mapper;

        public EtkinlikManager(IRepository<Etkinlik> etkinlikRepository, IMapper mapper)
        {
            _etkinlikRepository = etkinlikRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Add(CreateEtkinlikRequest etkinlik)
        {
            var model = _mapper.Map<Etkinlik>(etkinlik);

            await _etkinlikRepository.AddAsync(model);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(int id)
        {
            var getId = await _etkinlikRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
            if (getId == null)
                return new ErrorResult("Etkinlik bulunamadı!");

            await _etkinlikRepository.DeleteAsync(getId);
            return new SuccessResult("Etkinlik kayıdı eklendi!");
        }

        public async Task<bool> Exists(int id)
        {
            var result = await _etkinlikRepository.Table.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task<IDataResult<List<Etkinlik>>> GetAll()
        {
            var result = await _etkinlikRepository.Table.ToListAsync();
            return new SuccessDataResult<List<Etkinlik>>(result);
        }

        public async Task<IDataResult<Etkinlik>> GetById(int id)
        {
            var getId = await _etkinlikRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
            if (getId == null)
                return new ErrorDataResult<Etkinlik>("Etkinlik bulunamadı");
            return new SuccessDataResult<Etkinlik>(getId);
        }

        public async Task<IResult> Update(UpdateEtkinlikRequest etkinlik)
        {
            var getId = await _etkinlikRepository.Table.FirstOrDefaultAsync(x => x.Id == etkinlik.Id);
            if (getId == null)
                return new ErrorDataResult<Etkinlik>("Etkinlik bulunamadı");

            getId.SalonId = etkinlik.SalonId;
            getId.SalonBolumId = etkinlik.SalonBolumId;
            getId.CiftAdi = etkinlik.CiftAdi;
            getId.BaslangicZaman = etkinlik.BaslangicZaman;
            getId.BitisZaman = etkinlik.BitisZaman;
            getId.Paylasim = etkinlik.Paylasim;
            getId.MDate = DateTime.Now;

            await _etkinlikRepository.UpdateAsync(getId);
            return new SuccessResult("Etkinlik kayıdı güncellendi!");
        }
    }
}

using AutoMapper;
using Business.Abstract;
using Business.DTO.EtkinlikIzin;
using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class EtkinlikIzinManager : IEtkinlikIzinService
    {
        private readonly IRepository<EtkinlikIzin> _etkinlikIzinRepository;
        private readonly IMapper _mapper;
        public EtkinlikIzinManager(IRepository<EtkinlikIzin> etkinlikIzinRepository, IMapper mapper)
        {
            _etkinlikIzinRepository = etkinlikIzinRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Add(CreateEtkinlikIzinRequest etkinlikIzin)
        {
            var model = _mapper.Map<EtkinlikIzin>(etkinlikIzin);

            await _etkinlikIzinRepository.AddAsync(model);
            return new SuccessResult("Etkinlik İzin Eklendi!");
        }

        public async Task<IResult> Delete(int id)
        {
            var getId = await _etkinlikIzinRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
            if (getId == null)
                return new ErrorResult("Etkinlik İzin bulunamadı!");

            await _etkinlikIzinRepository.DeleteAsync(getId);
            return new SuccessResult("Etkinlik İzin Silindi!");
        }

        public async Task<bool> Exists(int id)
        {
            var result = await _etkinlikIzinRepository.Table.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task<IDataResult<List<EtkinlikIzin>>> GetAll()
        {
            var result = await _etkinlikIzinRepository.Table.ToListAsync();
            return new SuccessDataResult<List<EtkinlikIzin>>(result);
        }

        public async Task<IDataResult<EtkinlikIzin>> GetById(int id)
        {
            var getId = await _etkinlikIzinRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
            if (getId == null)
                return new ErrorDataResult<EtkinlikIzin>("Etkinlik İzin Id bulunamadı!");
            return new SuccessDataResult<EtkinlikIzin>(getId);
        }

        public async Task<IResult> Update(UpdateEtkinlikIzinRequest etkinlikIzin)
        {
            var getId = await _etkinlikIzinRepository.Table.FirstOrDefaultAsync(x => x.Id == etkinlikIzin.Id);
            if (getId == null)
                return new ErrorDataResult<EtkinlikIzin>("Etkinlik İzin Id bulunamadı!");

            getId.EtkinlikId = etkinlikIzin.EtkinlikId;
            getId.KullaniciId = etkinlikIzin.KullaniciId;
            getId.Goruntuleme = etkinlikIzin.Goruntuleme;
            getId.Indirme = etkinlikIzin.Indirme;

            await _etkinlikIzinRepository.UpdateAsync(getId);
            return new SuccessResult("Etkinlik İzin Güncellendi!");
        }
    }
}

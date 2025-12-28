using AutoMapper;
using Business.Abstract;
using Business.DTO.QRKod;
using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class QRKodManager : IQRKodService
    {
        private readonly IRepository<QRKod> _QRKodRepository;
        private readonly IMapper _mapper;

        public QRKodManager(IRepository<QRKod> QRKodRepository, IMapper mapper)
        {
            _QRKodRepository = QRKodRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Add(CreateQRKodRequest QRKod)
        {
            var model = _mapper.Map<QRKod>(QRKod);

            await _QRKodRepository.AddAsync(model);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(int id)
        {
            var getId = await _QRKodRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
            if (getId == null)
                return new ErrorResult("QRKod  bulunamadı");

            await _QRKodRepository.DeleteAsync(getId);
            return new SuccessResult();
        }

        public async Task<bool> Exists(int id)
        {
            var result = await _QRKodRepository.Table.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task<IDataResult<List<QRKod>>> GetAll()
        {
            var result = await _QRKodRepository.Table.ToListAsync();
            return new SuccessDataResult<List<QRKod>>(result);
        }

        public async Task<IDataResult<QRKod>> GetById(int id)
        {
            var getId = await _QRKodRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
            if (getId == null)
                return new ErrorDataResult<QRKod>("QRKod bulunamadı");
            return new SuccessDataResult<QRKod>(getId);
        }

        public async Task<IResult> Update(UpdateQRKodRequest QRKod)
        {
            var getId = await _QRKodRepository.Table.FirstOrDefaultAsync(x => x.Id == QRKod.Id);
            if (getId == null)
                return new ErrorDataResult<QRKod>("QRKod bulunamadı");

            getId.SalonBolumId = QRKod.SalonBolumId;
            getId.QrData = QRKod.QrData;
            getId.MDate = DateTime.Now;

            await _QRKodRepository.UpdateAsync(getId);
            return new SuccessResult("Kayıt İşlemi başarılı");
        }
    }
}

using Business.Abstract;
using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class KullaniciManager : IKullaniciService
    {
        private readonly IRepository<Kullanici> _KullaniciRepository;

        public KullaniciManager(IRepository<Kullanici> KullaniciRepository)
        {
            _KullaniciRepository = KullaniciRepository;
        }

        public async Task<IResult> Add(Kullanici Kullanici)
        {
            await _KullaniciRepository.AddAsync(Kullanici);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(int id)
        {
            var getId = await _KullaniciRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
            if (getId == null)
                return new ErrorResult("Kullanici  bulunamadı");

            await _KullaniciRepository.DeleteAsync(getId);
            return new SuccessResult();
        }

        public async Task<bool> Exists(int id)
        {
            var result = await _KullaniciRepository.Table.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task<IDataResult<List<Kullanici>>> GetAll()
        {
            var result = await _KullaniciRepository.Table.ToListAsync();
            return new SuccessDataResult<List<Kullanici>>(result);
        }

        public async Task<IDataResult<Kullanici>> GetById(int id)
        {
            var getId = await _KullaniciRepository.Table.FirstOrDefaultAsync(x => x.Id == id);
            if (getId == null)
                return new ErrorDataResult<Kullanici>("Kullanici bulunamadı");
            return new SuccessDataResult<Kullanici>(getId);
        }

        public async Task<IResult> Update(Kullanici Kullanici)
        {
            var getId = await _KullaniciRepository.Table.FirstOrDefaultAsync(x => x.Id == Kullanici.Id);
            if (getId == null)
                return new ErrorDataResult<Kullanici>("Kullanici bulunamadı");

            getId.Email = Kullanici.Email;
            getId.Adi = Kullanici.Adi;
            getId.SifreHash = Kullanici.SifreHash;
            getId.GoogleId = Kullanici.GoogleId;
            getId.Rol = Kullanici.Rol;
            getId.MDate = DateTime.Now;

            await _KullaniciRepository.UpdateAsync(getId);
            return new SuccessResult("Kayıt İşlemi başarılı");
        }
    }
}

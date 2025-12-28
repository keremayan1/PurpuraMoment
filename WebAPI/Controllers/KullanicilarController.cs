using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KullanicilarController : ControllerBase
    {
        private IKullaniciService _KullaniciService;

        public KullanicilarController(IKullaniciService KullaniciService)
        {
            _KullaniciService = KullaniciService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Kullanici Kullanici)
        {
            var result = await _KullaniciService.Add(Kullanici);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Kullanici Kullanici)
        {
            var result = await (_KullaniciService.Update(Kullanici));
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _KullaniciService.Delete(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _KullaniciService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _KullaniciService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

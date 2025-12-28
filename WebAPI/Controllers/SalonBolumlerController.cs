using Business.Abstract;
using Business.DTO.SalonBolum;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalonBolumlerController : ControllerBase
    {
        private ISalonBolumService _SalonBolumService;

        public SalonBolumlerController(ISalonBolumService SalonBolumService)
        {
            _SalonBolumService = SalonBolumService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateSalonBolumRequest SalonBolum)
        {
            var result = await _SalonBolumService.Add(SalonBolum);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSalonBolumRequest SalonBolum)
        {
            var result = await (_SalonBolumService.Update(SalonBolum));
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _SalonBolumService.Delete(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _SalonBolumService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _SalonBolumService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

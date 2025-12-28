using Business.Abstract;
using Business.DTO.Salon;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalonlarController : ControllerBase
    {
        private ISalonService _SalonService;

        public SalonlarController(ISalonService SalonService)
        {
            _SalonService = SalonService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateSalonRequest Salon)
        {
            var result = await _SalonService.Add(Salon);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSalonRequest Salon)
        {
            var result = await (_SalonService.Update(Salon));
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _SalonService.Delete(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _SalonService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _SalonService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

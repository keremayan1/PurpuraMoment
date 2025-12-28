using Business.Abstract;
using Business.DTO.EtkinlikIzin;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EtkinlikIzinlerController : ControllerBase
    {
        private IEtkinlikIzinService _EtkinlikIzinService;

        public EtkinlikIzinlerController(IEtkinlikIzinService EtkinlikIzinService)
        {
            _EtkinlikIzinService = EtkinlikIzinService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateEtkinlikIzinRequest EtkinlikIzin)
        {
            var result = await _EtkinlikIzinService.Add(EtkinlikIzin);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateEtkinlikIzinRequest EtkinlikIzin)
        {
            var result = await (_EtkinlikIzinService.Update(EtkinlikIzin));
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _EtkinlikIzinService.Delete(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _EtkinlikIzinService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _EtkinlikIzinService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

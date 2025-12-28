using Business.Abstract;
using Business.DTO.Etkinlik;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EtkinliklerController : ControllerBase
    {
        private IEtkinlikService _EtkinlikService;

        public EtkinliklerController(IEtkinlikService EtkinlikService)
        {
            _EtkinlikService = EtkinlikService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateEtkinlikRequest Etkinlik)
        {
            var result = await _EtkinlikService.Add(Etkinlik);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateEtkinlikRequest Etkinlik)
        {
            var result = await (_EtkinlikService.Update(Etkinlik));
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _EtkinlikService.Delete(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _EtkinlikService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _EtkinlikService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

using Business.Abstract;
using Business.DTO.Medya;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MedyalarController : ControllerBase
    {
        private IMedyaService _MedyaService;

        public MedyalarController(IMedyaService MedyaService)
        {
            _MedyaService = MedyaService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateMedyaRequest Medya)
        {
            var result = await _MedyaService.Add(Medya);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateMedyaRequest Medya)
        {
            var result = await (_MedyaService.Update(Medya));
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _MedyaService.Delete(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _MedyaService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

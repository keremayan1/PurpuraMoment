using Business.Abstract;
using Business.DTO.QRKod;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QRKodlarController : ControllerBase
    {
        private IQRKodService _QRKodService;

        public QRKodlarController(IQRKodService QRKodService)
        {
            _QRKodService = QRKodService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateQRKodRequest QRKod)
        {
            var result = await _QRKodService.Add(QRKod);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateQRKodRequest QRKod)
        {
            var result = await (_QRKodService.Update(QRKod));
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _QRKodService.Delete(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _QRKodService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _QRKodService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }

}

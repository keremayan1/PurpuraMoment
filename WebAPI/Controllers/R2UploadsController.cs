using Amazon.S3.Model;
using Amazon.S3;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class R2UploadsController : ControllerBase
    {
        private readonly IR2Service _r2;

        public R2UploadsController(IR2Service r2)
        {
            _r2 = r2;
        }

        [HttpPut()]
        public async Task<IActionResult> InitFile(int etkinlikId)
        {
            var result = await _r2.InitFile(etkinlikId);
            if (result.Success == false)
                return BadRequest(result.Message);
            return Ok(result);
        }

    }
}

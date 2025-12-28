using Business.Abstract;
using Business.DTO.SalonPlan;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalonPlanlarController : ControllerBase
    {
        private ISalonPlanService _SalonPlanService;

        public SalonPlanlarController(ISalonPlanService SalonPlanService)
        {
            _SalonPlanService = SalonPlanService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateSalonPlanRequest SalonPlan)
        {
            var result = await _SalonPlanService.Add(SalonPlan);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSalonPlanRequest SalonPlan)
        {
            var result = await (_SalonPlanService.Update(SalonPlan));
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _SalonPlanService.Delete(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _SalonPlanService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _SalonPlanService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

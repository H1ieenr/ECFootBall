using ECFootBall._Service.Interfaces;
using ECFootBall.Dtos.BrandDto;
using ECFootBall.Helpers.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ECFootBall.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedAsync([FromQuery] PaginationParam pagination, [FromQuery] SearchBrandDto dto)
        {
            var result = await _brandService.GetPagedBrandsAsync(pagination, dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandByIdAsync(int id)
        {
            var result = await _brandService.GetBrandByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBrandDto dto)
        {
            var result = await _brandService.Create(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandDto dto)
        {
            var result = await _brandService.Update(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _brandService.Delete(id, "admin");
            return Ok(result);
        }
    }
}

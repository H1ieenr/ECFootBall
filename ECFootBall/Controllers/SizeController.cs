using ECFootBall._Service.Interfaces;
using ECFootBall.Dtos.SizeDto;
using ECFootBall.Helpers.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ECFootBall.Controllers
{
    [Route("api/sizes")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISizeService _sizeService;
        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedAsync([FromQuery] PaginationParam pagination, [FromQuery] SearchSizeDto dto)
        {
            var result = await _sizeService.GetPagedSizesAsync(pagination, dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSizeByIdAsync(int id)
        {
            var result = await _sizeService.GetSizeByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSizeDto dto)
        {
            var result = await _sizeService.Create(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSizeDto dto)
        {
            var result = await _sizeService.Update(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _sizeService.Delete(id, "admin");
            return Ok(result);
        }
    }
}

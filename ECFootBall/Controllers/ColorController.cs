using ECFootBall._Service.Interfaces;
using ECFootBall.Dtos.ColorDto;
using ECFootBall.Helpers.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ECFootBall.Controllers
{
    [Route("api/colors")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;
        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedAsync([FromQuery] PaginationParam pagination, [FromQuery] SearchColorDto dto)
        {
            var result = await _colorService.GetPagedColorsAsync(pagination, dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColorByIdAsync(int id)
        {
            var result = await _colorService.GetColorByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateColorDto dto)
        {
            var result = await _colorService.Create(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateColorDto dto)
        {
            var result = await _colorService.Update(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _colorService.Delete(id, "admin");
            return Ok(result);
        }
    }
}

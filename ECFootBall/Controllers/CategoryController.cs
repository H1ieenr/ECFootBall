using ECFootBall._Service.Interfaces;
using ECFootBall.Dtos.CategoryDto;
using ECFootBall.Helpers.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ECFootBall.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedAsync([FromQuery] PaginationParam pagination, [FromQuery] SearchCategoryDto dto)
        {
            var result = await _categoryService.GetPagedCategoriesAsync(pagination, dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var result = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
        {
            var result = await _categoryService.Create(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDto dto)
        {
            var result = await _categoryService.Update(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.Delete(id, "admin");
            return Ok(result);
        }
    }
}

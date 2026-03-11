using ECFootball.Product.API.Controllers.Base;
using ECFootBall._Service.Interfaces;
using ECFootBall.Dtos.BrandDto;
using ECFootBall.Helpers.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECFootBall.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandController : BaseManagementController
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        [AllowAnonymous]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromForm] CreateBrandDto dto)
        {
            dto.CreateBy = CurrentUserId;
            var result = await _brandService.Create(dto);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromForm] UpdateBrandDto dto)
        {
            dto.UpdateBy = CurrentUserId;
            var result = await _brandService.Update(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _brandService.Delete(id, CurrentUserId);
            return Ok(result);
        }
    }
}

using ECFootball.Product.API._Service.Interfaces;
using ECFootball.Product.API.Controllers.Base;
using ECFootball.Product.API.Dtos.ProductVariantDto;
using ECFootBall.Dtos.ProductVariantDto;
using ECFootBall.Helpers.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECFootball.Product.API.Controllers
{
    [Route("api/productVariant")]
    [ApiController]
    public class ProductVariantController : BaseManagementController
    {
        private IProductVariantService _productVariantService;
        public ProductVariantController(IProductVariantService productVariantService)
        {
            _productVariantService = productVariantService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPagedAsync([FromQuery] PaginationParam pagination, [FromQuery] SearchProductVariantDto dto)
        {
            var result = await _productVariantService.GetPagedProductVariantsAsync(pagination, dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductVariantByIdAsync(int id)
        {
            var result = await _productVariantService.GetProductVariantByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductVariantDto dto)
        {
            var result = await _productVariantService.Create(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductVariantDto dto)
        {
            var result = await _productVariantService.Update(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productVariantService.Delete(id, "admin");
            return Ok(result);
        }

        [HttpPost("Create-Range")]
        public async Task<IActionResult> CreateRange([FromBody] List<CreateProductVariantDto> dtos)
        {
            var result = await _productVariantService.CreateRange(dtos);
            return Ok(result);
        }

        [HttpPut("Update-Range")]
        public async Task<IActionResult> UpdateRange([FromBody] List<UpdateProductVariantDto> dtos)
        {
            var result = await _productVariantService.UpdateRange(dtos);
            return Ok(result);
        }

        [HttpDelete("Delete-Range")]
        public async Task<IActionResult> DeleteRange([FromBody] List<int> ids)
        {
            var result = await _productVariantService.DeleteRange(ids, "admin");
            return Ok(result);
        }
    }
}

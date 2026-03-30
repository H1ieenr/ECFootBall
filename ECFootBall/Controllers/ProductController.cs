using ECFootball.Product.API._Service.Interfaces;
using ECFootball.Product.API.Controllers.Base;
using ECFootball.Product.API.Dtos.ProductDto;
using ECFootBall.Helpers.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECFootball.Product.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : BaseManagementController
    {
        private IProductService _productService;
        public ProductController(IProductService productService) 
        {
            _productService = productService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPagedAsync([FromQuery] PaginationParam pagination, [FromQuery] SearchProductDto dto)
        {
            var result = await _productService.GetPagedProductsAsync(pagination, dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductByIdAsync(string id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductDto dto)
        {
            dto.CreateBy = CurrentUserId;
            var result = await _productService.Create(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateProductDto dto)
        {
            dto.UpdateBy = CurrentUserId;
            var result = await _productService.Update(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _productService.Delete(id, CurrentUserId);
            return Ok(result);
        }

    }
}

using ECFootBall._Service.Interfaces;
using ECFootBall.Dtos.ProductDto;
using Microsoft.AspNetCore.Mvc;

namespace ECFootBall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateStore([FromBody] CreateProductDto dto)
        {
            var result = await _productService.Create(dto);
            return Ok(result);
        }
    }
}

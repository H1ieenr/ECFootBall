using ECFootball.Order.API._Service.Interface;
using ECFootball.Order.API.Controllers.Base;
using ECFootball.Order.API.Dtos.CartDto;
using Microsoft.AspNetCore.Mvc;

namespace ECFootball.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : BaseManagementController
    {
        private ICartService _cartService;
        public CartController(ICartService cartService) 
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCartAsync()
        {
            var result = await _cartService.GetCartAsync(CurrentUserId);
            return Ok(result);
        }

        [HttpPost("add-to-cart")]
        public async Task<IActionResult> AddToCartAsync([FromBody] AddToCartDto dto)
        {
            dto.UserId = CurrentUserId;
            var result = await _cartService.AddToCartAsync(dto);
            return Ok(result);
        }

        [HttpPost("sync")]
        public async Task<IActionResult> SyncCart([FromBody] List<CartItemDto> items)
        {
            var result = await _cartService.SyncCartAsync(CurrentUserId, items);
            return Ok(result);
        }

        [HttpDelete("remove-item/{productId}")]
        public async Task<IActionResult> RemoveFromCartAsync(string productId) 
        {
            var result = await _cartService.RemoveFromCartAsync(CurrentUserId, productId);
            return Ok(result);
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCartAsync() 
        {
            var result = await _cartService.ClearCartAsync(CurrentUserId);
            return Ok(result);
        }
    }
}

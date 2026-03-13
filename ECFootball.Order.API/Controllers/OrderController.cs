using ECFootball.Order.API._Service.Interface;
using ECFootball.Order.API.Controllers.Base;
using ECFootball.Order.API.Dtos.OrderDto;
using ECFootball.Order.API.Helpers.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECFootball.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseManagementController
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService) 
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<OperationResult> CheckoutAsync([FromBody] CheckoutDto dto)
        {
            dto.UserId = CurrentUserId;
            var result = await _orderService.CheckoutAsync(dto);
            return(result);
        }

        [HttpGet("{orderCode}")]
        public async Task<IActionResult> GetOrderDetailAsync(string orderCode)
        {
            var order = await _orderService.GetOrderDetailAsync(orderCode);

            if (order == null)
                return NotFound(new { Message = "No data!" });

            return Ok(order);
        }
    }
}

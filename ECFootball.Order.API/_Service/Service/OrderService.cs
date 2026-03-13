using ECFootball.Order.API._Service.Interface;
using ECFootball.Order.API.Data;
using ECFootball.Order.API.Dtos.OrderDto;
using ECFootball.Order.API.Helpers.Mapper;
using ECFootball.Order.API.Helpers.Utilities;
using ECFootball.Order.API.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace ECFootball.Order.API._Service.Service
{
    public class OrderService : IOrderService
    {
        private ECFootBallOrderDBContext _context;
        private IProductClient _productClient;
        private ICartService _cartService;
        private readonly IPublishEndpoint _publishEndpoint;
        public OrderService(ECFootBallOrderDBContext context, IProductClient productClient, ICartService cartService, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _productClient = productClient;
            _cartService = cartService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<OrderDto> GetOrderDetailAsync(string orderCode)
        {
            return await _context.Orders.AsNoTracking().Where(x => x.OrderCode == orderCode)
                .Select(order => new OrderDto
                 {
                     Id = order.Id,
                     OrderCode = order.OrderCode,
                     TotalAmount = order.TotalAmount,
                     Status = order.Status,
                     CreatedDate = order.CreatedDate,
                     ReceiverName = order.ReceiverName,
                     ShippingAddress = order.ShippingAddress,
                     ReceiverPhone = order.ReceiverPhone,
                     UserId =order.UserId,
                    OrderItemDtos = order.OrderItems.Select(item => new OrderItemDto
                     {
                         Id = item.Id,
                         OrderId = item.OrderId,
                         ProductId = item.ProductId.ToString(), 
                         ProductName = item.ProductName,
                         Quantity = item.Quantity,
                         Price = item.Price,
                         Avatar = item.Avatar
                     }).ToList()
                 })
                 .FirstOrDefaultAsync();
        }

        public async Task<OperationResult> CheckoutAsync(CheckoutDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var cartItems = await _context.CartItems.Where(x => x.Cart.UserId == dto.UserId).ToListAsync();
                if (!cartItems.Any()) return new OperationResult { Success = false, Message = "Cart is empty" };

                ECFootball.Order.API.Models.Order order = dto.MapToEntity();

                decimal totalAmount = 0;
                foreach (var item in cartItems)
                {
                    var product = await _productClient.GetProductByIdAsync(item.ProductId);
                    if (product == null) continue;

                    var orderItem = product.MapToEntity(item, order);

                    order.OrderItems.Add(orderItem);
                    totalAmount += orderItem.Price * orderItem.Quantity;
                }

                order.TotalAmount = totalAmount;

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                await _cartService.ClearCartAsync(order.UserId);

                await transaction.CommitAsync();
                //await InventoryUpdate(order);
                return new OperationResult { Success = true, Message = "Order created successfully", Data = order.OrderCode };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new OperationResult { Success = false, Message = ex.Message };
            }
        }

        //public async Task InventoryUpdate(ECFootball.Order.API.Models.Order order)
        //{
        //    var stockEvent = new OrderCreatedEvent
        //    {
        //        OrderId = order.Id,
        //        Items = order.OrderItems.Select(x => new OrderItemStockDto
        //        {
        //            ProductId = x.ProductId,
        //            Quantity = x.Quantity,
        //            SizeId = x.
        //        }).ToList()
        //    };

        //    await _publishEndpoint.Publish(stockEvent);
        //}
    }
}

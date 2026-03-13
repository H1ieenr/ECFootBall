using ECFootball.Order.API.Dtos.OrderDto;
using ECFootball.Order.API.Dtos.ProductDto;
using ECFootball.Order.API.Models;
using static ECFootball.Order.API.Helpers.Utilities.Utilities;

namespace ECFootball.Order.API.Helpers.Mapper
{
    public static class OrderMappingExtentions
    {
        public static ECFootball.Order.API.Models.Order MapToEntity(this CheckoutDto dto)
        {
            return new ECFootball.Order.API.Models.Order
            {
                Id = Guid.NewGuid(),
                UserId = dto.UserId,
                OrderCode = GenerateOrderCode(),
                ShippingAddress = dto.ShippingAddress,
                ReceiverName = dto.ReceiverName,
                ReceiverPhone = dto.ReceiverPhone,
                Status = OrderStatus.Pending,
                CreatedDate = DateTime.Now,
                OrderItems = new List<OrderItem>()
            };
        }

        public static OrderItem MapToEntity(this ProductDto dto, CartItem item, ECFootball.Order.API.Models.Order order)
        {
            return new OrderItem
            {
                ProductId = item.ProductId,
                ProductName = dto.Name,
                Quantity = item.Quantity,
                Price = (dto.IsPromotion == true && dto.PricePromotion.HasValue)
                                ? dto.PricePromotion.Value
                                : dto.Price,
                Avatar = dto.Avatar,
                Order = order
            };
        }
    }
}

using ECFootball.Product.API.Dtos.OrderDto;
using ECFootBall.Data;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace ECFootball.Product.API._Service.Services
{
    public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
    {
        private readonly ECFootBallDBContext _context;

        public OrderCreatedConsumer(ECFootBallDBContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var message = context.Message;

            foreach (var item in message.Items)
            {
                var variant = await _context.ProductVariants.FirstOrDefaultAsync(v => v.ProductId == item.ProductId
                                           && v.SizeId == item.SizeId
                                           && v.ColorId == item.ColorId);

                if (variant != null)
                {
                    if (variant.StockQuantity >= item.Quantity)
                    {
                        variant.StockQuantity -= item.Quantity;
                    }
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}

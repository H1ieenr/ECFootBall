using ECFootball.Order.API.Dtos.CartDto;
using ECFootball.Order.API.Models;

namespace ECFootball.Order.API.Helpers.Mapper
{
    public static class CartMappingExtentions
    {
        public static CartDto MapToDto(this Cart entity)
        {
            return new CartDto
            {
                CartId = entity.Id,
                LastUpdate = entity.LastUpdate,
                UserId = entity.UserId,
                CartItems = new List<CartItemDto>()
            };
        }
    }
}

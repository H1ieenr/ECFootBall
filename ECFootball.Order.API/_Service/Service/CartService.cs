using ECFootball.Order.API._Service.Interface;
using ECFootball.Order.API.Data;
using ECFootball.Order.API.Dtos.CartDto;
using ECFootball.Order.API.Dtos.ProductDto;
using ECFootball.Order.API.Helpers.Utilities;
using ECFootball.Order.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECFootball.Order.API._Service.Service
{
    public class CartService : ICartService
    {
        private ECFootBallOrderDBContext _context;
        private IProductClient _productClient;
        public CartService(ECFootBallOrderDBContext context, IProductClient productClient) 
        {
            _context = context;
            _productClient = productClient;
        }

        public async Task<OperationResult> AddToCartAsync(AddToCartDto dto)
        {
            try
            {
                var cart = await _context.Carts.FirstOrDefaultAsync(x => x.UserId == dto.UserId);
                if (cart == null)
                {
                    cart = new Cart { UserId = dto.UserId, LastUpdate = DateTime.Now };
                    _context.Carts.Add(cart);
                    await _context.SaveChangesAsync();
                }

                var existingItem = await _context.CartItems.FirstOrDefaultAsync(x => x.CartId == cart.Id && x.ProductId == dto.ProductId);

                if (existingItem != null) existingItem.Quantity += (int)dto.Quantity;
                else
                {
                    if (cart.CartItems == null) cart.CartItems = new List<CartItem>();
                    cart.CartItems.Add(new CartItem
                    {
                        CartId = cart.Id,
                        ProductId = dto.ProductId,
                        Quantity = (int)dto.Quantity
                    });
                }

                cart.LastUpdate = DateTime.Now;
                await _context.SaveChangesAsync();

                return new OperationResult { Success = true, Message = "Added to cart" };
            }
            catch (Exception ex) 
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }
        public async Task<OperationResult> SyncCartAsync(string userId, List<CartItemDto> anonymousItems)
        {
            try
            {
                var cart = await _context.Carts.FirstOrDefaultAsync(x => x.UserId == userId);

                if (cart == null)
                {
                    cart = new Cart { UserId = userId, LastUpdate = DateTime.Now };
                    _context.Carts.Add(cart);
                    await _context.SaveChangesAsync();
                }

                foreach (var anonItem in anonymousItems)
                {
                    var existingItem = cart.CartItems.FirstOrDefault(x => x.ProductId == anonItem.ProductId);

                    if (existingItem != null)
                    {
                        existingItem.Quantity += (int)anonItem.Quantity;
                    }
                    else
                    {
                        cart.CartItems.Add(new CartItem
                        {
                            CartId = cart.Id,
                            ProductId = anonItem.ProductId,
                            Quantity = (int)anonItem.Quantity
                        });
                    }
                }

                cart.LastUpdate = DateTime.Now;
                await _context.SaveChangesAsync();

                return new OperationResult { Success = true, Message = "Cart synchronized successfully!" };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, Message = ex.Message };
            }
        }
        public Task<OperationResult> ClearCartAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> RemoveFromCartAsync(string userId, Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> GetCartAsync(string userId)
        {
            Cart cart = await _context.Carts.Include(x => x.CartItems).FirstOrDefaultAsync(x => x.UserId == userId);

            if (cart == null) return new CartDto();

            CartDto cartDto = new CartDto
            {
                CartId = cart.Id,
                UserId = cart.UserId,
                LastUpdate = cart.LastUpdate,
                CartItems = new List<CartItemDto>()
            };
            var result = new List<CartDto>();

            foreach (var item in cart.CartItems)
            {
                ProductDto product = await _productClient.GetProductByIdAsync(item.ProductId);

                if (product != null)
                {
                    cartDto.CartItems.Add(new CartItemDto
                    {
                        CartId = item.CartId,
                        ProductId = item.ProductId.ToString(),
                        Quantity = item.Quantity,
                        NameProduct = product.Name,
                        Avatar = product.Avatar,
                        Price = product.Price,
                        PricePromotion = product.PricePromotion,
                        IsPromotion = product.IsPromotion,
                        //SizeName = "L",
                        //Color = "Red"
                    });
                }
            }
            return cartDto;
        }
    }
}

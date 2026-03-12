using ECFootball.Order.API._Service.Interface;
using ECFootball.Order.API.Dtos.ProductDto;

namespace ECFootball.Order.API._Service.Service
{
    public class ProductClient : IProductClient
    {
        private readonly HttpClient _httpClient;

        public ProductClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductDto?> GetProductByIdAsync(string productId)
        {
            var response = await _httpClient.GetAsync($"/api/products/{productId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ProductDto>();
            }
            return null;
        }
    }
}

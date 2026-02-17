using ECFootBall._Service.Interfaces;
using ECFootBall.Data;
using ECFootBall.Dtos.ProductDto;
using ECFootBall.Helpers.Mapper;
using ECFootBall.Helpers.Utilities;
using ECFootBall.Models;

namespace ECFootBall._Service.Services
{
    public class ProductService : IProductService
    {
        private ECFootBallDBContext _context;
        public ProductService(ECFootBallDBContext context) 
        {
            _context = context;
        }


        public async Task<OperationResult> Create(CreateProductDto dto)
        {
            try
            {
                var product = dto.MapToEntity();


                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, Message = "Create Success" };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Success = false, Message = ex.Message };
            }
        }

        public Task<OperationResult> Delete(string ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<PaginationUtility<ProductDto>> GetListProduct(PaginationParam pagination, SearchProductDto dto, bool isPaging = true)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProduct(string ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(UpdateProductDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

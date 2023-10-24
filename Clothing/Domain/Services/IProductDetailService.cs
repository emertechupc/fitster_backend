using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Clothing.Domain.Services.Communication;

namespace Fitster.API.Clothing.Domain.Services;

public interface IProductDetailService
{
    Task<IEnumerable<ProductDetail>> ListAsync();
    Task<IEnumerable<ProductDetail>> ListByProductIdAsync(int productId);
    Task<ProductDetailResponse> SaveAsync(ProductDetail productDetail);
    Task<ProductDetailResponse> GetByIdAsync(int id);
    Task<ProductDetailResponse> UpdateAsync(int id, ProductDetail productDetail);
    Task<ProductDetailResponse> DeleteAsync(int id);
}
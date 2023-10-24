using Fitster.API.Clothing.Domain.Models;

namespace Fitster.API.Clothing.Domain.Repositories;

public interface IProductDetailRepository
{
    Task<IEnumerable<ProductDetail>> ListAsync();
    Task<IEnumerable<ProductDetail>> ListByProductIdAsync(int productId);
    Task<ProductDetail> FindByIdAsync(int id);
    Task AddAsync(ProductDetail productDetail);
    void Update(ProductDetail productDetail);
    void Remove(ProductDetail productDetail);
}
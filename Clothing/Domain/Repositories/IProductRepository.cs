using Fitster.API.Clothing.Domain.Models;

namespace Fitster.API.Clothing.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> ListAsync();
    Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId);
    Task<IEnumerable<Product>> ListByTypeIdAsync(int typeId);
    Task<IEnumerable<Product>> ListByBrandIdAsync(int brandId);
    Task<IEnumerable<Product>> ListByCategoryIdAndTypeIdAsync(int categoryId, int typeId);
    Task<IEnumerable<Product>> ListByCategoryIdAndBrandIdAsync(int categoryId, int brandId);
    Task<IEnumerable<Product>> ListByTypeIdAndBrandIdAsync(int typeId, int brandId);
    Task<IEnumerable<Product>> ListByCategoryIdAndTypeIdAndBrandIdAsync(int categoryId, int typeId, int brandId);
    Task<Product> FindByIdAsync(int id);
    Task AddAsync(Product product);
    void Update(Product product);
    void Remove(Product product);
}

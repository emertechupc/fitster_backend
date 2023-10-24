using Fitster.API.Clothing.Domain.Models;

namespace Fitster.API.Clothing.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> ListAsync();
    Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId);
    Task<IEnumerable<Product>> ListByGenderIdAsync(int genderId);
    Task<IEnumerable<Product>> ListByBrandIdAsync(int brandId);
    Task<IEnumerable<Product>> ListByCategoryIdAndGenderIdAsync(int categoryId, int genderId);
    Task<IEnumerable<Product>> ListByCategoryIdAndBrandIdAsync(int categoryId, int brandId);
    Task<IEnumerable<Product>> ListByGenderIdAndBrandIdAsync(int genderId, int brandId);
    Task<IEnumerable<Product>> ListByCategoryIdAndGenderIdAndBrandIdAsync(int categoryId, int genderId, int brandId);
    Task<Product> FindByIdAsync(int id);
    Task AddAsync(Product product);
    void Update(Product product);
    void Remove(Product product);
}

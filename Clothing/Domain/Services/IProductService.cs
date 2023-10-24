using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Clothing.Domain.Services;
using Fitster.API.Clothing.Domain.Services.Communication;

namespace Fitster.API.Clothing.Domain.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> ListAsync();
    Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId);
    Task<IEnumerable<Product>> ListByGenderIdAsync(int genderId);
    Task<IEnumerable<Product>> ListByBrandIdAsync(int brandId);
    Task<IEnumerable<Product>> ListByCategoryIdAndGenderIdAsync(int categoryId, int genderId);
    Task<IEnumerable<Product>> ListByCategoryIdAndBrandIdAsync(int categoryId, int brandId);
    Task<IEnumerable<Product>> ListByGenderIdAndBrandIdAsync(int genderId, int brandId);
    Task<IEnumerable<Product>> ListByCategoryIdAndGenderIdAndBrandIdAsync(int categoryId, int genderId, int brandId);
    Task<ProductResponse> GetById(int id);
    Task<ProductResponse> SaveAsync(Product product);
    Task<ProductResponse> UpdateAsync(int id, Product product);
    Task<ProductResponse> DeleteAsync(int id);
}
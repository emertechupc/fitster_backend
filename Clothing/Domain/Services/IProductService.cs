using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Clothing.Domain.Services;
using Fitster.API.Clothing.Domain.Services.Communication;

namespace Fitster.API.Clothing.Domain.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> ListAsync();
    Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId);
    Task<IEnumerable<Product>> ListByTypeIdAsync(int typeId);
    Task<IEnumerable<Product>> ListByBrandIdAsync(int brandId);
    Task<IEnumerable<Product>> ListByCategoryIdAndTypeIdAsync(int categoryId, int typeId);
    Task<IEnumerable<Product>> ListByCategoryIdAndBrandIdAsync(int categoryId, int brandId);
    Task<IEnumerable<Product>> ListByTypeIdAndBrandIdAsync(int typeId, int brandId);
    Task<IEnumerable<Product>> ListByCategoryIdAndTypeIdAndBrandIdAsync(int categoryId, int typeId, int brandId);
    Task<ProductResponse> GetById(int id);
    Task<ProductResponse> SaveAsync(Product product);
    Task<ProductResponse> UpdateAsync(int id, Product product);
    Task<ProductResponse> DeleteAsync(int id);
}
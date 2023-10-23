using Fitster.API.Clothing.Domain.Repositories;
using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Clothing.Domain.Services;
using Fitster.API.Clothing.Domain.Services.Communication;
using Fitster.API.Shared.Domain.Repositories;

namespace Fitster.API.Reports.Services;

public class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _productRepository.ListAsync();
    }

    public async Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId)
    {
        return await _productRepository.ListByCategoryIdAsync(categoryId);
    }

    public async Task<IEnumerable<Product>> ListByTypeIdAsync(int typeId)
    {
        return await _productRepository.ListByTypeIdAsync(typeId);
    }

    public async Task<IEnumerable<Product>> ListByBrandIdAsync(int brandId)
    {
        return await _productRepository.ListByBrandIdAsync(brandId);
    }

    public async Task<IEnumerable<Product>> ListByCategoryIdAndTypeIdAsync(int categoryId, int typeId)
    {
        return await _productRepository.ListByCategoryIdAndTypeIdAsync(categoryId, typeId);
    }

    public async Task<IEnumerable<Product>> ListByCategoryIdAndBrandIdAsync(int categoryId, int brandId)
    {
        return await _productRepository.ListByCategoryIdAndBrandIdAsync(categoryId, brandId);
    }

    public async Task<IEnumerable<Product>> ListByTypeIdAndBrandIdAsync(int typeId, int brandId)
    {
        return await _productRepository.ListByTypeIdAndBrandIdAsync(typeId, brandId);
    }

    public async Task<IEnumerable<Product>> ListByCategoryIdAndTypeIdAndBrandIdAsync(int categoryId, int typeId, int brandId)
    {
        return await _productRepository.ListByCategoryIdAndTypeIdAndBrandIdAsync(categoryId, typeId, brandId);
    }

    public async Task<ProductResponse> GetById(int id)
    {
        var existingProduct = await _productRepository.FindByIdAsync(id);

        if (existingProduct == null)
            return new ProductResponse("Product not found.");

        return new ProductResponse(existingProduct);
    }

    public async Task<ProductResponse> SaveAsync(Product product)
    {
        try
        {
            await _productRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return new ProductResponse(product);
        }
        catch (Exception ex)
        {
            return new ProductResponse($"An error occurred when saving the product: {ex.Message}");
        }
    }

    public async Task<ProductResponse> UpdateAsync(int id, Product product)
    {
        var existingProduct = await _productRepository.FindByIdAsync(id);

        if (existingProduct == null)
            return new ProductResponse("Product not found.");

        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.Rating = product.Rating;
        existingProduct.CategoryId = product.CategoryId;
        existingProduct.TypeId = product.TypeId;
        existingProduct.BrandId = product.BrandId;

        try
        {
            _productRepository.Update(existingProduct);
            await _unitOfWork.CompleteAsync();

            return new ProductResponse(existingProduct);
        }
        catch (Exception ex)
        {
            return new ProductResponse($"An error occurred when updating the product: {ex.Message}");
        }
    }

    public async Task<ProductResponse> DeleteAsync(int id)
    {
        var existingProduct = await _productRepository.FindByIdAsync(id);

        if (existingProduct == null)
            return new ProductResponse("Product not found.");

        try
        {
            _productRepository.Remove(existingProduct);
            await _unitOfWork.CompleteAsync();

            return new ProductResponse(existingProduct);
        }
        catch (Exception ex)
        {
            return new ProductResponse($"An error occurred when deleting the product: {ex.Message}");
        }
    }
}
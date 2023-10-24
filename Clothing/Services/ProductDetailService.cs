using Fitster.API.Clothing.Domain.Repositories;
using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Clothing.Domain.Services;
using Fitster.API.Clothing.Domain.Services.Communication;
using Fitster.API.Shared.Domain.Repositories;
namespace Fitster.API.Clothing.Services;

public class ProductDetailService: IProductDetailService
{
    private readonly IProductDetailRepository _productDetailRepository;
    private readonly IUnitOfWork _unitOfWork;
    public ProductDetailService(IProductDetailRepository productDetailRepository, IUnitOfWork unitOfWork)
    {
        _productDetailRepository = productDetailRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProductDetail>> ListAsync()
    {
        return await _productDetailRepository.ListAsync();
    }

    public async Task<IEnumerable<ProductDetail>> ListByProductIdAsync(int productId)
    {
        return await _productDetailRepository.ListByProductIdAsync(productId);
    }

    public async Task<ProductDetailResponse> SaveAsync(ProductDetail productDetail)
    {
        try
        {
            await _productDetailRepository.AddAsync(productDetail);
            await _unitOfWork.CompleteAsync();

            return new ProductDetailResponse(productDetail);
        }
        catch (Exception ex)
        {
            return new ProductDetailResponse($"An error occurred when saving the product detail: {ex.Message}");
        }
    }

    public async Task<ProductDetailResponse> GetByIdAsync(int id)
    {
        var existingProductDetail = await _productDetailRepository.FindByIdAsync(id);

        if (existingProductDetail == null)
            return new ProductDetailResponse("Product detail not found.");

        return new ProductDetailResponse(existingProductDetail);
    }

    public async Task<ProductDetailResponse> UpdateAsync(int id, ProductDetail productDetail)
    {
        var existingProductDetail = await _productDetailRepository.FindByIdAsync(id);

        if (existingProductDetail == null)
            return new ProductDetailResponse("Product detail not found.");

        existingProductDetail.Image  = productDetail.Image;
        existingProductDetail.Model3d = productDetail.Model3d;
        existingProductDetail.Price = productDetail.Price;
        existingProductDetail.Size = productDetail.Size;
        existingProductDetail.Stock = productDetail.Stock;

        try
        {
            _productDetailRepository.Update(existingProductDetail);
            await _unitOfWork.CompleteAsync();

            return new ProductDetailResponse(existingProductDetail);
        }
        catch (Exception ex)
        {
            return new ProductDetailResponse($"An error occurred when updating the product detail: {ex.Message}");
        }
    }

    public async Task<ProductDetailResponse> DeleteAsync(int id)
    {
        var existingProductDetail = await _productDetailRepository.FindByIdAsync(id);

        if (existingProductDetail == null)
            return new ProductDetailResponse("Product detail not found.");

        try
        {
            _productDetailRepository.Remove(existingProductDetail);
            await _unitOfWork.CompleteAsync();

            return new ProductDetailResponse(existingProductDetail);
        }
        catch (Exception ex)
        {
            return new ProductDetailResponse($"An error occurred when deleting the product detail: {ex.Message}");
        }
    }
}
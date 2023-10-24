using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Clothing.Domain.Repositories;
using Fitster.API.Shared.Persistence.Contexts;
using Fitster.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fitster.API.Clothing.Persistence.Repositories;

public class ProductDetailRepository: BaseRepository, IProductDetailRepository
{
    public ProductDetailRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ProductDetail>> ListAsync()
    {
        return await _context.ProductDetails.ToListAsync();
    }

    public async Task<IEnumerable<ProductDetail>> ListByProductIdAsync(int productId)
    {
        return await _context.ProductDetails
            .Where(p => p.ProductId == productId)
            .ToListAsync();
    }

    public async Task<ProductDetail> FindByIdAsync(int id)
    {
        return await _context.ProductDetails.FindAsync(id);
    }

    public async Task AddAsync(ProductDetail productDetail)
    {
        await _context.ProductDetails.AddAsync(productDetail);
    }

    public void Update(ProductDetail productDetail)
    {
        _context.ProductDetails.Update(productDetail);
    }

    public void Remove(ProductDetail productDetail)
    {
        _context.ProductDetails.Remove(productDetail);
    }
}
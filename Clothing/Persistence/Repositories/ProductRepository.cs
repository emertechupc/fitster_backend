using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Clothing.Domain.Repositories;
using Fitster.API.Shared.Persistence.Contexts;
using Fitster.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fitster.API.Clothing.Persistence.Repositories;

public class ProductRepository: BaseRepository, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task<Product> FindByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId)
    {
        return await _context.Products
            .Where(p => p.CategoryId == categoryId)
            .Include(p => p.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> ListByGenderIdAsync(int genderId)
    {
        return await _context.Products
            .Where(p => p.GenderId == genderId)
            .Include(p => p.Gender)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> ListByBrandIdAsync(int brandId)
    {
        return await _context.Products
            .Where(p => p.BrandId == brandId)
            .Include(p => p.Brand)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> ListByCategoryIdAndGenderIdAsync(int categoryId, int genderId)
    {
        return await _context.Products
            .Where(p => p.CategoryId == categoryId && p.GenderId == genderId)
            .Include(p => p.Category)
            .Include(p => p.Gender)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> ListByCategoryIdAndBrandIdAsync(int categoryId, int brandId)
    {
        return await _context.Products
            .Where(p => p.CategoryId == categoryId && p.BrandId == brandId)
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> ListByGenderIdAndBrandIdAsync(int genderId, int brandId)
    {
        return await _context.Products
            .Where(p => p.GenderId == genderId && p.BrandId == brandId)
            .Include(p => p.Gender)
            .Include(p => p.Brand)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> ListByCategoryIdAndGenderIdAndBrandIdAsync(int categoryId, int genderId, int brandId)
    {
        return await _context.Products
            .Where(p => p.CategoryId == categoryId && p.GenderId == genderId && p.BrandId == brandId)
            .Include(p => p.Category)
            .Include(p => p.Gender)
            .Include(p => p.Brand)
            .ToListAsync();
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public void Remove(Product product)
    {
        _context.Products.Remove(product);
    }
}
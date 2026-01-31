using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.DTOs.Products;
using ProductApi.Models;
using ProductApi.Services.Interfaces;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductResponseDto>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    ProductCode = p.ProductCode,
                    Manufacturer = p.Manufacturer,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name
                })
                .ToListAsync();
        }

        public async Task CreateAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                ProductCode = dto.ProductCode,
                Manufacturer = dto.Manufacturer,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price,
                CategoryId = dto.CategoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _context.Products.FindAsync(id)
                ?? throw new Exception("Product not found");

            product.Name = dto.Name;
            product.ProductCode = dto.ProductCode;
            product.Manufacturer = dto.Manufacturer;
            product.Description = dto.Description;
            product.ImageUrl = dto.ImageUrl;
            product.Price = dto.Price;
            product.CategoryId = dto.CategoryId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id)
                ?? throw new Exception("Product not found");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}

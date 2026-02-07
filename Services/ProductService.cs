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
                    CategoryName = p.Category.Name,
                    SubCategoryId = p.SubCategoryId

                })
                .ToListAsync();
        }

        public async Task CreateAsync(CreateProductDto dto)
        {
            var name = dto.Name.Trim();

            var exists = await _context.Products.AnyAsync(p =>
                p.CategoryId == dto.CategoryId &&
                p.SubCategoryId == dto.SubCategoryId &&
                p.Name.ToLower() == name.ToLower());

            if (exists)
                throw new InvalidOperationException(
                    "Product already exists in this category and sub-category");

            var codeExists = await _context.Products.AnyAsync(p =>
                p.ProductCode.ToLower() == dto.ProductCode.Trim().ToLower());

            if (codeExists)
                throw new InvalidOperationException("Product code already exists");

            var product = new Product
            {
                Name = name,
                ProductCode = dto.ProductCode.Trim(),
                Manufacturer = dto.Manufacturer.Trim(),
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                SubCategoryId = dto.SubCategoryId // ✅ FIX
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }



        public async Task UpdateAsync(int id, CreateProductDto dto)
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
            product.SubCategoryId = dto.SubCategoryId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id)
                ?? throw new Exception("Product not found");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.DTOs.Dashboard;

namespace ProductApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Dashboard stats
        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            return Ok(new
            {
                products = await _context.Products.CountAsync(),
                categories = await _context.Categories.CountAsync(),
                users = await _context.Users.CountAsync(),
                franchises = await _context.Franchises.CountAsync()
            });
        }

        // ✅ Dashboard products
        [HttpGet("products")]
        public async Task<IActionResult> GetDashboardProducts()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Select(p => new DashboardProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.Category.Name
                })
                .ToListAsync();

            return Ok(products);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Services.Interfaces;

namespace ProductApi.Services
{
    public class ReportService : IReportService
    {
        private readonly AppDbContext _context;

        public ReportService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetSummaryAsync()
        {
            return new
            {
                TotalUsers = await _context.Users.CountAsync(),
                TotalProducts = await _context.Products.CountAsync(),
                TotalCategories = await _context.Categories.CountAsync(),
                TotalFranchises = await _context.Franchises.CountAsync()
            };
        }
    }
}

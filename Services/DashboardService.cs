using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.DTOs.Dashboard;

public class DashboardService : IDashboardService
{
    private readonly AppDbContext _context;

    public DashboardService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<DashboardStatsDto> GetStatsAsync()
    {
        return new DashboardStatsDto
        {
            Products = await _context.Products.CountAsync(),
            Categories = await _context.Categories.CountAsync(),
            Users = await _context.Users.CountAsync(),
            Franchises = await _context.Franchises.CountAsync()
        };
    }
}

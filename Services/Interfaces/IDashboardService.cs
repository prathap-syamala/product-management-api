using ProductApi.DTOs.Dashboard;

public interface IDashboardService
{
    Task<DashboardStatsDto> GetStatsAsync();
}

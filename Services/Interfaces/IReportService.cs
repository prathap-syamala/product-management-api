namespace ProductApi.Services.Interfaces
{
    public interface IReportService
    {
        Task<object> GetSummaryAsync();
    }
}

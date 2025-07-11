using BioGenom.DB.Entities;

namespace BioGenom.DB.Repositories
{
    public interface IReportRepository
    {
        Task<Report?> GetLatestReportAsync();
        Task SaveReportAsync(Report newReport);
    }
}
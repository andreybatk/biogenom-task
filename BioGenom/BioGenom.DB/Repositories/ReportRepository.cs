using BioGenom.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace BioGenom.DB.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить последний (и единственный) отчёт
        /// </summary>
        public async Task<Report?> GetLatestReportAsync()
        {
            return await _context.Reports
                .Include(r => r.DailyIntakes)
                .Include(r => r.NewDailyIntakes)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Удалить старый и сохранить новый отчёт
        /// </summary>
        public async Task SaveReportAsync(Report newReport)
        {
            var oldReports = await _context.Reports.ToListAsync();
            _context.Reports.RemoveRange(oldReports);

            newReport.CreatedAt = DateTime.UtcNow;
            _context.Reports.Add(newReport);

            await _context.SaveChangesAsync();
        }
    }
}

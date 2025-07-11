using BioGenom.API.Contracts;
using BioGenom.DB.Entities;

namespace BioGenom.API.Mappers
{
    public static class ReportMapper
    {
        public static ReportResponse ToResponse(Report report)
        {
            return new ReportResponse
            {
                Id = report.Id,
                CreatedAt = report.CreatedAt,
                DailyIntakes = report.DailyIntakes.Select(di => new DailyIntakeResponse
                {
                    Id = di.Id,
                    Name = di.Name,
                    Source = di.Source,
                    Value = di.Value,
                    Norm = di.Norm
                }).ToList(),
                NewDailyIntakes = report.NewDailyIntakes.Select(ndi => new NewDailyIntakeResponse
                {
                    Id = ndi.Id,
                    Name = ndi.Name,
                    Source = ndi.Source,
                    Value = ndi.Value,
                    ValueFromSet = ndi.ValueFromSet,
                    ValueFromFood = ndi.ValueFromFood
                }).ToList()
            };
        }

        public static Report ToEntity(ReportRequest request)
        {
            return new Report
            {
                CreatedAt = DateTime.UtcNow,
                DailyIntakes = request.DailyIntakes.Select(d => new DailyIntake
                {
                    Name = d.Name,
                    Source = d.Source,
                    Value = d.Value,
                    Norm = d.Norm
                }).ToList(),
                NewDailyIntakes = request.NewDailyIntakes.Select(n => new NewDailyIntake
                {
                    Name = n.Name,
                    Source = n.Source,
                    Value = n.Value,
                    ValueFromSet = n.ValueFromSet,
                    ValueFromFood = n.ValueFromFood
                }).ToList()
            };
        }
    }

}

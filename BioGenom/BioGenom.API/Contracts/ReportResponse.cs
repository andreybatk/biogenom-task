namespace BioGenom.API.Contracts
{
    public class ReportResponse
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<DailyIntakeResponse> DailyIntakes { get; set; } = new();
        public List<NewDailyIntakeResponse> NewDailyIntakes { get; set; } = new();
    }
}
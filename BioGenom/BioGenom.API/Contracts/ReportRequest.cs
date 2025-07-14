namespace BioGenom.API.Contracts
{
    public class ReportRequest
    {
        public PersonalizedSetRequest? PersonalizedSet { get; set; }
        public List<DailyIntakeRequest> DailyIntakes { get; set; } = [];
        public List<NewDailyIntakeRequest> NewDailyIntakes { get; set; } = [];
    }
}
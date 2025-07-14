namespace BioGenom.DB.Entities
{
    public class Report
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public PersonalizedSet? PersonalizedSet { get; set; }

        public List<DailyIntake> DailyIntakes { get; set; } = [];
        public List<NewDailyIntake> NewDailyIntakes { get; set; } = [];
    }
}
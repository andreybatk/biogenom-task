namespace BioGenom.DB.Entities
{
    public class PersonalizedSet
    {
        public Guid Id { get; set; }

        public Guid ReportId { get; set; }
        public Report Report { get; set; } = null!;

        public List<PersonalizedItem> Items { get; set; } = [];
    }
}
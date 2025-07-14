namespace BioGenom.DB.Entities
{
    public class PersonalizedItem
    {
        public Guid Id { get; set; }
        public Guid PersonalizedSetId { get; set; }
        public PersonalizedSet PersonalizedSet { get; set; } = null!;

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int? AlternativesCount { get; set; }
    }
}
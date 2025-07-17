namespace BioGenom.DB.Entities
{
    public class PersonalizedItem
    {
        public Guid Id { get; set; }

        public Guid PersonalizedSetId { get; set; }
        public PersonalizedSet PersonalizedSet { get; set; } = null!;

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int? AlternativesCount { get; set; }
    }
}
namespace BioGenom.API.Contracts
{
    public class PersonalizedItemResponse
    {
        public Guid Id { get; set; }

        public ProductResponse? Product { get; set; }
        public int? AlternativesCount { get; set; }
    }
}

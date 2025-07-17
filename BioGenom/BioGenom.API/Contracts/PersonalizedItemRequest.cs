namespace BioGenom.API.Contracts
{
    public class PersonalizedItemRequest
    {
        public Guid ProductId { get; set; }
        public int? AlternativesCount { get; set; }
    }
}
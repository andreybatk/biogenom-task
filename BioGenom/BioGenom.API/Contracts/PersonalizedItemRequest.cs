namespace BioGenom.API.Contracts
{
    public class PersonalizedItemRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int? AlternativesCount { get; set; }
    }
}
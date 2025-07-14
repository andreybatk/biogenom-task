namespace BioGenom.API.Contracts
{
    public class PersonalizedSetRequest
    {
        public List<PersonalizedItemRequest> Items { get; set; } = [];
    }
}
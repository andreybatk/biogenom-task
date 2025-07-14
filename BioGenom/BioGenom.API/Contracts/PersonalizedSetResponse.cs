namespace BioGenom.API.Contracts
{
    public class PersonalizedSetResponse
    {
        public Guid Id { get; set; }
        public List<PersonalizedItemResponse> Items { get; set; } = [];
    }
}

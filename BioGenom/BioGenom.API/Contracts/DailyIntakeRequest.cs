namespace BioGenom.API.Contracts
{
    public class DailyIntakeRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public float Value { get; set; }
        public float Norm { get; set; }
    }
}
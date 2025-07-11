namespace BioGenom.API.Contracts
{
    public class NewDailyIntakeRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public float Value { get; set; }
        public float ValueFromSet { get; set; }
        public float ValueFromFood { get; set; }
        public float Norm { get; set; }
    }
}
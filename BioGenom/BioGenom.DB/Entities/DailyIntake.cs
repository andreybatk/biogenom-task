namespace BioGenom.DB.Entities
{
    public class DailyIntake
    {
        public Guid Id { get; set; }

        public Guid ReportId { get; set; }
        public Report Report { get; set; } = null!;

        /// <summary>
        /// Продукт
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Витамин в продукте
        /// </summary>
        public string Source { get; set; } = string.Empty;
        /// <summary>
        /// Текущее потребление
        /// </summary>
        public float Value { get; set; }
        /// <summary>
        /// Норма потребления
        /// </summary>
        public float Norm { get; set; }
    }
}
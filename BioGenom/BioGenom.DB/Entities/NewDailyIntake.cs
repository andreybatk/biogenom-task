namespace BioGenom.DB.Entities
{
    public class NewDailyIntake
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
        /// Потребление из персонального набора
        /// </summary>
        public float ValueFromSet { get; set; }
        /// <summary>
        /// Потребление из питания
        /// </summary>
        public float ValueFromFood { get; set; }
    }
}

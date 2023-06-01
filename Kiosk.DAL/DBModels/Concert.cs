namespace Kiosk.DAL.DBModels
{
    /// <summary>
    ///  Concert Entity
    /// </summary>
    public class Concert
    {
        /// <summary>
        /// Concert Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Show Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Max Capacity of Concert.
        /// </summary>
        public int MaxCapacity { get; set; }

        /// <summary>
        /// Performance date and time.
        /// </summary>
        public DateTime PerformanceDateTime { get; set; }

        /// <summary>
        /// Represent the available capacity.
        /// </summary>
        public int AvailableCapacity { get; set; }

        /// <summary>
        /// Is Concert Active or not.
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Each Ticket price.
        /// </summary>
        public double Price { get; set; }
    }
}
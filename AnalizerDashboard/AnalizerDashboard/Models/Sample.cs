namespace AnalizerDashboard.Models
{
    public class Sample : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Result { get; set; }

        /* EF Relations */
        public Analist? Analist { get; set; }
        public Guid AnalistId { get; set; }
    }
}

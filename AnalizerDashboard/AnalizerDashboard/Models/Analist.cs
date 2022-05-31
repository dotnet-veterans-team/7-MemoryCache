namespace AnalizerDashboard.Models
{
    public class Analist : EntityBase
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public ICollection<Sample> Samples { get; set; }

    }
}

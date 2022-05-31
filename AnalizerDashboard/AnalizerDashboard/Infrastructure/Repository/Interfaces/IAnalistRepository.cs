using AnalizerDashboard.Models;

namespace AnalizerDashboard.Infrastructure.Repository.Interfaces
{
    public interface IAnalistRepository : IRepository<Analist>
    {
        Analist GetAnalist(Guid id);
    }
}

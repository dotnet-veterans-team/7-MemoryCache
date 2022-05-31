using AnalizerDashboard.Infrastructure.Repository.Interfaces;
using AnalizerDashboard.Models;

namespace AnalizerDashboard.Infrastructure.Repository
{
    public class SampleRepository : Repository<Sample>, ISampleRepository
    {
        private readonly AnalizerDbContext _context;

        public SampleRepository(AnalizerDbContext context) : base(context) => _context = context;
    }
}

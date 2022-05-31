using AnalizerDashboard.Infrastructure.Repository.Interfaces;
using AnalizerDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace AnalizerDashboard.Infrastructure.Repository
{
    public class AnalistRepository : Repository<Analist>, IAnalistRepository
    {
        private readonly AnalizerDbContext _context;

        public AnalistRepository(AnalizerDbContext context) : base(context) => _context = context;

        public  Analist GetAnalist(Guid id)
        {
            return _context.Analist.AsNoTracking().Where(y =>y.Id == id)
                                                  .Include(x => x.Samples)
                                                  .Select(s => new Analist
                                                  {
                                                    CreatedAt = s.CreatedAt,
                                                    Id = s.Id,
                                                    Name = s.Name,
                                                    Role = s.Role,
                                                    Samples = s.Samples,                                                            
                                                  }).First();
        }
    }
}

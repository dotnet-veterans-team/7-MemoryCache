using AnalizerDashboard.Infrastructure.Repository.Interfaces;
using AnalizerDashboard.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AnalizerDashboard.Infrastructure.Repository;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
{
    protected readonly AnalizerDbContext Db;
    protected readonly DbSet<TEntity> DbSet;
    protected Repository(AnalizerDbContext db)
    {
        Db = db;
        DbSet = db.Set<TEntity>();
    }

    public IUnitOfWork UnitOfWork => Db;
    public virtual async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.AsNoTrackingWithIdentityResolution().Where(predicate).ToListAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task<TEntity> GetById(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual void Add(TEntity entity)
    {
        DbSet.Add(entity);
        Db.SaveChanges();
    }

    public virtual void Add(IEnumerable<TEntity> entities)
    {
        DbSet.AddRange(entities);
        Db.SaveChanges();
    }

    public virtual void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public virtual void Remove(Guid id)
    {
        DbSet.Remove(new TEntity { Id = id });
    }

    public virtual void Remove(IEnumerable<TEntity> entities)
    {
        DbSet.RemoveRange(entities);
    }

    private bool _disposed = false;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
                Db?.Dispose();

            _disposed = true;
        }
    }
}

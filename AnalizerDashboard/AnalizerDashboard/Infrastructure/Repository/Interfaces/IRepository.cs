using AnalizerDashboard.Models;
using System.Linq.Expressions;

namespace AnalizerDashboard.Infrastructure.Repository.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : EntityBase
{
    IUnitOfWork UnitOfWork { get; }
    void Add(TEntity entity);
    void Add(IEnumerable<TEntity> entities);
    Task<TEntity> GetById(Guid id);
    Task<IEnumerable<TEntity>> GetAll();
    void Update(TEntity entity);
    void Remove(Guid id);
    void Remove(IEnumerable<TEntity> entities);
    Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
}


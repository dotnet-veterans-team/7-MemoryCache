namespace AnalizerDashboard.Infrastructure.Repository.Interfaces;
public interface IUnitOfWork
{
    Task<bool> Commit();
    bool Rollback();
}


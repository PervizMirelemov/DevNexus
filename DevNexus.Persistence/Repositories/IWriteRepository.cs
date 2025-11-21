namespace DevNexus.Persistence.Repositories;

public interface IWriteRepository<TEntity, TId>
    where TEntity : class
{
    Task CreateAsync(TEntity entity);
    Task SaveChangesAsync();
}
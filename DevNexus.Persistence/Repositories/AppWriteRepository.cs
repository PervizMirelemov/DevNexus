using DevNexus.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevNexus.Persistence.Repositories;

public class AppWriteRepository<TEntity, TId> : IWriteRepository<TEntity, TId>
    where TEntity : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _set;

    public AppWriteRepository(AppDbContext context)
    {
        _context = context;
        _set = _context.Set<TEntity>();
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _set.AddAsync(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
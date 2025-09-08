using BillPayment.Infrastructure.Ports;
using Microsoft.EntityFrameworkCore;
using BillPayment.Domain.Entities;
using BillPayment.Infrastructure.Context;

namespace BillPayment.Infrastructure.Adapters;

public sealed class GenericRepository<T>(ApplicationContext context) : IGenericRepository<T> where T : DomainEntity
{
    readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id) ?? throw new ArgumentNullException(nameof(id));

    public void Update(T entity) => _dbSet.Update(entity);

    public async Task Save() => await context.SaveChangesAsync();

    public async Task DeleteAsync(T entity)
    {
        if (entity is not null)
        {
            _dbSet.Remove(entity);
        }
    }
}


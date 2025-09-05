using BillPayment.Infrastructure.Ports;
using Microsoft.EntityFrameworkCore;
using BillPayment.Domain.Entities;
using BillPayment.Infrastructure.Context;

namespace BillPayment.Infrastructure.Adapters;

public class GenericRepository<T> : IGenericRepository<T> where T : DomainEntity
{
    readonly ApplicationContext _context;
    readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(BillPayment.Infrastructure.Context));
        _dbSet = context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    { 
         await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id) ?? throw new ArgumentNullException(nameof(id));
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public async Task Save() => await _context.SaveChangesAsync();

    public async Task DeleteAsync(T entity)
    {
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }
}



namespace BillPayment.Infrastructure.Ports;

    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        Task Save();
        Task DeleteAsync(T entity);
    }


using CourseManagerApp.Entities;
using System.Linq.Expressions;

namespace CourseManagerApp.Data.Contracts
{
    internal interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll();

        Task<T> GetByIdAsync(int id);
        T GetById(int id);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<int> Commit();
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate);
        Task<bool> Any(Expression<Func<T, bool>> predicate);
        Task<int> Count(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate);
    }
}

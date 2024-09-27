using CourseManagerApp.Business.Contracts;
using CourseManagerApp.Data.Contracts;
using CourseManagerApp.Entities;

namespace CourseManagerApp.Business.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

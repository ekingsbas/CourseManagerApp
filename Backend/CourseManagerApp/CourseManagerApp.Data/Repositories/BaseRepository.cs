using CourseManagerApp.Data.Contracts;
using CourseManagerApp.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CourseManagerApp.Data.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext _context;

        public BaseRepository()
        {
        }

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public void Error(string message)
        {
            throw new Exception(message);
        }

        #region Methods

        public virtual Task<int> Commit()
        {
            return _context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                var query = _context.Set<TEntity>().Where(x => x.ID == id);

                return await query.FirstOrDefaultAsync();
            }
            catch (SqlException se)
            {
                throw new Exception($"Error en db/GetByIdAsync, Entity:{typeof(TEntity)}", se);
            }
            catch (Exception e)
            {
                throw;
            }
            
        }

        public virtual TEntity GetById(int id)
        {
            try
            {
                var query = _context.Set<TEntity>().Where(x => x.ID == id);

                return query.FirstOrDefault();
            }
            catch (SqlException se)
            {
                throw new Exception($"Error en db/GetById, Entity:{typeof(TEntity)}", se);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {

            try
            {
                var query = _context.Set<TEntity>().Where(x => true);
                return await query.ToListAsync();
            }
            catch (SqlException se)
            {
                throw new Exception($"Error en db/GetAllAsync, Entity:{typeof(TEntity)}", se);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                var query = _context.Set<TEntity>().Where(x => true);
                return query.ToList();
            }
            catch (SqlException se)
            {
                throw new Exception($"Error en db/GetAll, Entity:{typeof(TEntity)}", se);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (SqlException se)
            {
                throw new Exception($"Error en db/CreateAsync, Entity:{typeof(TEntity)}", se);
            }
            catch (Exception e)
            {
                throw;
            }

        }



        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (SqlException se)
            {
                throw new Exception($"Error en db/UpdateAsync, Entity:{typeof(TEntity)}", se);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            try
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _context.Set<TEntity>().Attach(entity);
                }
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (SqlException se)
            {
                throw new Exception($"Error en db/DeleteAsync, Entity:{typeof(TEntity)}", se);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public virtual async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                if (entity == null)
                {
                    return;
                }

                await DeleteAsync(entity);
            }
            catch (SqlException se)
            {
                throw new Exception($"Error en db/DeleteAsync, Entity:{typeof(TEntity)}", se);
            }
            catch (Exception e)
            {
                throw;
            }

        }



        public virtual async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var query = _context.Set<TEntity>().Where(predicate);
                return await query?.ToListAsync();
            }
            catch (SqlException se)
            {
                throw new Exception($"Error en db/Where, Entity:{typeof(TEntity)}", se);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public virtual async Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var query = _context.Set<TEntity>().Where(predicate);
                return await query?.AnyAsync();
            }
            catch (SqlException se)
            {
                throw new Exception($"Error en db/Any, Entity:{typeof(TEntity)}", se);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var query = _context.Set<TEntity>().Where(predicate);
                return await query?.CountAsync();
            }
            catch (SqlException se)
            {
                throw new Exception($"Error en db/Count, Entity:{typeof(TEntity)}", se);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var query = _context.Set<TEntity>().Where(predicate);
                return await (query?.SingleOrDefaultAsync());
            }
            catch (SqlException se)
            {
                throw new Exception($"Error en db/SingleOrDefault, Entity:{typeof(TEntity)}", se);
            }
            catch (Exception e)
            {
                throw;
            }

        }


        #endregion
    }
}

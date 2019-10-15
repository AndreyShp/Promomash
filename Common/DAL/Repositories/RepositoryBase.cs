using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Promomash.Common.DAL.Repositories.Contracts;

namespace Promomash.Common.DAL.Repositories {
    /// <summary>
    /// Базовый репозиторий абстрагирующий от используемой ORM.
    /// Захотим заменить EF на другую будем менять этот класс (ну и наследников DbContext)
    /// </summary>
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class {
        private readonly DbContext _dbContext;

        protected RepositoryBase(DbContext dbContext) {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public async Task<ICollection<T>> GetAsync(Expression<Func<T, bool>> filter = null) {
            var queryable = GetQueryable(filter);
            return await ToListAsync(queryable);
        }

        /// <inheritdoc />
        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null) {
            var queryable = GetQueryable(filter);
            return await queryable.FirstOrDefaultAsync();
        }

        /// <inheritdoc />
        public async Task<T> AddAsync(T entity) {
            var result = await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        /// <summary>
        /// Формирует запрос на выборку
        /// </summary>
        /// <param name="filter">фильтр (необязателен)</param>
        /// <param name="noTracking">нужно ли отслеживать изменение сущностей</param>
        /// <returns>запрос на выборку</returns>
        protected IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter = null, bool noTracking = true) {
            IQueryable<T> result = _dbContext.Set<T>();
            if (filter != null) {
                result = result.Where(filter);
            }

            if (noTracking) {
                result = result.AsNoTracking();
            }

            return result;
        }

        /// <summary>
        /// Получает сущности
        /// </summary>
        /// <param name="queryable">запрос на выборку</param>
        /// <returns>сущности</returns>
        protected async Task<ICollection<T>> ToListAsync(IQueryable<T> queryable) {
            return await queryable.ToListAsync();
        }
    }
}
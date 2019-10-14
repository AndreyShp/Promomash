using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Promomash.Common.DAL.Repositories.Contracts {
    /// <summary>
    /// Базовый интерфейс репозитория
    /// </summary>
    public interface IRepositoryBase<T> {
        /// <summary>
        /// Получает сущности
        /// </summary>
        /// <param name="predicate">фильтр (необязателен). Если не указать - ограничение на выборку не будет происходить</param>
        /// <returns>сущности попавшие под фильтр</returns>
        Task<ICollection<T>> GetAsync(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// Получает одну сущность по фильтру
        /// </summary>
        /// <param name="predicate">фильтр (необязателен). Если не указать - вернем все данные</param>
        /// <returns>первая попавшая в выборку сущность или null</returns>
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// Сохраняет сущность
        /// </summary>
        /// <param name="entity">сущность</param>
        Task<T> AddAsync(T entity);
    }
}
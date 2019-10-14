using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Promomash.Regions.Contracts.Data;
using Promomash.Regions.WebApi.DAL.Dto;

namespace Promomash.Regions.WebApi.Managers.Contracts {
    /// <summary>
    /// Интерфейс менеджера для работы с заказами
    /// </summary>
    public interface IRegionsManager {
        /// <summary>
        /// Получает регионы
        /// </summary>
        /// <param name="query">запрос для выборки</param>
        /// <returns>заказы попавшие под фильтр</returns>
        Task<ICollection<Region>> GetAsync(Query query);
    }
}
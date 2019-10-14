using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Promomash.Regions.Contracts.Data;
using Promomash.Regions.WebApi.DAL.Dto;

namespace Promomash.Regions.WebApi.DAL.Repositories.Contracts {
    /// <summary>
    /// Интерфейс репозитория регионов
    /// </summary>
    public interface IRegionsRepository {
        /// <summary>
        /// Получает регионы
        /// </summary>
        /// <param name="query">запрос для выборки</param>
        /// <returns>заказы попавшие под фильтр</returns>
        Task<ICollection<RegionDto>> GetAsync(Query query);
    }
}
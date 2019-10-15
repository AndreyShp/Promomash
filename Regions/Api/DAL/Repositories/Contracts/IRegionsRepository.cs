using System.Collections.Generic;
using System.Threading.Tasks;
using Promomash.Regions.Contracts.Data;
using Promomash.Regions.WebApi.DAL.Dto;

namespace Promomash.Regions.WebApi.DAL.Repositories.Contracts {
    /// <summary>
    /// Интерфейс репозитория регионов
    /// </summary>
    internal interface IRegionsRepository {
        /// <summary>
        /// Получает регионы
        /// </summary>
        /// <param name="query">запрос для выборки</param>
        /// <returns>заказы попавшие под фильтр</returns>
        Task<ICollection<RegionDto>> GetAsync(Query query);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Promomash.Regions.Contracts.Data;

namespace Promomash.Regions.WebApi.Managers.Contracts {
    /// <summary>
    /// Интерфейс менеджера регионов
    /// </summary>
    public interface IRegionsManager {
        /// <summary>
        /// Получает регионы
        /// </summary>
        /// <param name="query">запрос для выборки</param>
        /// <returns>регионы попавшие под фильтр</returns>
        Task<ICollection<Region>> GetAsync(Query query);
    }
}
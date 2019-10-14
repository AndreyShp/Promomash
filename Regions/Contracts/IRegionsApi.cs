using System.Collections.Generic;
using System.Threading.Tasks;
using Promomash.Regions.Contracts.Data;

namespace Promomash.Regions.Contracts {
    /// <summary>
    /// Интерфейс сервиса регионов
    /// </summary>
    public interface IRegionsApi {
        /// <summary>
        /// Получает регионы
        /// </summary>
        /// <param name="query">запрос на выборку данных</param>
        /// <returns>регионы</returns>
        Task<ICollection<Region>> Get(Query query = null);
    }
}
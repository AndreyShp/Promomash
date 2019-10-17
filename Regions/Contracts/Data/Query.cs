using System.Collections.Generic;
using Promomash.Regions.Contracts.Enums;

namespace Promomash.Regions.Contracts.Data {
    /// <summary>
    /// Запрос на получение регионов
    /// Если указать несколько фильтров, то вернутся данные подходящие под все из них
    /// </summary>
    public class Query {
        /// <summary>
        /// Пагинация (опционально)
        /// </summary>
        public Pagination Pagination { get; set; }

        /// <summary>
        /// Сортировка по полям, ключ это название поля для сортировки а значение направление для сортировки (опционально)
        /// </summary>
        public Dictionary<string, SortDirection> SortFields { get; set; }

        /// <summary>
        /// Идентификатор родительских регионов для фильтрации (опционально).
        /// Если указать в качестве элемента 0, то вернем также те у которых нет родителя
        /// </summary>
        public HashSet<long> ParentsIds { get; set; }

        /// <summary>
        /// Идентификаторы регионов для фильтрации (опционально)
        /// </summary>
        public HashSet<long> Ids { get; set; }
        
        /// <summary>
        /// Имя региона для фильтрации (опционально). Может быть часть имени. Поиск регистронезависим
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Тип регионов для фильтрации (опционально)
        /// </summary>
        public HashSet<RegionType> Types { get; set; }
    }
}
using System.Collections.Generic;
using Promomash.Regions.Contracts.Enums;

namespace Promomash.Regions.Contracts.Data {
    /// <summary>
    /// Регион
    /// </summary>
    public class Region {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип региона
        /// </summary>
        public RegionType Type { get; set; }
        
        /// <summary>
        /// Родительский регион если есть
        /// </summary>
        public Region Parent { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using Promomash.Regions.Contracts.Enums;

namespace Promomash.Regions.WebApi.DAL.Dto {
    /// <summary>
    /// Регион
    /// </summary>
    public class RegionDto {
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
        /// Идентификатор региона
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// Родительский регион
        /// </summary>
        [ForeignKey(nameof(ParentId))]
        public virtual RegionDto Parent { get; set; }
    }
}
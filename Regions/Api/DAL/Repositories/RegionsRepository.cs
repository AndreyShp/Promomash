﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Promomash.Common.DAL.Repositories;
using Promomash.Regions.Contracts.Data;
using Promomash.Regions.Contracts.Enums;
using Promomash.Regions.WebApi.DAL.Context;
using Promomash.Regions.WebApi.DAL.Dto;
using Promomash.Regions.WebApi.DAL.Repositories.Contracts;

namespace Promomash.Regions.WebApi.DAL.Repositories {
    /// <summary>
    /// Репозиторий регионов
    /// </summary>
    internal class RegionsRepository : RepositoryBase<RegionDto>, IRegionsRepository {
        private readonly Dictionary<string, Expression<Func<RegionDto, object>>> _sortFields =
            new Dictionary<string, Expression<Func<RegionDto, object>>> {
                                                                {"Name", e => e.Name},
                                                                {"Type", e => e.Type}
                                                            };

        /// <inheritdoc />
        public RegionsRepository(RegionsDbContext dbContext) : base(dbContext) { }

        /// <inheritdoc />
        public async Task<ICollection<RegionDto>> GetAsync(Query query) {
            var queryable = GetQueryable();
            if (query?.Ids?.Any() == true) {
                queryable = queryable.Where(e => query.Ids.Contains(e.Id));
            }

            if (query?.ParentsIds?.Any() == true) {
                queryable = queryable.Where(e => query.ParentsIds.Contains(e.ParentId));
            }

            if (query?.Names?.Any() == true) {
                queryable = queryable.Where(e => query.Names.Contains(e.Name));
            }

            if (query?.SortFields?.Any() == true) {
                foreach (var sortField in query.SortFields) {
                    if (!_sortFields.TryGetValue(sortField.Key, out var sortFld)) {
                        throw new ArgumentException($"Некорректное поле для сортировки {sortField.Key}");
                    }
                    queryable = queryable.OrderBy(sortFld, sortField.Value == SortDirection.Asc);
                }
            }

            return await ToListAsync(queryable);
        }
    }
}
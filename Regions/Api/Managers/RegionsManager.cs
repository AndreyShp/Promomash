using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Promomash.Regions.Contracts.Data;
using Promomash.Regions.WebApi.DAL.Repositories.Contracts;
using Promomash.Regions.WebApi.Managers.Contracts;

namespace Promomash.Regions.WebApi.Managers {
    /// <summary>
    /// Менеджер для работы с регионами
    /// </summary>
    public class RegionsManager : IRegionsManager {
        private readonly IMapper _mapper;
        private readonly IRegionsRepository _regionsRepository;

        public RegionsManager(IRegionsRepository regionsRepository, IMapper mapper) {
            _regionsRepository = regionsRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<ICollection<Region>> GetAsync(Query query) {
            var orders = await _regionsRepository.GetAsync(query);
            var result = _mapper.Map<ICollection<Region>>(orders);
            return result;
        }
    }
}
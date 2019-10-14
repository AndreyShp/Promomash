using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Promomash.Regions.Contracts;
using Promomash.Regions.Contracts.Data;
using Promomash.Regions.WebApi.Managers.Contracts;

namespace Promomash.Regions.WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase, IRegionsApi {
        private readonly IRegionsManager _regionsManager;

        public RegionsController(IRegionsManager regionsManager) {
            _regionsManager = regionsManager;
        }

        /// <inheritdoc />
        // GET api/regions
        // GET api/regions?ids=6&ids=7&parentsIds=2&sortFields[Name]=desc&pagination.count=1&pagination.offset=1
        [HttpGet]
        public async Task<ICollection<Region>> Get([FromQuery] Query query = null) {
            var result = await _regionsManager.GetAsync(query);
            return result;
        }
    }
}
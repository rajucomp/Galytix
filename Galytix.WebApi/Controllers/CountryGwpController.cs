using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Galytix.WebApi.Data;
using Galytix.WebApi.Data.DataServices;
using Galytix.WebApi.Data.Models;
using Galytix.WebApi.Data.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Galytix.WebApi.Controllers
{
    [ApiController]
    [Route("/api/gwp")]
    public class CountryGwpController: ControllerBase
    {
        private readonly IGrossWeightPremiumDataService dataService;

        private IMemoryCache _cache;

        public CountryGwpController(IGrossWeightPremiumDataService gwpDataService, IMemoryCache memoryCache)
        {
            dataService = gwpDataService;
            _cache = memoryCache;
        }

        [HttpPost("avg")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<List<GwpModel>> GetAverageGrossWrittenPremium(GrossWrittenPremiumRequest request)
        {
            List<GwpModel> res;

            if (!_cache.TryGetValue("CountryData", out res))
            {
                // Key not in cache, so get data.
                res = await Task.FromResult(dataService.GetCountryData(request)).ConfigureAwait(false);

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60));

                // Save data in cache.
                _cache.Set("CountryData", res, cacheEntryOptions);
            }

            return res;

        }
    }
}

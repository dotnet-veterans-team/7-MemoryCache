using AnalizerDashboard._Util;
using AnalizerDashboard.Infrastructure.Caching;
using AnalizerDashboard.Infrastructure.Caching.Interfaces;
using AnalizerDashboard.Infrastructure.Repository.Interfaces;
using AnalizerDashboard.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnalizerDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnaliserController : ControllerBase
    {
        private readonly IAnalistRepository _analistRepository;
        private readonly ISampleRepository _sampleRepository;
        private readonly ICacheStore _cacheStore;
       
        public AnaliserController(IAnalistRepository analistRepository,
                                  ISampleRepository sampleRepository,
                                  ICacheStore cacheStore)
        {
            _analistRepository = analistRepository;
            _sampleRepository = sampleRepository;
            _cacheStore = cacheStore;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var AnalistCacheKey = new AnalistCache(new Guid("AE1DACCA-E352-4556-B2F5-4BE4AC16D235"));

            Analist analist = _cacheStore.Get(AnalistCacheKey);

            if (analist == null)
            {
                var AnalistFound = _analistRepository.GetAnalist(new Guid("AE1DACCA-E352-4556-B2F5-4BE4AC16D235"));

                if (AnalistFound is not null)
                {
                    _cacheStore.Add(AnalistFound, AnalistCacheKey);
                    return new OkObjectResult(AnalistFound);
                }
                else
                {
                    return NotFound();
                }
            }

            return new OkObjectResult(analist);
        }


        [HttpPost("Analist")]
        public void Post()
        {
            _analistRepository.Add(new Models.Analist() { Name = "Vitor Santos", Role = "Analist" });
            _analistRepository.UnitOfWork.Commit();
        }

        [HttpPost("Samples")]
        public async void PostSamples()
        {
            var samples = SamplesFake.ListOfSamples(5000, new Guid("AE1DACCA-E352-4556-B2F5-4BE4AC16D235"));
            _sampleRepository.Add(samples);
            _cacheStore.Clean();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

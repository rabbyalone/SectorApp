using Microsoft.AspNetCore.Mvc;
using SectorApp.Entity;
using SectorApp.Repository;

namespace SectorApp.Controllers
{
    [Route("api/sectors")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly IMongoRepository<Sector> mongoRepository;
        public SectorController(IMongoRepository<Sector> mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSectors()
        {
            var all = await mongoRepository.GetAllAsync();
            return Ok(all);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Sector sector)
        {
            var entity = await mongoRepository.InsertAsync(sector);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] Sector sector)
        {
            var entity = await mongoRepository.UpdateAsync(id, sector);
            return Ok(entity);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SectorApp.Entity;
using SectorApp.Repository;

namespace SectorApp.Controllers
{
    [Route("api/sector-assign")]
    [ApiController]
    public class SectorAssignController : ControllerBase
    {
        private readonly IMongoRepository<SectorAssign> mongoRepository;
        public SectorAssignController(IMongoRepository<SectorAssign> mongoRepository)
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
        public async Task<IActionResult> Create([FromBody] SectorAssign sector)
        {
            sector.Id = Guid.NewGuid().ToString("N").Substring(0, 24);
            var entity = await mongoRepository.InsertAsync(sector);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] SectorAssign sector)
        {
            var entity = await mongoRepository.UpdateAsync(id, sector);
            return Ok(entity);
        }
    }
}

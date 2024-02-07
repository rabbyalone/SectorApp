using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (!ObjectId.TryParse(id, out var sectorId))
                return BadRequest("Invalid ID format");
            var single = await mongoRepository.GetByIdAsync(sectorId);
            return Ok(single);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Sector sector)
        {
            sector.Id = Guid.NewGuid().ToString("N").Substring(0, 24);
            var entity = await mongoRepository.InsertAsync(sector);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, [FromBody] Sector sector)
        {
            if (!ObjectId.TryParse(id, out var sectorId))
                return BadRequest("Invalid ID format");

            var entity = await mongoRepository.UpdateAsync(sectorId, sector);
            return Ok(entity);
        }
    }
}

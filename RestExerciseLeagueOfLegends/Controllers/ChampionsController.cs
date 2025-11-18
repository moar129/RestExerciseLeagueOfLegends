using LeagueOfLegendsLib;
using Microsoft.AspNetCore.Mvc;
using RestExerciseLeagueOfLegends.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestExerciseLeagueOfLegends.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionsController : ControllerBase
    {
        private ChampionsRepo _repo;
        public ChampionsController(ChampionsRepo repo)
        {
            _repo = repo;
        }
        // GET: api/<ChampionsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IEnumerable<Champion> Get([FromQuery] string? nameIncludes, [FromQuery] string? descriptionIncludes, [FromQuery] string? orderBy)
        {
            return _repo.Get(nameIncludes, descriptionIncludes, orderBy);
        }

        // GET api/<ChampionsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Champion> Get(int id)
        {
            Champion? champion = _repo.GetById(id);
            if (champion == null)
            {
                return NotFound();
            }
            return Ok(champion);
        }

        // POST api/<ChampionsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Champion> Post([FromBody] ChampionDTO value)
        {
            try
            {
                Champion createdChampion = ConverDTOTOChampion(value);
                _repo.Add(createdChampion);
                // return Created($"api/Champions/{createdChampion.Id}",createdChampion);
                return CreatedAtAction(nameof(Get), new { id = createdChampion.Id }, createdChampion);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception)
            {
                return BadRequest("An error occurred while processing the request.");
            }
        }

        // PUT api/<ChampionsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Champion> Put(int id, [FromBody] ChampionDTO value)
        {
            try
            {
                Champion updatedChampion = ConverDTOTOChampion(value);
                Champion? result = _repo.Update(id, updatedChampion);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("An error occurred while processing the request.");
            }
        }

        // DELETE api/<ChampionsController>/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Champion> Delete(int id)
        {
            Champion? championToBeDeleted = _repo.GetById(id);
            if (championToBeDeleted == null)
            {
                return NotFound();
            }
            _repo.Delete(id);
            return NoContent();
        }

        private Champion ConverDTOTOChampion(ChampionDTO dto)
        {
            if (dto.Name == null) throw new ArgumentNullException("Name cannot be null");
            if (dto.Role == null) throw new ArgumentNullException("Role cannot be null");
            if (dto.Description == null) throw new ArgumentNullException("Description cannot be null");
            if (dto.Difficulty == null) throw new ArgumentNullException("Difficulty cannot be null");
            if (dto.ReleaseDate == null) throw new ArgumentNullException("ReleaseDate cannot be null");
            Champion champion = new Champion()
            {
                Name = dto.Name,
                Role = dto.Role,
                Description = dto.Description,
                Difficulty = dto.Difficulty,
                ReleaseDate = dto.ReleaseDate.Value
            };
            return champion;
        }
    }
}

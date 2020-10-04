using System;
using System.Threading.Tasks;
using Demo.Interfaces;
using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampsController : Controller
    {

        private readonly ICampRepository _campRepository;

        public CampsController(ICampRepository campRepository)
        {
            _campRepository = campRepository;
        }
        
        
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                return Ok(await _campRepository.GetAllCamp());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error In Retrieving Data From Database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Camp>>GetCamp(int id)
        {
            try
            {
                var camp = await _campRepository.GetCamp(id);

                if (camp == null )
                {
                    return NotFound();
                }

                return camp;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from  Database");
            }
        }

        [HttpPost]

        public async Task<ActionResult> AddCamp([FromBody] Camp camp)
        {
            try
            {

                var result = await _campRepository.AddCamp(camp);
                if (camp == null)
                {
                    return NotFound();
                }

                return Ok(new
                {
                    result.Moniker,
                    result.Name,
                    result.Description,
                    result.Length,
                    result.EventDate,
                    result.RowVersion
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from  Database");
            }
        }
    }
}
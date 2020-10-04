using System;
using System.Threading.Tasks;
using Demo.Interfaces;
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
        public async Task<IActionResult> Index()
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
    }
}
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

    public class SchoolController : Controller
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        [HttpGet]

        public async Task<ActionResult> Index()
        {
            try
            {
                return Ok(await _schoolRepository.GetAllSchool());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error In Retrieving Data From Database");
            }
        }

        [HttpGet("{schoolId:int}")]

        public async Task<ActionResult<School>> GetSchool(int schoolId)
        {
            try
            {
                var result = await _schoolRepository.GetSchool(schoolId);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from  Database");
            }
        }

        [HttpPost]

        public async Task<ActionResult<School>> AddSchool(School school)
        {
            try
            {
                var schools = await _schoolRepository.AddSchool(school);

                if (schools == null)
                {
                    return NotFound();
                }

                return Ok(new
                {
                    schools.Name,
                    schools.Address,
                    schools.ContactName,
                    schools.ContactEmail,
                    schools.ContactPhoneNo
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from  Database");
            }
            
        }
        
        [HttpPut("{schoolId:int}")]
        public async Task<ActionResult<School>> UpdateCamp(int schoolId, School school)
        {
            try
            {
                if (schoolId != school.Id)
                {
                    return BadRequest("Id Mismatch");
                }

                var schoolUpdate = await _schoolRepository.GetSchool(schoolId);
                if (schoolUpdate==null)
                {
                    return NotFound($"School Id = {schoolId} Not Found");
                }

                return await _schoolRepository.UpdateSchool(school);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpDelete("{schoolId:int}")]
        public async Task<ActionResult<School>> DeleteSchool(int schoolId, School school)
        {
            try
            {
                if (schoolId != school.Id)
                {
                    return BadRequest("Id Mismatch");
                }
        
                var schoolDelete = await _schoolRepository.GetSchool(schoolId);
                if (schoolDelete==null)
                {
                    return NotFound($"School Id = {schoolId} Not Found");
                }
        
                return await _schoolRepository.DeleteSchool(schoolId);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from  Database");
            }
        }

    }

}
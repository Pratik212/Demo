using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Interfaces;
using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Provider
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly DemoContext _context;

        public SchoolRepository(DemoContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<School>> GetAllSchool()
        {
            return await _context.Schools.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<School> GetSchool(int schoolId)
        {
            return await _context.Schools.FirstOrDefaultAsync(x => x.Id == schoolId);
        }

        public async Task<School> AddSchool(School school)
        {
            var schools = await _context.Schools.AddAsync(school);
            await _context.SaveChangesAsync();
            return schools.Entity;
        }

        public async Task<School> UpdateSchool(School school)
        {
            var schools = await _context.Schools.FirstOrDefaultAsync(x => x.Id == school.Id);

            if (schools != null)
            {
                schools.Id = school.Id;
                schools.Name = school.Name;
                schools.Address = school.Address;
                schools.ContactName = school.ContactName;
                schools.ContactPhoneNo = school.ContactPhoneNo;

                await _context.SaveChangesAsync();
                return schools;
            }

            return null;
        }

        public async Task<School> DeleteSchool(int schoolId)
        {
            var schools =await _context.Schools.FirstOrDefaultAsync(e => e.Id == schoolId);
            if (schools != null)
            {
                _context.Schools.Remove(schools);
                await _context.SaveChangesAsync();
                return schools;
            }

            return null;
        }
    }
}
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Demo.Interfaces;
using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Provider
{
    public class CampRepository : ICampRepository
    {
        private readonly DemoContext _context;

        public CampRepository(DemoContext context)
        {
            _context = context;
        }

        public  async Task<IEnumerable<Camp>> GetAllCamp()
        {
            return await _context.Camps.ToListAsync();
        }

        public async Task<Camp> GetCamp(int id)
        {
            return await _context.Camps.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Camp> AddCamp(Camp camp)
        {
            var camps = await _context.Camps.AddAsync(camp);
            await _context.SaveChangesAsync();
            return camps.Entity;

        }
    }
}
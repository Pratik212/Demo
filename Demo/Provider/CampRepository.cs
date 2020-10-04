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
    }
}
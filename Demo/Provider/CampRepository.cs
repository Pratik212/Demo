using System.Collections.Generic;
using System.Linq;
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
            return await _context.Camps.OrderBy(x=>x.Id).ToListAsync();
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

        public async Task<Camp> UpdateCamp(Camp camp)
        {
            var result =await _context.Camps.FirstOrDefaultAsync(a => a.Id == camp.Id);
            if (result!=null)
            {
                result.Id = camp.Id;
                result.Moniker = camp.Moniker;
                result.Name = camp.Name;
                result.Length = camp.Length;
                result.Description = camp.Description;
                result.EventDate = camp.EventDate;
                result.RowVersion = camp.RowVersion;
                
                    await _context.SaveChangesAsync();
                    return result;
            }

            return null;
        }

        public async Task<Camp>DeleteCamp(int id)
        {
            var camps =await _context.Camps.FirstOrDefaultAsync(e => e.Id == id);
            if (camps != null)
            {
                _context.Camps.Remove(camps);
                await _context.SaveChangesAsync();
                return camps;
            }

            return null;
        }
    }
}
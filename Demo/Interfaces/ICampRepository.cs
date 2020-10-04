using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Models;

namespace Demo.Interfaces
{
    public interface ICampRepository
    {
        Task<IEnumerable<Camp>> GetAllCamp();

        Task<Camp> GetCamp(int id);

        Task<Camp> AddCamp(Camp camp);
    }
}
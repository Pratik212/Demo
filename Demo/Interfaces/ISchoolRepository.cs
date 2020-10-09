using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Models;

namespace Demo.Interfaces
{
    public interface ISchoolRepository
    {
        Task<IEnumerable<School>> GetAllSchool();

        Task<School> GetSchool(int schoolId);

        Task<School> AddSchool(School school);

        Task<School> UpdateSchool(School school);

        Task<School> DeleteSchool(int schoolId);
    }
}
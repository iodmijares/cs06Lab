using Student.Web.Api.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Student.Web.Api.Data
{
    public interface IGradesRepository: IRepository<Grading>
    {
        Task<List<Grading>> GetAllAsync();
        Task<Grading?> GetById(int id);
    
    }
}
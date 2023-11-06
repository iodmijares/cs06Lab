using Student.Web.Api.Models;

namespace Student.Web.Api.Data
{
    public interface IPupilRepository : IRepository<Pupil>
    {
        Task<List<Pupil>> GetAllAsync();
    }
}
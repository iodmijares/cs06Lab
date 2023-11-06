using Student.Web.Api.Models;

namespace Student.Web.Api.Data
{
    public interface IGradeRepository : IRepository<Grade>
    {
         Task<List<Grade>> GetAllByPupilIdAsync(string pupilId);
         Task<List<Grade>> GetAllBySubjecIdAsync(int subjectId);
    }
}

using Microsoft.EntityFrameworkCore;
using Student.Web.Api.Models;

namespace Student.Web.Api.Data
{
    public class GradesRepository : IGradesRepository
    {
        private readonly StudentDataContext _gradingContext;

        public GradesRepository(StudentDataContext gradingContext)
        {
            _gradingContext = gradingContext;
        }

        public void Add(Grading newT)
        {
            _gradingContext.Add(newT);
        }

        public void Delete(Grading item)
        {
            _gradingContext.Remove(item);
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _gradingContext.SaveChangesAsync() > 0;
        }

        public async void Update<K>(K id, Grading input)
        {
            var thegrading = await _gradingContext.Gradings.FindAsync(id);
          
                thegrading.GradeId= input.GradeId;
                
                thegrading.Grade = input.Grade;
                thegrading.Remarks = input.Remarks;
        }

        public async Task<List<Grading>> GetAllAsync()
        {
            return await _gradingContext.Gradings.ToListAsync();
        }

        public async Task<Grading?> GetById(int id)
        {
            return await _gradingContext.Gradings.FirstOrDefaultAsync(x => x.GradeId == id);
        }
    }
}

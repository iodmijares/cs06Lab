using Microsoft.EntityFrameworkCore;
using Student.Web.Api.Models;

namespace Student.Web.Api.Data
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly StudentDataContext _dbContext;


        public SubjectRepository(StudentDataContext studentContext)
        {
            _dbContext = studentContext;

        }
        public void Add(Subject newT)
        {
            _dbContext.Add(newT);
        }

        public void Delete(Subject item)
        {
            _dbContext.Remove(item);
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async void Update<K>(K id, Subject input)
        {
            // Get the Subject
            var theSubject = await _dbContext.Subjects.FindAsync(id);
            theSubject.Code = input.Code;
            theSubject.Title = input.Title;
        }

        public async Task<List<Subject>> GetAllAsync()
        {
            return await _dbContext.Subjects.ToListAsync();
        }


        public async Task<Subject?> GetById<K>(K id)
        {
            return await _dbContext.Subjects.FirstOrDefaultAsync(x => x.Id == Convert.ToInt32(id));
        }

    }
}
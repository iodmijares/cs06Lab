using Microsoft.EntityFrameworkCore;
using Student.Web.Api.Models;

// Factory Method pattern
namespace Student.Web.Api.Data
{
    // Interface defining the Factory Method
    public interface ISubjectFactory
    {
        Subject CreateSubject(string code, string title);
    }

    // Concrete implementation of the Factory Method
    public class SubjectFactory : ISubjectFactory
    {
        // Factory Method: Creates and returns a new Subject instance
        public Subject CreateSubject(string code, string title)
        {
            return new Subject
            {
                Code = code,
                Title = title
            };
        }
    }

    // Repo class using the Factory Method
    public class SubjectRepository : ISubjectRepository
    {
        private readonly StudentDataContext _dbContext;
        private readonly ISubjectFactory _subjectFactory;

        public SubjectRepository(StudentDataContext studentContext, ISubjectFactory subjectFactory)
        {
            _dbContext = studentContext;
            _subjectFactory = subjectFactory;
        }

        public void Add(Subject newT)
        {
            _dbContext.Add(newT);
        }

        public void Delete(Subject item)
        {
            _dbContext.Remove(item);
        }

        public void AddSubject(string code, string title)
        {
            Subject newSubject = _subjectFactory.CreateSubject(code, title);
            _dbContext.Add(newSubject);
        }

        public async void Update<K>(K id, Subject input)
        {
            // Get the Subject
            var theSubject = await _dbContext.Subjects.FindAsync(id);
            theSubject.Code = input.Code;
            theSubject.Title = input.Title;
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
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

using Student.Web.Api.Models;
using Microsoft.EntityFrameworkCore;
using Student.Web.Api.Data;

namespace Student.Web.Api.Data
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly StudentDataContext _subjectContex;

        public SubjectRepository(StudentDataContext subjectContex)
        {
            _subjectContex = subjectContex;
        }

        public void Add(Subject newT)
        {
            _subjectContex.Add(newT);
        }

        public void Delete(Subject item)
        {
            _subjectContex.Remove(item);
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _subjectContex.SaveChangesAsync() > 0;
        }

        public async void Update<K>(K subjectId, Subject input)
        {
            // Get the subject
            var theSub = await _subjectContex.Subjects.FindAsync(subjectId);
            
            theSub.SubjectId = input.SubjectId;
            theSub.Code = input.Code;
            theSub.Title = input.Title;
        }

        public async Task<List<Subject>> GetAllAsync()
        {
            return await _subjectContex.Subjects.ToListAsync();
        }

        public async Task<Subject?> GetById(int Id)
        {
            return await _subjectContex.Subjects.FirstOrDefaultAsync(x => x.SubjectId == Id);
        }


    }
}

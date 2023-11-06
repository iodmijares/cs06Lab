using Microsoft.EntityFrameworkCore;
using Student.Web.Api.Models;

namespace Student.Web.Api.Data
{
    public class GradeRepository: IGradeRepository
    {
        private readonly StudentDataContext _dbContext;


        public GradeRepository(StudentDataContext studentContext)
        {
            _dbContext = studentContext;

        }
        public void Add(Grade newT)
        {
            _dbContext.Add(newT);
        }

        public void Delete(Grade input)
        {
            _dbContext.Remove(input);
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async void Update<K>(K id, Grade input)
        {
            // Get the Grade
            var theGrade = await _dbContext.Grades.FindAsync(id);
            theGrade.PupilId = input.PupilId;
            theGrade.SubjectId = input.SubjectId;
            theGrade.MidTerm = input.MidTerm;
            theGrade.FinalTerm = input.FinalTerm;
            theGrade.FinalGrade = input.FinalGrade;
            theGrade.Remarks = input.Remarks;
        }

        public async Task<List<Grade>> GetAllAsync()
        {
            return await _dbContext.Grades.ToListAsync();
        }


        public async Task<Grade?> GetById<K>(K id)
        {
            return await _dbContext.Grades.FirstOrDefaultAsync(x => x.Id == Convert.ToInt32(id));
        }

        public async Task<List<Grade>> GetAllByPupilIdAsync(string pupilId)
        {
            return await _dbContext.Grades
                .Include(x => x.Subject)
                .Where(x => x.PupilId == pupilId).ToListAsync();
        }

        public async Task<List<Grade>> GetAllBySubjecIdAsync(int subjectId)
        {
            return await _dbContext.Grades
                .Include(x => x.Pupil)
                .Where(x => x.SubjectId == subjectId).ToListAsync();
        }

    }
}
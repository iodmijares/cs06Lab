namespace Student.Web.Api.Dto
{
    public class GradeDto
    {
        // Primary Key
        public int Id { get; set; }

        // Foreign Key for PupilTable
        public string PupilId { get; set; }

        // Foreign Key for Subject Table
        public int SubjectId { get; set; }
        public string Pupil { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string MidTerm { get; set; }
        public string FinalTerm { get; set; }
        public string FinalGrade { get; set; }
        public string Remarks { get; set; }
        
    }
}
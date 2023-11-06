namespace Student.Web.Api.Models
{
    public class Grade
    {
        // Primary Key
        public int Id { get; set; }

        // Foreign Key for PupilTable
        public string PupilId { get; set; }

        // Foreign Key for Subject Table
        public int SubjectId { get; set; }
        public string MidTerm { get; set; }
        public string FinalTerm { get; set; }
        public string FinalGrade { get; set; }
        public string Remarks { get; set; }

        // Navigation Properties
        public Pupil Pupil { get; set; }
        public Subject Subject { get; set; }
    }
}
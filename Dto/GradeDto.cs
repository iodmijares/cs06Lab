namespace Student.Web.Api.Dto
{
    public class GradesDto
    {
        public int GradeId { get; set; }
        public string StudentId{get;set;} = string.Empty;
        public int SubjectId {get;set;}
        public string? Grade { get; set; }
    }
}
namespace Student.Web.Api.Dto
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public List<GradeDto> Grades { get; set; } = new List<GradeDto>();
    }
}
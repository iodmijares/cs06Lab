namespace Student.Web.Api.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public List<Grade> Grades { get; set; } = new List<Grade>();
    }
}
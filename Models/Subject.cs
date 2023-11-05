
namespace Student.Web.Api.Models
{
    public partial class Subject
    {
      

        public Subject(int subjectId)
        {
            SubjectId = subjectId;
        }
        public int SubjectId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;


      
    }
}
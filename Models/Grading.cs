using System;
using System.Collections.Generic;
namespace Student.Web.Api.Models
{
    public partial class Grading
    {
        public Grading()
        {
            Pupils = new HashSet<Pupil>();
            Subjects = new HashSet<Subject>();
        }
        public Grading(int gradeId)
        {            
            GradeId = gradeId;
        }
        public int GradeId { get; set; }
        public string? Grade { get; set; }
        public string? Remarks { get; set;}

        public virtual ICollection<Pupil>Pupils{get;set;}
        public virtual ICollection<Subject>Subjects{get;set;}
    }
}
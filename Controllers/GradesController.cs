using Microsoft.AspNetCore.Mvc;
using Student.Web.Api.Data;
using Student.Web.Api.Dto;
using Student.Web.Api.Dto.Builders;
using Student.Web.Api.Models;

namespace Student.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GradesController: ControllerBase
    {
        private readonly ILogger<GradesController> _logger;

        private readonly IGradeRepository _gradeRepository;
        private readonly IPupilRepository _pupilRepository;
        private readonly ISubjectRepository _subjectRepository;


        public GradesController(ILogger<GradesController> logger,
            IGradeRepository gradeRepository,
            IPupilRepository pupilRepository,
            ISubjectRepository subjectRepository)
        {
            this._logger = logger;

            this._gradeRepository = gradeRepository;
            _pupilRepository = pupilRepository;
            this._subjectRepository = subjectRepository;

        }

        [HttpGet("by-student/{pupilId}")]
        public async Task<IActionResult> GetListByPupil(string pupilId)
        {
            var pupil = await _pupilRepository.GetById(pupilId);
            var grades = await _gradeRepository.GetAllByPupilIdAsync(pupilId);

            if (pupil == null)
            {
                return NotFound("Pupil not found");
            }

            _logger.LogInformation("Getting all list");

            // convert to DTO
            var pupilToReturn = new PupilDto();
            pupilToReturn.StudentId = pupil.StudentId;
            pupilToReturn.LastName = pupil.LastName;
            pupilToReturn.FirsName = pupil.FirsName;
            pupilToReturn.MiddleName = pupil.MiddleName;

            foreach (var item in grades)
            {
                var newGrade = new GradeDto();
                newGrade.PupilId = item.PupilId;
                newGrade.SubjectId = item.SubjectId;
                newGrade.Subject = $"{item.Subject.Code} {item.Subject.Title}";
                newGrade.MidTerm = item.MidTerm;
                newGrade.FinalTerm = item.FinalTerm;
                newGrade.FinalGrade = item.FinalGrade;
                newGrade.Remarks = item.Remarks;

                pupilToReturn.Grades.Add(newGrade);
            }

            return Ok(pupilToReturn);
        }

        [HttpGet("by-subject/{subjectId}")]
        public async Task<IActionResult> GetListBySubject(int subjectId)
        {
            var subject = await _subjectRepository.GetById(subjectId);
            var grades = await _gradeRepository.GetAllBySubjecIdAsync(subjectId);

            if (subject == null)
            {
                return NotFound("Pupil not found");
            }

            _logger.LogInformation("Getting all list");

            // convert to DTO
            var subjectToReturn = new SubjectDto();
            subjectToReturn.Code = subject.Code;
            subjectToReturn.Id = subject.Id;
            subjectToReturn.Title = subject.Title;
            subjectToReturn.Grades = new List<GradeDto>();

            foreach (var item in grades)
            {
                var newGrade = new GradeDto();
                newGrade.PupilId = item.PupilId;
                newGrade.Pupil = $"{item.Pupil.LastName}, {item.Pupil.FirsName}";
                newGrade.SubjectId = item.SubjectId;
                newGrade.MidTerm = item.MidTerm;
                newGrade.FinalTerm = item.FinalTerm;
                newGrade.FinalGrade = item.FinalGrade;
                newGrade.Remarks = item.Remarks;

                subjectToReturn.Grades.Add(newGrade);
            }

            return Ok(subjectToReturn);
        }

       // In GradesController class
[HttpPost()]
public async Task<IActionResult> Post(GradeDto input)
{
    var newGrade = new GradeDtoBuilder()
        .WithGradeInfo(input.PupilId, input.SubjectId, input.MidTerm, input.FinalTerm, input.FinalGrade, input.Remarks)
        .Build();

    // Convert GradeDto to Grade
    var gradeEntity = new Grade
    {
        PupilId = newGrade.PupilId,
        SubjectId = newGrade.SubjectId,
        MidTerm = newGrade.MidTerm,
        FinalTerm = newGrade.FinalTerm,
        FinalGrade = newGrade.FinalGrade,
        Remarks = newGrade.Remarks
    };

    _gradeRepository.Add(gradeEntity);

    if (await _gradeRepository.SaveAllChangesAsync())
    {
        return Ok(input);
    }

    return BadRequest("May Error");
}



        [HttpPut("{id}")]
        public async Task<IActionResult> Put(GradeDto input)
        {
            var grade = await _gradeRepository.GetById(input.Id);
            grade.PupilId = input.PupilId;
            grade.SubjectId = input.SubjectId;
            grade.MidTerm = input.MidTerm;
            grade.FinalTerm = input.FinalTerm;
            grade.FinalGrade = input.FinalGrade;
            grade.Remarks = input.Remarks;
            
            if ( await _gradeRepository.SaveAllChangesAsync())
            {
                return Ok("Updated Na!");
            }

            return BadRequest("May Error");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var grade = await _gradeRepository.GetById(id);
            
            if (grade != null) 
            {
                _gradeRepository.Delete(grade);
                if ( await _gradeRepository.SaveAllChangesAsync())
                {
                    return Ok("Finis Na!");
                }
            }


            return BadRequest("May Error");
        }

    }
}
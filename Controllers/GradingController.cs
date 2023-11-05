using Microsoft.AspNetCore.Mvc;
using Student.Web.Api.Data;
using Student.Web.Api.Dto;
using Student.Web.Api.Models;

namespace Student.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GradingController : ControllerBase
    {
        private ILogger<GradingController> _logger;
        private readonly IGradesRepository _gradingRepository;

        public GradingController(ILogger<GradingController> logger, IGradesRepository gradeRepository)
        {
            _logger = logger;
            _gradingRepository = gradeRepository;
        }
        

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var grades = await _gradingRepository.GetAllAsync();
            
            _logger.LogInformation("Getting all list");
            return Ok(grades);
        }

        [HttpPost]
        public async Task<IActionResult> Post(GradesDto input)
        {
            var newGrades = new Grading(input.GradeId);
            if (double.TryParse(input.Grade, out double grade))
            {
                newGrades.Grade = input.Grade;

                if (grade >= 1.00 && grade <= 3.00)
                {
                    newGrades.Remarks = "Passed";
                }
                else if (grade == 4)
                {
                    newGrades.Remarks = "Not sure";
                }
                else if (grade == 5.00)
                {
                    newGrades.Remarks = "Failed";
                }
                else
                {
                    newGrades.Remarks = null;
                }

                _gradingRepository.Add(newGrades);

                if (await _gradingRepository.SaveAllChangesAsync())
                {
                    return Ok(input);
                }
                else
                {
                    return BadRequest("May error!");
                }
            }
            else
            {
                return BadRequest("May Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(GradesDto input)
        {
            var newGrades = await _gradingRepository.GetById(input.GradeId);
            
            
            if (double.TryParse(input.Grade, out double grade))
            {
                newGrades.Grade = input.Grade;

                if (grade >= 1.00 && grade <= 3.00)
                {
                    newGrades.Remarks = "Passed";
                }
                else if (grade == 5.00)
                {
                    newGrades.Remarks = "Failed";
                }
                else
                {
                    newGrades.Remarks = null;
                }

                if (await _gradingRepository.SaveAllChangesAsync())
                {
                    return Ok("Updated Na!");
                }

                return BadRequest("May Error");
            }
            else
            {
                return BadRequest("May Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var grade = await _gradingRepository.GetById(id);

            if (grade != null)
            {
                _gradingRepository.Delete(grade);
                if (await _gradingRepository.SaveAllChangesAsync())
                {
                    return Ok("Finis Na!");
                }
            }
            return BadRequest("May Error");
        }
    }
}

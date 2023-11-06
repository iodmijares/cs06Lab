using Microsoft.AspNetCore.Mvc;
using Student.Web.Api.Data;
using Student.Web.Api.Dto;
using Student.Web.Api.Models;

namespace Student.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectsController: ControllerBase
    {
        private ILogger<SubjectsController> _logger;
        private readonly ISubjectRepository _subjectRepository;


        public SubjectsController(ILogger<SubjectsController> logger,
            ISubjectRepository SubjectRepository
        )
        {
            _logger = logger;
            _subjectRepository = SubjectRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetList()
        {
            var Subjects = await _subjectRepository.GetAllAsync();
            _logger.LogInformation("Getting all list");
            return Ok(Subjects);
        }

        [HttpPost()]
        public async Task<IActionResult> Post(SubjectDto input)
        {
            var newSubject = new Subject();
            newSubject.Code = input.Code;
            newSubject.Title = input.Title;

            _subjectRepository.Add(newSubject);

            if ( await _subjectRepository.SaveAllChangesAsync())
            {
                return Ok(input);
            }

            return BadRequest("May Error");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(SubjectDto input)
        {
            var Subject = await _subjectRepository.GetById(input.Id);
            Subject.Code = input.Code;
            Subject.Title = input.Title;
            
            if ( await _subjectRepository.SaveAllChangesAsync())
            {
                return Ok("Updated Na!");
            }

            return BadRequest("May Error");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var Subject = await _subjectRepository.GetById(id);
            
            if (Subject != null) 
            {
                _subjectRepository.Delete(Subject);
                if ( await _subjectRepository.SaveAllChangesAsync())
                {
                    return Ok("Finis Na!");
                }
            }


            return BadRequest("May Error");
        }


    }
}
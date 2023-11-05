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
        private ILogger<StudentsController> _logger;
        private readonly ISubjectRepository _subjectRepository;


        public SubjectsController(ILogger<StudentsController> logger,
            ISubjectRepository subjectRepository
        )
        {
            _logger = logger;
            _subjectRepository= subjectRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetList()
        {
            var subjects = await _subjectRepository.GetAllAsync();
            _logger.LogInformation("Getting all list");
            return Ok(subjects);
        }

         [HttpPost()]
        public async Task<IActionResult> Post(SubjectDto input)
        {
            var newSub = new Subject (input.SubjectId);
            newSub.Code = input.Code;
            newSub.Title = input.Title;
            

            _subjectRepository.Add(newSub);

            if ( await _subjectRepository.SaveAllChangesAsync())
            {
                return Ok(input);
            }

            return BadRequest("May Error");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(SubjectDto input)
        {
            var subject = await _subjectRepository.GetById(input.SubjectId);    
            subject.Code = input.Code;
            subject.Title = input.Title;
             if ( await _subjectRepository.SaveAllChangesAsync())
            {
                return Ok("Updated Na!");
            }

            return BadRequest("May Error");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var subject = await _subjectRepository.GetById(id);
            
            if (subject != null) 
            {
                _subjectRepository.Delete(subject);
                if ( await _subjectRepository.SaveAllChangesAsync())
                {
                    return Ok("Finis Na!");
                }
            }


            return BadRequest("May Error");
        }


    }
}
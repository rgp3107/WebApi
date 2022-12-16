using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api.Models;
using Web_Api.Repository;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStuRepository _stuRepo;

        public StudentController(IStuRepository stuRepo) {
            _stuRepo = stuRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _stuRepo.Get();
        }

        [HttpGet("{EmpId}")]
        public async Task<ActionResult<Student>> GetStudents(Guid id)
        {
            return await _stuRepo.GetById(id);
        }
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudents([FromBody] Student student)
        {
            var newStudent = await _stuRepo.Create(student);
            return CreatedAtAction(nameof(GetStudents), new { EmpId = newStudent.Id }, newStudent);
        }

        [HttpPut]
        public async Task<ActionResult<Student>> PutStudents(Guid EmpId, [FromBody] Student student)
        {
            if(EmpId != student.Id) {
                return BadRequest();
            }
            await _stuRepo.Update(student);
            return NoContent();
        }
        [HttpDelete("{EmpId}")]
        public async Task<ActionResult> Delete(Guid EmpId)
        {
            var studentToDelete = await _stuRepo.GetById(EmpId);
            if(studentToDelete == null)
            {
                return NotFound();
            }
            await _stuRepo.Delete(studentToDelete.Id);
            return NoContent();

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Model;
using WebAPI.Data.Repository.IRepository;

namespace DemoAPIAndSQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudents()
        {
          return await _studentRepository.GetAllStudent();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<Student> GetStudent(int id)
        {
            return await _studentRepository.GetStudentById(id);
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task PutStudent(Student student)
        {
            await _studentRepository.UpdateStudent( student);
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task PostStudent(Student student)
        {
          await _studentRepository.CreateStudent(student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task DeleteStudent(int id)
        {
            await _studentRepository.DeleteStudent(id);
        }
    }
}

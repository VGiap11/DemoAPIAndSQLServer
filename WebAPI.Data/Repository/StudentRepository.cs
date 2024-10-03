using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Model;
using WebAPI.Data.Repository.IRepository;

namespace WebAPI.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DbContextApp _dbContext;
        public StudentRepository(DbContextApp dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task CreateStudent(Student student)
        {
            try
            {
                _dbContext.Students.Add(student);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteStudent(int id)
        {
            try
            {
                var findId = _dbContext.Students.Find(id);
                if (findId != null)
                {
                    _dbContext.Students.Remove(findId);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            try
            {
                return await _dbContext.Students.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateStudent(Student student)
        {
            try
            {
                var findId = _dbContext.Students.Find(student.Id);
                if (findId != null)
                {
                    findId.Name = student.Name;
                    findId.Age = student.Age;
                    findId.MaSV = student.MaSV;
                    findId.Description  = student.Description;
                    _dbContext.Students.Update(findId);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

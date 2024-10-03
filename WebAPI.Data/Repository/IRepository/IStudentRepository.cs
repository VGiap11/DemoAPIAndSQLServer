using WebAPI.Data.Model;

namespace WebAPI.Data.Repository.IRepository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudent();
        Task CreateStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(int id);
        Task<Student> GetStudentById(int id);
    }
}

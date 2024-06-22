using Diploma.DAL.Models;

namespace Diploma.DAL;

public interface IStudentDAL
{
    public Task AddStudentAsync(Student model);
    public Task<List<Student>> GetAllStudentAsync();
}
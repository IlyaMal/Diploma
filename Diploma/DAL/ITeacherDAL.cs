using Diploma.DAL.Models;

namespace Diploma.DAL;

public interface ITeacherDAL
{
    public Task AddTeacherAsync(Teacher model);
    public Task<List<Teacher>> GetAllTeachersAsync();
}
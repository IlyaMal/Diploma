using Diploma.DAL.Models;

namespace Diploma.BLL;

public interface IDiplomaBLL
{
    public Task AddStudentAsync(Student model);
    public Task AddTeacherAsync(Teacher model);
    public Task AddSettingsAsync();
    public Task DiplomaGeneration();
}
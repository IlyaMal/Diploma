using Diploma.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Diploma.DAL;

public class StudentDAL: IStudentDAL
{
    public async Task AddStudentAsync(Student model)
    {
        using (var connection = new DBHelper())
        {
            await connection.Students.AddAsync(model);
            await connection.SaveChangesAsync();
        }
    }

    public async Task<List<Student>> GetAllStudentAsync()
    {
        using (var connection = new DBHelper())
        {
            return await connection.Students.ToListAsync();
        }
    }
}
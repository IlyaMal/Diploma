using Diploma.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Diploma.DAL;

public class TeacherDAL: ITeacherDAL
{
    public async Task AddTeacherAsync(Teacher model)
    {
        using (var connection = new DBHelper())
        {
            await connection.Teachers.AddAsync(model);
            await connection.SaveChangesAsync();
        }
    }

    public async Task<List<Teacher>> GetAllTeachersAsync()
    {
        using (var connection = new DBHelper())
        {
            return await connection.Teachers.ToListAsync();
        }
    }
}
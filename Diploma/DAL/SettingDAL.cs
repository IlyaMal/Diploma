using Diploma.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Diploma.DAL;

public class SettingDAL: ISettingDAL
{
    public async Task AddSettingAsync(TextSettings model)
    {
        using (var connection = new DBHelper())
        {
            await connection.TextSettings.AddAsync(model);
            await connection.SaveChangesAsync();
        }
    }

    public async Task<List<TextSettings>> GetAllSettingsAsync()
    {
        using (var connection = new DBHelper())
        {
            var list = await connection.TextSettings.ToListAsync();
            return list.OrderBy(x => x.Id).ToList();
        }
    }
}
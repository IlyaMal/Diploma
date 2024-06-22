using Diploma.DAL.Models;

namespace Diploma.DAL;

public interface ISettingDAL
{
    public Task AddSettingAsync(TextSettings model);
    public Task<List<TextSettings>> GetAllSettingsAsync();
}
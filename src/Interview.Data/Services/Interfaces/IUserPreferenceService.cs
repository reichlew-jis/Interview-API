using System.Threading.Tasks;
using Interview.Data.Models;

namespace Interview.Data.Services.Interfaces;

public interface IUserPreferenceService
{
    Task AddOrUpdateSelectedTenant(SelectedTenant selectedTenant);

    Task<SelectedTenant> GetSelectedTenant(string email);
}
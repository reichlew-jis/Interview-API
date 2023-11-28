using System.Threading.Tasks;
using Interview.Data.Models;

namespace Interview.Data.Services.Interfaces;

public interface ITenantService
{
    Task AddOrUpdateTenant(Tenant tenant);

    Task<Tenant> GetTenant(int tenantId);
}
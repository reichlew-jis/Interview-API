using System.Threading.Tasks;
using AutoMapper;
using Interview.Data.Contexts;
using Interview.Data.Entities;
using Interview.Data.Models;
using Interview.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Interview.Data.Services;

public class UserPreferenceService : IUserPreferenceService
{
    private readonly InterviewContext _context;
    private readonly IMapper _mapper;

    public UserPreferenceService(InterviewContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddOrUpdateSelectedTenant(SelectedTenant selectedTenant)
    {
        var existingSelectedTenant = await _context.SelectedTenants.SingleOrDefaultAsync(x => x.Email == selectedTenant.Email);

        if (existingSelectedTenant is not null)
        {
            existingSelectedTenant.LastTenant = selectedTenant.LastTenant;
        }
        else
        {
            var selectedTenantEntity = _mapper.Map<SelectedTenantEntity>(selectedTenant);

            _context.SelectedTenants.Add(selectedTenantEntity);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<SelectedTenant> GetSelectedTenant(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return null;
        }

        var selectedTenant = await _context.SelectedTenants.SingleOrDefaultAsync(x => x.Email == email);

        return _mapper.Map<SelectedTenant>(selectedTenant);
    }
}

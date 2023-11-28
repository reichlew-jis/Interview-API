using AutoMapper;
using Interview.Data.Entities;
using Interview.Data.Models;

namespace Interview.Data.Mappers;

public class SelectedTenantProfile : Profile
{
    public SelectedTenantProfile()
    {
        CreateMap<SelectedTenant, SelectedTenantEntity>();
        CreateMap<SelectedTenantEntity, SelectedTenant>();
    }
}

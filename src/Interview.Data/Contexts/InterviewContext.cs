using Interview.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Interview.Data.Contexts;

public class InterviewContext : DbContext
{
    public InterviewContext() : base()
    {
    }

    public InterviewContext(DbContextOptions<InterviewContext> options) : base(options)
    {
    }

    public virtual DbSet<SelectedTenantEntity> SelectedTenants { get; set; }
}

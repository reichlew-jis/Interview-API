using System.IO;
using Interview.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Interview.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<InterviewContext>
{
    public InterviewContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<InterviewContext>();

        var connectionString = configuration.GetConnectionString("InterviewDbConnectionString");

        builder.UseSqlServer(connectionString);

        return new InterviewContext(builder.Options);
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Interview.Data.Contexts;
using Interview.Data.Entities;
using Interview.Data.Mappers;
using Interview.Data.Models;
using Interview.Data.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Interview.Data.Test.Services;

public class UserPreferenceServiceTests
{
    private static readonly Fixture _fixture = new();

    private readonly InterviewContext _context;
    private readonly IMapper _mapper;

    private readonly UserPreferenceService _service;

    public UserPreferenceServiceTests()
    {
        var builder = new DbContextOptionsBuilder<InterviewContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());

        _context = new InterviewContext(builder.Options);
        _mapper = new MapperConfiguration(x => x.AddMaps(typeof(SelectedTenantProfile))).CreateMapper();

        _service = new UserPreferenceService(_context, _mapper);
    }

    [Fact]
    public async Task AddOrUpdateSelectedTenant_ShouldAddNewSelectedTenant()
    {
        // Arrange
        var selectedTenant = _fixture.Create<SelectedTenant>();

        // Act
        await _service.AddOrUpdateSelectedTenant(selectedTenant);

        // Assert
        var selectedTenantEntities = await _context.SelectedTenants.ToListAsync();
        selectedTenantEntities.Should().HaveCount(1);

        var selectedTenantEntity = selectedTenantEntities.Single();
        selectedTenantEntity.Email.Should().Be(selectedTenant.Email);
        selectedTenantEntity.LastTenant.Should().Be(selectedTenant.LastTenant);
    }

    [Fact]
    public async Task AddOrUpdateSelectedTenant_ShouldUpdateExistingSelectedTenant()
    {
        // Arrange
        var selectedTenantEntity = _fixture.Create<SelectedTenantEntity>();

        await _context.SelectedTenants.AddAsync(selectedTenantEntity);
        await _context.SaveChangesAsync();

        var currentLastTenant = selectedTenantEntity.LastTenant;

        var selectedTenant = new SelectedTenant
        {
            Email = selectedTenantEntity.Email,
            LastTenant = selectedTenantEntity.LastTenant + 1
        };

        // Act
        await _service.AddOrUpdateSelectedTenant(selectedTenant);

        // Assert
        selectedTenantEntity.Email.Should().Be(selectedTenant.Email);
        selectedTenantEntity.LastTenant.Should().Be(currentLastTenant + 1);
    }

    [Fact]
    public async Task GetSelectedTenant_ShouldReturnSelectedTenantWhenOneExists()
    {
        // Arrange
        var selectedTenantEntity = _fixture.Create<SelectedTenantEntity>();

        await _context.SelectedTenants.AddAsync(selectedTenantEntity);
        await _context.SaveChangesAsync();

        var email = selectedTenantEntity.Email;

        // Act
        var selectedTenant = await _service.GetSelectedTenant(email);

        // Assert
        selectedTenant.Should().BeEquivalentTo(_mapper.Map<SelectedTenant>(selectedTenantEntity));
    }

    [Fact]
    public async Task GetSelectedTenant_ShouldReturnNullWhenOneDoesNotExist()
    {
        // Arrange
        var email = _fixture.Create<string>();

        // Act
        var result = await _service.GetSelectedTenant(email);

        // Assert
        result.Should().BeNull();
    }
}

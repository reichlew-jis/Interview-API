using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Interview.Data.Entities;
using Interview.Data.Mappers;
using Interview.Data.Models;
using Xunit;

namespace Interview.Data.Test.Mappers;

public class SelectedTenantProfileTests
{
    private static readonly Fixture _fixture = new();

    private readonly IMapper _mapper;

    public SelectedTenantProfileTests()
    {
        _mapper = new MapperConfiguration(x => x.AddMaps(typeof(SelectedTenantProfile))).CreateMapper();
    }

    [Fact]
    public void ShouldMapSelectedTenantToSelectedTenantEntity()
    {
        // Arrange
        var selectedTenant = _fixture.Create<SelectedTenant>();

        // Act
        var selectedTenantEntity = _mapper.Map<SelectedTenantEntity>(selectedTenant);

        // Assert
        selectedTenantEntity.Email.Should().Be(selectedTenant.Email);
        selectedTenantEntity.LastTenant.Should().Be(selectedTenant.LastTenant);
    }

    [Fact]
    public void ShouldMapSelectedTenantEntityToSelectedTenant()
    {
        // Arrange
        var selectedTenantEntity = _fixture.Create<SelectedTenantEntity>();

        // Act
        var selectedTenant = _mapper.Map<SelectedTenant>(selectedTenantEntity);

        // Assert
        selectedTenant.Email.Should().Be(selectedTenantEntity.Email);
        selectedTenant.LastTenant.Should().Be(selectedTenantEntity.LastTenant);
    }
}

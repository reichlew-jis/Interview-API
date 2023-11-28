using System.ComponentModel.DataAnnotations;

namespace Interview.Data.Models;

public class Tenant
{
    public int Id { get; set; }

    [Required]
    public string CourtCode { get; set; }

    [Required]
    public string CourtName { get; set; }
}
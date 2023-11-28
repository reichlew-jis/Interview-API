using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interview.Data.Entities;

[Table("SelectedTenant")]
public class SelectedTenantEntity
{
    [Key]
    public string Email { get; set; }

    [Required]
    public int LastTenant { get; set; }
}
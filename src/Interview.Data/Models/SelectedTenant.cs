using System.ComponentModel.DataAnnotations;

namespace Interview.Data.Models;

public class SelectedTenant
{
    [Required]
    public string Email { get; set; }

    [Required]
    public int LastTenant { get; set; }
}

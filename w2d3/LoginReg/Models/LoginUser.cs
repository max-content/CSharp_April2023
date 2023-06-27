#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LoginReg.Models;

[NotMapped]
public class LoginUser
{
    // No other fields!
    [Required]
    [Display(Name = "Email")]
    public string LoginEmail { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string LoginPassword { get; set; } 
}
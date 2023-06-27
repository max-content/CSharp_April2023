#pragma warning disable CS8600
#pragma warning disable CS8602
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LoginReg.Models;

public class User
{
    [Key]
    public int UserId {get;set;}
    [Required]
    public string FirstName {get;set;}
    [Required]
    public string LastName {get;set;}
    [Required]
    [EmailAddress]
    [UniqueEmail]
    public string Email {get;set;}
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    [NotMapped]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string PasswordConfirm {get;set;}
}

public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null)
        {
            return new ValidationResult("Email is Required");
        }
        
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
        if(_context.Users.Any(e => e.Email == value.ToString()))
        {
            return new ValidationResult("Email must be unique.");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}
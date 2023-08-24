#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsNDishes.Models;

public class Chef
{
    [Key]
    public int ChefId {get;set;}
    [Required]
    public string FirstName {get;set;}
    [Required]
    public string LastName {get;set;}
    [Required]
    [BirthdayInPast]
    [EighteenOrOlder]
    public DateTime Birthday {get;set;}
    public List<Dish> AllDishes {get;set;} = new List<Dish>();
}

public class BirthdayInPastAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null)
        {
            return new ValidationResult("Please enter a birthday");
        }
        
        // datetime var to cast the passed in field as a DateTime type from generic user input object?
        DateTime IsValidBirthday = (DateTime)value;

        //if the birthday is after today invalid
        if(IsValidBirthday >= DateTime.Now)
        {
            return new ValidationResult("Birthday must be in the past.");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}

public class EighteenOrOlderAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null)
        {
            return new ValidationResult("Please enter a birthday");
        }

        // datetime var to cast the passed in field as a DateTime type from generic user input object?
        DateTime DateOfBirth = (DateTime)value;
        DateTime Today = DateTime.Now;
        TimeSpan age = Today - DateOfBirth;
        int years = (int)(age.Days / 365.25); // .25 to account for leap year

        if(years < 18)
        {
            return new ValidationResult("You must be 18 or older to register");
        }
        else {
            return ValidationResult.Success;
        }
    }
}
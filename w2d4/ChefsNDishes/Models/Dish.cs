#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsNDishes.Models;

public class Dish
{
    [Key]
    public int DishId {get;set;}
    [Required]
    public string Name {get;set;}
    [Required]
    [Range(1,5, ErrorMessage ="Please enter a number between 1-5")]
    public int? Tastiness {get;set;}
    [Required]
    [GreaterThanZero]
    public int? Calories {get;set;}
    [Required]
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

//~~~~~~~~~~~~~~~~ Relationships ~~~~~~~~~~~~~~~~
    public int ChefId {get;set;}
    public Chef? Chef {get;set;}
}

public class GreaterThanZero : ValidationAttribute 
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null || ((int)value) <= 0)
        {
            return new ValidationResult("Please enter a value greater than zero.");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}
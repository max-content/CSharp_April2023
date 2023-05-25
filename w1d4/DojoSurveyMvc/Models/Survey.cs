#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurveyMvc.Models;


public class Survey 
{
    [Required(ErrorMessage = "Name is required.")]
    [MinLength(2, ErrorMessage ="Name must be 2 or more letters.")]

    public string Name {get;set;}
    [Required(ErrorMessage = "City is required.")]

    public string City {get;set;}
    [Required(ErrorMessage = "Language is required.")]
    public string Language {get;set;}

    [MaxLength(20, ErrorMessage = "Your comment must be less than 20 characters.")]
    public string? Comments {get;set;}
}
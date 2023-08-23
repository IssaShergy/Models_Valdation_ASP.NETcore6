using System.ComponentModel.DataAnnotations;
using ModelsValdationExmample.CustomValedator;
namespace ModelsValdationExmample.Models
{
    public class Person
    {
        [Required(ErrorMessage = "{0}person cant null")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        [RegularExpression("^[A-Za-z .]$", ErrorMessage = "{0} should contain only alphabets,space and dot (.)")]
        public string? PersonName { get; set; }
        [EmailAddress(ErrorMessage = "{0} shoud be aproper email email  address")]
        [Required(ErrorMessage = "{0} cant be blank")]
        public string? Email { get; set; }
        [Phone(ErrorMessage = "{0} should contain 10 digits")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "{0} cant be blank")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "{0} cant be blank")]
        [Compare("Password", ErrorMessage = "{0} and {1} do not match")]
        [Display(Name = "Re-enter Password")]
        public string? ConfirmPassword { get; set; }
        [Range(0, 999.99, ErrorMessage = "{0} should be between {1} and {2}")]
        public float? Prise { get; set; }
        [MinimumYearValdation(2000, ErrorMessage = "Date of Birth should not be newer than 2000,{0}")]
        public DateTime DateofBirth{ get; set; }

        public DateTime FromeDate { get; set; }
        [DateRangeValidator("FromeDate",ErrorMessage="")]
        public DateTime ToDate { get; set; }
        public   override string ToString()
        {

            return $"person object - person name: {PersonName} , Email: {Email} ,Phone :{Phone} ,Password:{Password}, price :{Prise}";
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ModelsValdationExmample.CustomValedator
{
    public class MinimumYearValdation:ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000;
        /// <summary>
        /// parmeterless constructor
        /// </summary>
        public MinimumYearValdation()
        {
            
        }
        /// <summary>
        /// Parmetrized constructor 
        /// </summary>
        /// <param name="minimumYear"></param>
        public MinimumYearValdation(int minimumYear)
        {
            MinimumYear=minimumYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value!=null)
            {
                DateTime date = (DateTime)value;
                if (date.Year>= MinimumYear)
                {
                    return new ValidationResult(string.Format( ErrorMessage,MinimumYear));
                }
                else
                {
                    return ValidationResult.Success;
                }
                
            }return null;
        }
    }
}

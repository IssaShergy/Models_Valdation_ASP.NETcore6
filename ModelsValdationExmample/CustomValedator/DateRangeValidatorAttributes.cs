using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace ModelsValdationExmample.CustomValedator
{
    public class DateRangeValidatorAttributes:ValidationAttribute
    {
        public string OtherProertyNmae { get; set; }
        public DateRangeValidatorAttributes(string otherProertyNmae)
        {

            this.OtherProertyNmae =  otherProertyNmae;

        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
             if (value != null) {
                //get to date

                    DateTime to_date = Convert.ToDateTime(value);
                ///get to_date
                    PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherProertyNmae);
                if (otherProperty != null)
                {

               
                DateTime from_date=  Convert.ToDateTime(  otherProperty.GetValue(validationContext.ObjectInstance));
                    if (from_date > to_date)
                    {
                        return new ValidationResult(ErrorMessage, new string[] { OtherProertyNmae, validationContext.MemberName });
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                    }
                }
                return null;
            }

            return null;
        }
         
    }
}

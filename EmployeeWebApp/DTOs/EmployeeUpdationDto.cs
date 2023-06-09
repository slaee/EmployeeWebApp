using System.ComponentModel.DataAnnotations;

namespace EmployeeWebApp.DTOs
{
    public class EmployeeUpdationDto
    {
        public long ID { get; set; }
        [Required(ErrorMessage = "Contact number is required.")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "Invalid contact number.")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "EmailAddress is required.")]
        [RegularExpression(
            @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$",
            ErrorMessage = "The email address is not valid"
        )]
        public string EmailAddress { get; set; }
    }
}
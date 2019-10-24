using System.ComponentModel.DataAnnotations;

namespace redtag90.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Enter your email")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string loginEmail {get;set;}

        [Required(ErrorMessage = "Enter your password")]
        [MinLength(8, ErrorMessage = "Must be at least 8 characters")]
        public string loginPassword {get;set;}
    }
}
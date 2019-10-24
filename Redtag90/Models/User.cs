using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace redtag90.Models
{
    public class User 
    {
        [Key]
        public int UserId {get;set;}

        [Required(ErrorMessage = "Please enter your first name")]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must only contain letters")]
        public string first_name {get;set;}

        [Required(ErrorMessage = "Please enter your last name")]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must contain only letters")]
        public string last_name {get;set;}

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage ="Enter a valid email address")]
        public string email {get;set;}

        [Required(ErrorMessage = "Please enter a password")]
        [MinLength(8, ErrorMessage = "Must be at least 8 characters")]
        [DataType(DataType.Password)]
        public string password {get;set;}

        [Compare("password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string confirm_password {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }
}


using System.ComponentModel.DataAnnotations;

/// <summary>
/// class used to process data from the login form (so not in the db)
/// </summary>

namespace HelpDeskWebapp.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email {get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}
    }
}
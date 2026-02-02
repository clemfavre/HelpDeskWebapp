

using System.ComponentModel.DataAnnotations;

/// <summary>
/// class used to process data from the registration form (so not in the db)
/// </summary>

namespace HelpDeskWebapp.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Pseudo {get; set;}
        [Required]
        [EmailAddress]
        public string Email {get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}
    }
}
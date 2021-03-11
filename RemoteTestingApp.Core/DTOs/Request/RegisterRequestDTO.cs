using System.ComponentModel.DataAnnotations;


namespace RemoteTestingApp.Core.DTOs.Request
{
    public class RegisterRequestDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "You must specify password between 6 to 20 characters")]
        public string password { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "FirstName cannot be null")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "LastName cannot be null")]
        public string LastName { get; set; }
    }
}

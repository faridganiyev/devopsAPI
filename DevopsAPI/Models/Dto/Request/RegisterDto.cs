using System.ComponentModel.DataAnnotations;

namespace DevopsAPI.Models.Dto.Request
{
    public struct RegisterDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Activity { get; set; }
        [Required]
        public string UseFor { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        public string RetryPassword { get; set; }
    }
}

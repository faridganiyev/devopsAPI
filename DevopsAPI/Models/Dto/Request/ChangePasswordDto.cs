using System.ComponentModel.DataAnnotations;

namespace DevopsAPI.Models.Dto.Request
{
    public struct ChangePasswordDto
    {
        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Compare("NewPassword")]
        public string RetryPassword { get; set; }
    }
}

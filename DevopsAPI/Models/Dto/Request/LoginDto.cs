using System.ComponentModel.DataAnnotations;

namespace DevopsAPI.Models.Dto.Request
{
    public struct LoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

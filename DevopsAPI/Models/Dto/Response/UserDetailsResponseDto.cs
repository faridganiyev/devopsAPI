using DevopsAPI.Data.Entities;

namespace DevopsAPI.Models.Dto.Response
{
    public class UserDetailsResponseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string? Address { get; set; }
        public string? Picture { get; set; }
    }
}

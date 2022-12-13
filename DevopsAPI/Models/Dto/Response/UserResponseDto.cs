namespace DevopsAPI.Models.Dto.Response
{
    public class UserResponseDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public DateOnly CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool EmailConfirmed { get; set; }
        public UserDetailsResponseDto Details { get; set; }
        public UserActivityResponseDto Activity { get; set; }
    }
}

namespace DevopsAPI.Models.Dto.Response
{
    public struct UserClaim
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public DateOnly CreatedDate { get; set; }
    }
}

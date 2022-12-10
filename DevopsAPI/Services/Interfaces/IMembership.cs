namespace DevopsAPI.Services.Interfaces
{
    public interface IMembership
    {
        Task<string> GetUserMembershipAsync(string userId);
    }
}

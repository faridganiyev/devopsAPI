using DevopsAPI.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace DevopsAPI.Data.Repository
{
    public static class UserManagerExtensions
    {
        public static async Task<bool> DeactivateAsync(this UserManager<AppUser> userManager, string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            user.IsActive = false;
            return (await userManager.UpdateAsync(user)).Succeeded;
        }

        public static async Task<bool> ReactivateAsync(this UserManager<AppUser> userManager, string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            user.IsActive = true;
            return (await userManager.UpdateAsync(user)).Succeeded;
        }
    }
}

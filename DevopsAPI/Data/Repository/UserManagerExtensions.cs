using DevopsAPI.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DevopsAPI.Data.Repository
{
    public static class UserManagerExtensions
    {
        public static async Task<bool> DeactivateAsync(this UserManager<AppUser> userManager, string id)
        {
            var user = await userManager.FindByIdAsync(id);
            user.IsActive = false;
            return (await userManager.UpdateAsync(user)).Succeeded;
        }

        public static async Task<bool> ReactivateAsync(this UserManager<AppUser> userManager, string id)
        {
            var user = await userManager.FindByIdAsync(id);
            user.IsActive = true;
            return (await userManager.UpdateAsync(user)).Succeeded;
        }

        public static async Task<AppUser?> GetByIdAsync(this UserManager<AppUser> userManager, string id)
                                            => await userManager.Users
                                                            .Where(x => x.Id == id)
                                                            .Select(x => new AppUser
                                                            {
                                                                Id = x.Id,
                                                                Email = x.Email,
                                                                EmailConfirmed = x.EmailConfirmed,
                                                                CreatedDate = x.CreatedDate,
                                                                IsActive = x.IsActive,
                                                                Details = x.Details,
                                                                Activity = x.Activity
                                                            })
                                                            .FirstOrDefaultAsync();

    }
}

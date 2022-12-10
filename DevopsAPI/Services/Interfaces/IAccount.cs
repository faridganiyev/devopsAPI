using DevopsAPI.Models.Base;
using DevopsAPI.Models.Dto.Request;

namespace DevopsAPI.Services.Interfaces
{
    public interface IAccount
    {
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="dto">Data transfer object for register parameters</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<Response> CreateAsync(RegisterDto dto);

        /// <summary>
        /// Update personal info
        /// </summary>
        /// <returns></returns>
        Task<Response> UpdateAsync();

        /// <summary>
        /// Update profile picture
        /// </summary>
        /// <returns></returns>
        Task<Response> UpdatePictureAsync();

        /// <summary>
        /// Change current password
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dto">Data transfer object for password info</param>
        /// <returns></returns>
        Task<Response> ChangePasswordAsync(string userId, ChangePasswordDto dto);
        Task<Response> VerifyEmailAsync();
        Task<Response> DeleteAsync(string userId);

        /// <summary>
        /// Deactivate account
        /// </summary>
        /// <returns></returns>
        Task<Response> DeactivateAsync(string userId);

        /// <summary>
        /// Reactivate account
        /// </summary>
        /// <returns></returns>
        Task<Response> ReactivateAsync(string userId);

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="dto">Data transfer object for login credentials</param>
        /// <returns></returns>
        Task<Response> LoginAsync(LoginDto dto);

    }
}

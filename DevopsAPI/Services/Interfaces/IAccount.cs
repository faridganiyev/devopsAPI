using DevopsAPI.Models.Base;
using DevopsAPI.Models.Dto.Request;

namespace DevopsAPI.Services.Interfaces
{
    public interface IAccount
    {
        /// <summary>
        /// Get full info of user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response> GetByIdAsync(string id);

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="dto">Data transfer object for register parameters</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<Response> CreateAsync(RegisterDto dto);

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="dto">Data transfer object for login credentials</param>
        /// <returns></returns>
        Task<Response> LoginAsync(LoginDto dto);

        /// <summary>
        /// Update personal info
        /// </summary>
        /// <returns></returns>
        Task<Response> UpdateAsync();

        /// <summary>
        /// Update profile picture
        /// </summary>
        /// <returns></returns>
        Task<Response> UpdatePictureAsync(string id, IFormFile photo);

        /// <summary>
        /// Change current password
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dto">Data transfer object for password info</param>
        /// <returns></returns>
        Task<Response> ChangePasswordAsync(string id, ChangePasswordDto dto);

        /// <summary>
        /// Verify email
        /// </summary>
        /// <returns></returns>
        Task<Response> VerifyEmailAsync(string id, string verificationtoken);

        /// <summary>
        /// Delete account
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Response> DeleteAsync(string id);

        /// <summary>
        /// Deactivate account
        /// </summary>
        /// <returns></returns>
        Task<Response> DeactivateAsync(string id);

        /// <summary>
        /// Reactivate account
        /// </summary>
        /// <returns></returns>
        Task<Response> ReactivateAsync(string id);
    }
}

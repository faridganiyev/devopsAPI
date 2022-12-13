using DevopsAPI.Data.Entities;
using DevopsAPI.Data.Repository;
using DevopsAPI.Models.Base;
using DevopsAPI.Models.Dto.Request;
using DevopsAPI.Models.Dto.Response;
using DevopsAPI.Models.Others;
using DevopsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace DevopsAPI.Services.Implementations
{
    public class AccountService : IAccount
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IToken _token;
        private readonly IMailer _mailer;
        private readonly IMembership _membership;
        private readonly IHttpContextAccessor _contextAccessor;

        public AccountService(UserManager<AppUser> userManager,
                              IToken token,
                              IMailer mailer,
                              IMembership membership,
                              IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _token = token;
            _mailer = mailer;
            _membership = membership;
            _contextAccessor = contextAccessor;
        }

        public async Task<Response> ChangePasswordAsync(string userId, ChangePasswordDto dto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(! (await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword)).Succeeded);
                return (await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword)).Succeeded
                    ? new Response(true)
                    : new Response("Password is not valid");
        }

        public async Task<Response> CreateAsync(RegisterDto dto)
        {
            var user = new AppUser
            {
                Email = dto.Email,
                UserName = dto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Details = new UserInfo
                {
                    Name = dto.Name,
                    Surname = dto.Surname,
                },
                Activity = new UserActivity
                {
                    Title = dto.Activity,
                    UseFor = dto.UseFor
                },
                Membership = new Membership
                {
                    StartDate = DateOnly.FromDateTime(DateTime.Now),
                    DueDate = DateOnly.FromDateTime(DateTime.Now.AddYears(1)),
                }
            };
            var identityResult = await _userManager.CreateAsync(user, dto.Password);
            if (!identityResult.Succeeded)
                throw new Exception("An error occured");

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var request = _contextAccessor?.HttpContext?.Request;
            _mailer.SendAsHtml(user.Email, new MailUIContent
            {
                title = "Email Confirmation",
                description = "Click button to confirm email",
                buttonTitle = "Confirm",
                link = $"{request?.Scheme}://{request?.Host}/api/v1/account/verify-email?id={user.Id}&verificationToken={token}",
                copyright = "Dind.io"
            }, MailTemplate.email_confirmation);
            return new Response(HttpStatusCode.Created, new
            {
                user.Id,
                user.CreatedDate
            });
        }

        public async Task<Response> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user is null)
                return new Response("user not found");
            var isValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!isValid)
            {
                _ = await _userManager.AccessFailedAsync(user);
                return new Response("password is not valid");
            }

            var membership = await _membership.GetUserMembershipAsync(user.Id) ?? "Free";

            var token = _token.CreateToken(user, membership);
            return new Response(data: token);
        }

        public async Task<Response> GetByIdAsync(string id)
        {
            var user = await _userManager.GetByIdAsync(id);
            if (user is null)
                return new Response("User not found.");
            return new Response(new UserResponseDto
            {
                Id = id,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                CreatedDate = user.CreatedDate,
                IsActive = user.IsActive,
                Details = new UserDetailsResponseDto
                {
                    Name = user.Details.Name,
                    Surname = user.Details.Surname,
                    BirthDate = user.Details.BirthDate,
                    Gender = user.Details.Gender,
                    Address = user.Details.Address,
                    Picture = user.Details.Picture
                },
                Activity = new UserActivityResponseDto
                {
                    Title = user.Activity.Title,
                    UseFor = user.Activity.UseFor
                }
            });
        }

        public async Task<Response> ReactivateAsync(string userId) => new Response(await _userManager.ReactivateAsync(userId));

        public async Task<Response> DeactivateAsync(string userId) => new Response(await _userManager.DeactivateAsync(userId));

        public async Task<Response> DeleteAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
                return user is null
                    ? new Response("User not found")
                    : new Response((await _userManager.DeleteAsync(user)).Succeeded);
        }

        public async Task<Response> VerifyEmailAsync(string id, string verificationToken)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is null)
                return new Response("User not found.");
            if (user.EmailConfirmed)
                return new Response("The user has already verified his email.");
            return (await _userManager.ConfirmEmailAsync(user, verificationToken)).Succeeded
                ? new Response(true)
                : new Response("An error occured.");
        }

        public async Task<Response> UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Response> UpdatePictureAsync(string id, IFormFile photo)
        {
            throw new NotImplementedException();
        }
    }
}

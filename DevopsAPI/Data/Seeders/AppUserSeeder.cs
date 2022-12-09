using Bogus;
using DevopsAPI.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace DevopsAPI.Data.Seeders
{
    public class AppUserSeeder
    {
        public List<AppUser> AppUsers { get; set; }


        public AppUserSeeder()
        {

            //info
            var userInfo = new Faker<UserInfo>()
                //.RuleFor(ui => ui.UserId, f => f.PickRandom(AppUsers).Id)
                .RuleFor(ui => ui.Address, f => f.Address.FullAddress())
                .RuleFor(ui => ui.BirthDate, f => DateOnly.FromDateTime(f.Person.DateOfBirth))
                .RuleFor(ui => ui.Gender, f => Gender.male)
                .RuleFor(ui => ui.Name, f => f.Person.FirstName)
                .RuleFor(ui => ui.Surname, f => f.Person.LastName)
                .RuleFor(ui => ui.Picture, f => f.Person.Avatar);

            //activity
            var userActivity = new Faker<UserActivity>()
                .RuleFor(ui => ui.UserId, f => f.PickRandom(AppUsers).Id)
                .RuleFor(ui => ui.Title, f => f.Name.JobTitle());

            var passwordHasher = new PasswordHasher<AppUser>();

            //user
            Faker<AppUser> fakerUser = new Faker<AppUser>()
                .StrictMode(true)
                .RuleFor(u => u.Id, f => f.Random.Uuid().ToString())
                .RuleFor(u => u.Email, f => f.Person.Email)
                .RuleFor(u => u.PhoneNumber, f => f.Person.Phone)
                .RuleFor(u => u.UserName, f => f.Person.UserName)
                .RuleFor(u => u.AccessFailedCount, f => f.Random.Number(1, 5))
                .RuleFor(u => u.ConcurrencyStamp, Guid.NewGuid().ToString())
                .RuleFor(u => u.SecurityStamp, Guid.NewGuid().ToString())
                .RuleFor(u => u.LockoutEnabled, false)
                .RuleFor(u => u.PhoneNumberConfirmed, true)
                .RuleFor(u => u.EmailConfirmed, true)
                .RuleFor(u => u.PasswordHash, f => f.Random.Hash())
                .RuleFor(u => u.CreatedDate, f => DateOnly.FromDateTime(DateTime.Now))
                .RuleFor(u => u.ModifiedDate, f => null)
                .RuleFor(u => u.LockoutEnd, f => null)
                .RuleFor(u => u.TwoFactorEnabled, f => false)
                .RuleFor(u => u.Details, f => userInfo)
                .RuleFor(u => u.Activity, f => userActivity)
                .RuleFor(u => u.Membership, f => null)
                .RuleFor(u => u.Payments, f => null)
                .RuleFor(u => u.QuizResults, f => null)
                .RuleFor(u => u.ChallangeResults, f => null)
                ;

            AppUsers = fakerUser.Generate(10);





        }
    }
}

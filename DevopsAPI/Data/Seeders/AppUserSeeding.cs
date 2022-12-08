using Bogus;
using DevopsAPI.Data.Entities;

namespace DevopsAPI.Data.Seeders
{
    public class AppUserSeeding
    {
        public List<AppUser> AppUsers { get; set; }
        public List<UserInfo> UserInfos { get; set; }
        public List<UserActivity> UserActivities { get; set; }


        public AppUserSeeding()
        {
            Faker<AppUser> fakerUser = new Faker<AppUser>()
                .StrictMode(true)
                .RuleFor(u => u.Id, f => f.Random.Uuid().ToString())
                .RuleFor(u => u.Email, f => f.Person.Email)
                .RuleFor(u => u.PhoneNumber, f => f.Person.Phone)
                .RuleFor(u => u.UserName, f => f.Person.UserName)
                .RuleFor(u => u.AccessFailedCount, f => f.Random.Number(1, 5))
                .RuleFor(u=>u.ConcurrencyStamp, Guid.NewGuid().ToString())
                .RuleFor(u=>u.SecurityStamp, Guid.NewGuid().ToString());

            AppUsers = fakerUser.Generate(10);

            //info
            Faker<UserInfo> fakerUserInfo = new Faker<UserInfo>()
                .RuleFor(ui => ui.UserId, f => f.PickRandom(AppUsers).Id)
                .RuleFor(ui => ui.Address, f => f.Address.FullAddress())
                .RuleFor(ui => ui.BirthDate, f => DateOnly.FromDateTime(f.Person.DateOfBirth))
                .RuleFor(ui => ui.Gender, Gender.male)
                .RuleFor(ui => ui.Name, f => f.Person.FirstName)
                .RuleFor(ui => ui.Surname, f => f.Person.LastName)
                .RuleFor(ui => ui.Picture, f => f.Person.Avatar);

            UserInfos = fakerUserInfo.Generate(10);

            //activity
            Faker<UserActivity> fakerUserActivity = new Faker<UserActivity>()
                .RuleFor(ui => ui.UserId, f => f.PickRandom(AppUsers).Id)
                .RuleFor(ui => ui.Title, f => f.Name.JobTitle());

            UserInfos = fakerUserInfo.Generate(10);

        }
    }
}

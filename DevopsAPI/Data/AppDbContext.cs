using DevopsAPI.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DevopsAPI.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<UserActivity> UserActivities { get; set; }
        public virtual DbSet<IdentityRole> Roles { get; set; }
        public virtual DbSet<IdentityUserRole<string>> UserRoles { get; set; }
        public virtual DbSet<IdentityUserClaim<string>> UserClaims { get; set; }
        public virtual DbSet<IdentityUserToken<string>> UserTokens { get; set; }
        public virtual DbSet<IdentityRoleClaim<string>> RoleClaims { get; set; }
        public virtual DbSet<IdentityUserLogin<string>> UserLogins { get; set; }
        public virtual DbSet<Pricing> Pricings { get; set; }
        public virtual DbSet<PricingOpportunities> PricingOpportunities { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<Container> Containers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<QuizTicket> QuizTickets { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<QuizVariant> QuizVariants { get; set; }
        public virtual DbSet<QuizResult> QuizResults { get; set; }
        public virtual DbSet<ChallangeTicket> ChallangeTickets { get; set; }
        public virtual DbSet<Challange> Challanges { get; set; }
        public virtual DbSet<ChallangeTask> ChallangeTasks { get; set; }
        public virtual DbSet<TaskResult> TaskResults { get; set; }
        public virtual DbSet<ChallangeResult> ChallangeResults { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

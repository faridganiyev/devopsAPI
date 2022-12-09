using Microsoft.AspNetCore.Identity;

namespace DevopsAPI.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            ChallangeResults = new HashSet<ChallangeResult>();
            QuizResults = new HashSet<QuizResult>();
            Payments = new HashSet<Payment>();
        }
        public DateOnly CreatedDate { get; set; }
        public DateOnly? ModifiedDate { get; set; }
        public virtual UserInfo Details { get; set; }
        public virtual UserActivity Activity { get; set; }
        public virtual Membership Membership { get; set; }
        public virtual ICollection<ChallangeResult> ChallangeResults { get; set;}
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<QuizResult> QuizResults { get; set; }
    }
}

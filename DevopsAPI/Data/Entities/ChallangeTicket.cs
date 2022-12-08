namespace DevopsAPI.Data.Entities
{
    public class ChallangeTicket : BaseEntity
    {
        public ChallangeTicket()
        {
            Challanges = new HashSet<Challange>();
        }
        public int CategoryId { get; set; }
        public string No { get; set; }
        public string Time { get; set; }
        public QuizLevel Level { get; set; } 

        public virtual Category Category { get; set; }
        public virtual ICollection<Challange> Challanges { get; set; }
    }
}

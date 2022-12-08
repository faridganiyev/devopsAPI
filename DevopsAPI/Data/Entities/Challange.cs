namespace DevopsAPI.Data.Entities
{
    public class Challange : BaseEntity
    {
        public Challange()
        {
            Tasks = new HashSet<ChallangeTask>();
            Results = new HashSet<ChallangeResult>();
        }
        public int TicketId { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
        public virtual ChallangeTicket Ticket { get; set; }
        public virtual ICollection<ChallangeTask> Tasks { get; set; }
        public virtual ICollection<ChallangeResult> Results { get; set; }
    }
}

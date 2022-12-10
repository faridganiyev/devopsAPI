namespace DevopsAPI.Data.Entities
{
    public class Command : BaseEntity
    {
        public int ContainerId { get; set; }
        public string CommandText { get; set; }

        public virtual Container Container { get; set; }
    }
}

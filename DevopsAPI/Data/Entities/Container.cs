using DevopsAPI.Models.Base;

namespace DevopsAPI.Data.Entities
{
    public class Container : BaseEntity
    {
        public Container()
        {
            Commands = new HashSet<Command>();
        }
        public string Name { get; set; }
        public string Port { get; set; }
        public string Location { get; set; }
        public bool IsAlive { get; set; }
        public int LifeTime { get; set; }
        public DateTime DeadDate { get; set; }
        public ContainerType Type { get; set; }

        public ICollection<Command> Commands { get; set; }
    }
}

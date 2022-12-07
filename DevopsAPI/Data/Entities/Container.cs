using DevopsAPI.Models;

namespace DevopsAPI.Data.Entities
{
    public class Container : BaseEntity
    {
        public string Name { get; set; }
        public string Port { get; set; }
        public string Location { get; set; }
        public bool IsAlive { get; set; }
        public int LifeTime { get; set; }
        public DateTime DeadDate { get; set; }
        public ContainerType Type { get; set; }
    }
}

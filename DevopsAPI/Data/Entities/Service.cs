using DevopsAPI.Models.Base;

namespace DevopsAPI.Data.Entities
{
    public class Service : BaseEntity
    {
        public ContainerType Name { get; set; }
        public string Script { get; set; }
    }
}

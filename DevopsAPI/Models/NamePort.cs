namespace DevopsAPI.Models
{
    public class NamePort
    {
        public string Name { get; set; }
        public int Port { get; set; }

        public NamePort(string name, int port)
        {
            Name = name;
            Port = port;
        }
    }
}

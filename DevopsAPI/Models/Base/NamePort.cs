namespace DevopsAPI.Models.Base
{
    public class NamePort
    {
        /// <summary>
        /// Name of container
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Port of container
        /// </summary>
        public int Port { get; set; }

        public NamePort(string name, int port)
        {
            Name = name;
            Port = port;
        }
    }
}

using DevopsAPI.Models.Base;
using System.Text;

namespace DevopsAPI.Helper
{
    public class Utility
    {
        /// <summary>
        /// Recursion for generate unique name and port
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static (string names, int ports) GenerateNameAndPort(string? characters)
        {
            var nameBuilder = new StringBuilder();
            var chars = characters?.ToCharArray();
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                nameBuilder.Append(chars?[rand.Next(0, chars.Length - 1)]);
            }
            var name = nameBuilder.ToString();
            var port = rand.Next(8001, 65535);

            StaticStore.Create();
            return !StaticStore.Add(new NamePort(name, port))
                ? GenerateNameAndPort(characters)
                : (name, port);
        }
    }
}

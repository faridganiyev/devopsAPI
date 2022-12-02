using DevopsAPI.Models;

namespace DevopsAPI.Helper
{
    internal static class StaticStore
    {
        internal static HashSet<NamePort>? NamePort;
        internal static void Create() => NamePort ??= new HashSet<NamePort>();
        internal static bool Add(NamePort item) => NamePort.Add(item);
    }
}

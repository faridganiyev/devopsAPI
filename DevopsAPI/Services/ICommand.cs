namespace DevopsAPI.Services
{
    public interface ICommand
    {
        Task<bool> ExecuteProcess(string command);
    }
}

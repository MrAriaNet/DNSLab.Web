namespace DNSLab.Web.Interfaces.Repositories
{
    public interface IToolRepository
    {
        Task<string?> Ping(string host);
        Task<bool> IsPortOpen(string host, int port);
    }
}

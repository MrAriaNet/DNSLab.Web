namespace DNSLab.Web.Interfaces.Repositories
{
    public interface IToolRepository
    {
        Task<string?> Ping(string host);
    }
}

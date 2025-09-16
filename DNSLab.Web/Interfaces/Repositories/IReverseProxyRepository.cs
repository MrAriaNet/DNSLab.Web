namespace DNSLab.Web.Interfaces.Repositories
{
    public interface IReverseProxyRepository
    {
        Task<string?> GetClientToken();
        Task<string?> RevokeClientToken();
    }
}

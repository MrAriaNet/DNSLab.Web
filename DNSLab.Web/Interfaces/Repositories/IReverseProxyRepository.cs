using DNSLab.Web.DTOs.Repositories.ReeverseProxy;

namespace DNSLab.Web.Interfaces.Repositories
{
    public interface IReverseProxyRepository
    {
        Task<string?> GetClientToken();
        Task<string?> RevokeClientToken();

        Task<IEnumerable<ReverseProxyTunnelDTO>?> GetActiveTunnels();
    }
}

using DNSLab.Web.DTOs.Repositories.Record;
using DNSLab.Web.DTOs.Repositories.ReeverseProxy;
using DNSLab.Web.Interfaces.Providers;
using DNSLab.Web.Interfaces.Repositories;

namespace DNSLab.Web.Repositories
{
    public class ReverseProxyRepository(IHttpServiceProvider _HttpServiceProvider) : IReverseProxyRepository
    {
        const string APIController = "ReverseProxy";

        public async Task<IEnumerable<ReverseProxyTunnelDTO>?> GetActiveTunnels()
        {
            return await _HttpServiceProvider.Get<IEnumerable<ReverseProxyTunnelDTO>?>($"{APIController}/GetActiveTunnels");
        }

        public async Task<string?> GetClientToken()
        {
            return await _HttpServiceProvider.Get<string?>($"{APIController}/GetClientToken");
        }

        public async Task<string?> RevokeClientToken()
        {
            return await _HttpServiceProvider.Put<string?>($"{APIController}/RevokeClientToken");
        }
    }
}

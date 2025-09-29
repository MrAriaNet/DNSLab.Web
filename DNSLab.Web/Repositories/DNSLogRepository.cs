using DNSLab.Web.DTOs.Repositories.DNSLog;
using DNSLab.Web.Interfaces.Providers;
using DNSLab.Web.Interfaces.Repositories;

namespace DNSLab.Web.Repositories
{
    public class DNSLogRepository(IHttpServiceProvider _HttpServiceProvider) : IDNSLogRepository
    {
        const string APIController = "DNSLog";
        public async Task<IEnumerable<QueryLogDTO>?> GetLastQueries(Guid zoneId)
        {
            return await _HttpServiceProvider.Get<IEnumerable<QueryLogDTO>?>($"{APIController}/GetLastQueries?zoneId={zoneId}");
        }
    }
}

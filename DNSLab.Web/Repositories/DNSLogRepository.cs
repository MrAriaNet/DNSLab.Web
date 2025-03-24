using DNSLab.Web.DTOs.Repositories.DNSLog;
using DNSLab.Web.Enums;
using DNSLab.Web.Interfaces.Providers;
using DNSLab.Web.Interfaces.Repositories;

namespace DNSLab.Web.Repositories
{
    public class DNSLogRepository(IHttpServiceProvider _HttpServiceProvider) : IDNSLogRepository
    {
        const string APIController = "DNSLog";
    
        public async Task<long?> GetTotalRequest(string qName)
        {
            return await _HttpServiceProvider.Get<long?>($"{APIController}/GetTotalRequest?qName={qName}");
        }

        public async Task<IEnumerable<TimeAndCountDTO>?> GetTotalRequestChartByTime(string qName)
        {
            return await _HttpServiceProvider.Get<IEnumerable<TimeAndCountDTO>?>($"{APIController}/GetTotalRequestChartByTime?qName={qName}");
        }
    }
}

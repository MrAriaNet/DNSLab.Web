using DNSLab.Web.DTOs.Repositories.DNSLog;
using DNSLab.Web.Enums;
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

        public async Task<IEnumerable<QueryCountDTO>?> GetQueriesChart(Guid zoneId)
        {
            return await _HttpServiceProvider.Get<IEnumerable<QueryCountDTO>?>($"{APIController}/GetQueriesChart?zoneId={zoneId}");
        }

        public async Task<IEnumerable<QueryCountDTO>?> GetQueriesByRecordChart(Guid recordId, RecordTypeEnum recordType)
        {
            return await _HttpServiceProvider.Get<IEnumerable<QueryCountDTO>?>($"{APIController}/GetQueriesByRecordChart?recordId={recordId}&recordType={(int)recordType}");
        }

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

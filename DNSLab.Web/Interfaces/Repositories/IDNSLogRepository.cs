using DNSLab.Web.DTOs.Repositories.DNSLog;
using DNSLab.Web.Enums;

namespace DNSLab.Web.Interfaces.Repositories
{
    public interface IDNSLogRepository
    {
        Task<IEnumerable<QueryLogDTO>?> GetLastQueries(Guid zoneId);
        Task<IEnumerable<QueryCountDTO>?> GetQueriesChart(Guid zoneId);
        Task<long?> GetTotalRequest(string qName);
        Task<IEnumerable<TimeAndCountDTO>?> GetTotalRequestChartByTime(string qName);
        Task<IEnumerable<QueryCountDTO>?> GetQueriesByRecordChart(Guid recordId , RecordTypeEnum recordType);
    }
}

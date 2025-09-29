using DNSLab.Web.DTOs.Repositories.DNSLog;
using DNSLab.Web.Enums;

namespace DNSLab.Web.Interfaces.Repositories
{
    public interface IDNSLogRepository
    {
        Task<IEnumerable<QueryLogDTO>?> GetLastQueries(Guid zoneId);
        Task<IEnumerable<QueryCountDTO>?> GetQueriesChart(Guid zoneId);
        Task<IEnumerable<QueryCountDTO>?> GetQueriesByRecordChart(Guid recordId , RecordTypeEnum recordType);
    }
}

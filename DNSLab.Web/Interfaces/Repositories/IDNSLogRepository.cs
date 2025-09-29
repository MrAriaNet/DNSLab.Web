using DNSLab.Web.DTOs.Repositories.DNSLog;

namespace DNSLab.Web.Interfaces.Repositories
{
    public interface IDNSLogRepository
    {
        Task<IEnumerable<QueryLogDTO>?> GetLastQueries(Guid zoneId);
        Task<IEnumerable<QueryCountDTO>?> GetQueriesChart(Guid zoneId);
    }
}

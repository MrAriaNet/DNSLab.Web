using DNSLab.Web.DTOs.Repositories.DNSLog;

namespace DNSLab.Web.Interfaces.Repositories
{
    public interface IDNSLogRepository
    {
        Task<IEnumerable<QueryLogDTO>?> GetLastQueries(Guid zoneId);
    }
}

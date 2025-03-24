using DNSLab.Web.DTOs.Repositories.DNSLog;
using DNSLab.Web.Enums;

namespace DNSLab.Web.Interfaces.Repositories
{
    public interface IDNSLogRepository
    {
        Task<long?> GetTotalRequest(string qName);
        Task<IEnumerable<TimeAndCountDTO>?> GetTotalRequestChartByTime(string qName);
        Task<IEnumerable<ClientIPAndCountDTO>?> GetClientIPAndCounts(string qName);
    }
}

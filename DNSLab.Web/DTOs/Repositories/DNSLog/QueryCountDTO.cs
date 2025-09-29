using DNSLab.Web.Enums;

namespace DNSLab.Web.DTOs.Repositories.DNSLog
{
    public class QueryCountDTO
    {
        public int Count { get; set; }
        public QueryTypeEnum Type { get; set; }
        public TimeSpan Time { get; set; }
    }
}

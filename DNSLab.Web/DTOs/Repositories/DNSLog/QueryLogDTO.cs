using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSLab.Web.DTOs.Repositories.DNSLog
{
    public class QueryLogDTO
    {
        public string? Server { get; set; }
        public DateTime TimeStamp { get; set; }
        public string ClientIP { get; set; }
        public byte Protocol { get; set; }
        public byte ResponseType { get; set; }
        public float? ResponseRTT { get; set; }
        public byte RCode { get; set; }
        public string? QName { get; set; }
        public byte? QType { get; set; }
        public byte? QClass { get; set; }
        public string? Answer { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSLab.Web.DTOs.Repositories.DNSLog
{
    public class TimeAndCountDTO
    {
        public int Count { get; set; }
        public TimeSpan Time { get; set; }
    }
}

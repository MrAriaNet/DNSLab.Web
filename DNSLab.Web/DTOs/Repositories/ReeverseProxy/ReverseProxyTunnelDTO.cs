using DNSLab.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSLab.Web.DTOs.Repositories.ReeverseProxy
{
    public class ReverseProxyTunnelDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TunnelType Type { get; set; }
        public string LocalIp { get; set; }
        public int LocalPort { get; set; }
        public int RemotePort { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSLab.Web.Enums
{
    public enum ZoneStatusEnum
    {
        Pending = 1,
        Active = 2,
        Warning = 3,
        Suspended = 4,
        Expired = 5,
        Deleted = 6,
    }
}

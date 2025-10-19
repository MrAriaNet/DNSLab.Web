using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSLab.Web.DTOs.Repositories.Bundle
{
    public class UserBundleDTO
    {
        public Guid Id { get; set; }
        public BundleDTO Bundle { get; set; }
        public BundleDurationDTO Duration { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long TotalPrice { get; set; }

        public UserInfoDTO? User { get; set; }
    }
}

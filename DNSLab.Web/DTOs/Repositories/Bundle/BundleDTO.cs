using DNSLab.Shared.DTOs.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSLab.Web.DTOs.Repositories.Bundle
{
    public class BundleDTO
    {
        public Guid Id { get; set; }
        public List<BundleFeatureDTO> Features { get; set; }
        public BundleDurationDTO Duration { get; set; }
    }
}

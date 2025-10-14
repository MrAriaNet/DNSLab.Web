using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSLab.Web.DTOs.Repositories.Bundle
{
    public class BundleFeatureDTO
    {
        public int? Count { get; set; }
        public bool? IsEnable { get; set; }

        public FeatureDTO Feature { get; set; }
    }
}

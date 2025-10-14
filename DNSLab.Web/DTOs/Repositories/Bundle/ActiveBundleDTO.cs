using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSLab.Web.DTOs.Repositories.Bundle
{
    public class ActiveBundleDTO
    {
        public List<ActiveFeatureDTO> Features { get; set; }
        public int DurationId { get; set; }
    }

    public class ActiveFeatureDTO
    {
        public int Id { get; set; }
        public int? RequestCount { get; set; }
    }
}

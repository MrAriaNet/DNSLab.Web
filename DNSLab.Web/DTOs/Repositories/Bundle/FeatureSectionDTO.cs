using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSLab.Web.DTOs.Repositories.Bundle
{
    public class FeatureSectionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<FeatureDTO> Features { get; set; }
    }
}

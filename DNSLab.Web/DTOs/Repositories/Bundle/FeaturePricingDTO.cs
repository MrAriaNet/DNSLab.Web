using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSLab.Web.DTOs.Repositories.Bundle
{
    public class FeaturePricingDTO
    {
        public int Id { get; set; }
        public int? UnitPrice { get; set; }
        public int? FreeCount { get; set; }
        public int? ActivationPrice { get; set; }
        public bool? IsFree { get; set; }
    }
}

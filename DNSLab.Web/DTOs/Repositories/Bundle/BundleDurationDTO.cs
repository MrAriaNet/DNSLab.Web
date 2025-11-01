using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSLab.Web.DTOs.Repositories.Bundle
{
    public class BundleDurationDTO
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }

        public DurationDiscountDTO Discount { get; set; }
    }
}

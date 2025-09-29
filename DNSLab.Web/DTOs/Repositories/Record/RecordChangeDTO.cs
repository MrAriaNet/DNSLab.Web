using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSLab.Web.DTOs.Repositories.Record
{
    public class RecordChangeDTO
    {
        public DateTime TimeStamp { get; set; }
        public int OperationId { get; set; }
        public BaseRecordDTO? PreviousData { get; set; }
        public BaseRecordDTO? CurrentData { get; set; }
        public bool IsProcessed { get; set; }
    }
}

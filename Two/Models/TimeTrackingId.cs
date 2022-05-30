using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Two.Models
{
    public class TimeTrackingId : BaseModel
    {
        public int? UserId { get; set; }
        public int IssueId { get; set; }
        public DateTime ExecutionDate { get; set; }
        public int Hours { get; set; }
        [ForeignKey(nameof(IssueId))]
        public virtual Issue? Issue { get; set; }
    }
}

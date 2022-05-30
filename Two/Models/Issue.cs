using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Two.Models
{
    public class Issue :BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AutgorId { get; set; }
        public int? ExecutorId { get; set; }
        public int PropertyId { get; set; }

        [ForeignKey(nameof(AutgorId))]
        public virtual User? Author { get; set; }

        [ForeignKey(nameof(ExecutorId))]
        public virtual User? Executor { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public virtual Priority? Priority { get; set; }


        public virtual ICollection<TimeTrackingId> TimeTrackings { get; set; }

        public Issue()
        {
            TimeTrackings = new List<TimeTrackingId>();
        }
    }
}

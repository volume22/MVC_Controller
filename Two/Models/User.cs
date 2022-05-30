using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Two.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PositionId { get; set; }
        
        [ForeignKey(nameof(PositionId))]
        public virtual Position Position { get; set; }

    }
}

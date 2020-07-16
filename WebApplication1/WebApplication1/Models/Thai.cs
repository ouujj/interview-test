using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("Thai")]
    public class Thai
    {
        public long Id { get; set; }
        public string word { get; set; }

        public English English { get; set; }
        public long EngId { get; set; }

    }
}
